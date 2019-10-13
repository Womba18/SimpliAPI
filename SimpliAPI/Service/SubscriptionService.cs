using ApplicationCore.Service.Service_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Domain.BusinessDomain;
using ApplicationCore.Domain.Repository_Interfaces;
using ApplicationCore.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Service
{
    public class SubscriptionService : ISubscriptionService
    {
        private IRepository<Subscription> _subscriptionRepository;
        private IRepository<Supplier> _supplierRepository;
        private IRepository<Customer> _customerRepository;
        private ITrendService _trendService;

        private Customer customer;

        public SubscriptionService(IRepository<Subscription> subscriptionRepository, IRepository<Supplier> supplierRepository, IRepository<Customer> customerRepository, ITrendService trendService)
        {
            _supplierRepository = supplierRepository;
            _subscriptionRepository = subscriptionRepository;
            _customerRepository = customerRepository;
            _trendService = trendService;

        }

        public Dictionary<string,List<Subscription>> GenerateSubscriptions(string CustomerID, SearchCriteria searchCriteria)
        {
            // Get a customer or return null
            customer = _customerRepository.Read(CustomerID);
            if (customer == null)
            {
                return null;
            }

            var familyData = new Dictionary<TrendTypes, int>
            {
                //HARDCODED data
                { TrendTypes.PET, 1 },
                { TrendTypes.CHILDREN, 2 },
                { TrendTypes.COHABITANTS, 2 }
            };
            customer.Family = new Family { FamilyData = familyData };

            // Get all suppliers
            var supplierList = _supplierRepository.ReadAll();
            var coverageList = new List<Supplier>();
            int houseSize = 0;
            Subscription sub = null;
            // Creates a list of covered suppliers
            foreach (var item in supplierList)
            {
                //TO BE REMOVED WHEN POSTAL CODES ARE USED FOR COVERAGE 
                //START
                item.Coverage = new List<string>
                {
                    "1307"
                };
                //END

                sub = sub ?? item.Subscriptions.Find(x => x.Identity == customer.Identity);
                customer.Address.HouseSize = sub != null && customer.Address.HouseSize == 0 ? sub.DeliveryAddress.HouseSize : 0;
                houseSize = houseSize == 0 ? searchCriteria?.DevAddress?.HouseSize ?? customer.Address.HouseSize : houseSize;

                //Currently every supplier is forced to do house sizes betweeen 50-700m2
                if ( item.Coverage != null && item.Coverage.Contains(customer.Address.PostalCode) && houseSize > 50 && houseSize <= 700)
                {
                    coverageList.Add(item);
                }
            }
            

            var customerNeeds = CreateNeeds(coverageList);
            //Currently it only does alm. rengøring based on arbitrary family parameters TO BE SPECIFIED WHEN FAMILY RESEARCH HAS MORE PROGRESS
            //TODO create all services when PACKAGEs and PRODUCTs are specified properly in Simpli

            var completeList = new Dictionary<string, List<Subscription>>();
            // creates completesubscription
            foreach (var item in coverageList)
            {
                var listSubscriptions = new List<Subscription>();
                
                //Create tasks for each supplier
                foreach (var needs in customerNeeds)
                {
                    var serviceMatch = item.Services.Find(x => x == needs.Service);
                    if (serviceMatch != null)
                    {
                        var subscriptionMatch = listSubscriptions.Find(x => x.Interval == needs.Interval);
                        // If there is a subscription with the same interval as needs add it to the match else make a new subscription
                        if (subscriptionMatch != null)
                        {
                            subscriptionMatch.TaskBluePrint.Services.Add(serviceMatch);
                        }
                        else
                        {
                            listSubscriptions.Add(new Subscription
                            {
                                Supplier = item,
                                TaskBluePrint = new Domain.BusinessDomain.Task
                                {
                                    Services = new List<Domain.BusinessDomain.Service> { serviceMatch },
                                },
                                Interval = needs.Interval,
                                Status = Status.PENDING,
                                Customer = customer,
                                DeliveryAddress = searchCriteria?.DevAddress ?? customer.Address,
                            });
                        }
                    }
                    
                }
                completeList.Add(item.Identity, listSubscriptions);
            }
            return completeList;
            
            // Get Customer from ID
            // get all suppliers in customer range
            // get all services from selected suppliers
            // generate customer needs
            // map customer needs against supplier services
            // if (subscription is complete) add to complete list<list<Subscription>>
            // loop  Searchlist for pair. Add pairs to complelist
            // sort completelist after SearchCriteria
            // pick top one and return
        }

        public string MergeProductPackageAndExtras(string CustomerID, Supplier supplier)
        {
            return CustomerID + " NOTYETIMPLEMENTED! packagemerge";
        }

        public string MergeTaskDates(string CustomerID)
        {
            return CustomerID + " NOTYETIMPLEMENTED! taskmerge";
        }

        private List<CustomerNeeds> CreateNeeds(List<Supplier> coverageList)
        {
            //Creates a hashset of unique services
            var coveredServices = new HashSet<Domain.BusinessDomain.Service>();
            foreach (var item in coverageList)
            {
                foreach (var service in item.Services)
                {
                    coveredServices.Add(service);
                }
            }

            //Creates a list of tasks that calls calculateinterval with every service to calculate trends asynchrounly
            var customerNeedsTasks = new List<Task<CustomerNeeds>>();
            foreach (var item in coveredServices)
            {
                customerNeedsTasks.Add(CalculateInterval(item));
            }

            //WhenAll.wait waits for all the calculations to be done and completes the tasks
            System.Threading.Tasks.Task.WhenAll(customerNeedsTasks).Wait();

            //Generates the list of customer needs
            var customerNeeds = new List<CustomerNeeds>();
            foreach (var customerNeedsTask in customerNeedsTasks)
            {
                if (customerNeedsTask.Result?.Interval <= 365) //It will only create needs that are done one or more times each year
                {
                    if (customerNeedsTask.Result.Interval < 1)
                    {
                        customerNeedsTask.Result.Interval = 1;
                    }
                    customerNeeds.Add(customerNeedsTask.Result);
                }
            }
            
            return customerNeeds;
        }

        private async Task<CustomerNeeds> CalculateInterval(Domain.BusinessDomain.Service service)
        {
            var familyTrend = _trendService.FamilyTrends.Find(x => x.Service.Equals(service));
            if (familyTrend == null)
            {
                return null;
            }
            var interval = new List<double>();
            // calculates intervals
            foreach (var item in familyTrend.Trends)
            {
                interval.Add(item.Value[MathVariable.c] * Math.Pow(Math.E, item.Value[MathVariable.k] * customer.Family.FamilyData[item.Key]));
                
            }
            var selectedInterval = Convert.ToInt32(Math.Round(interval.Min()));


            return new CustomerNeeds { Interval = selectedInterval, Service = service };
        }
    }
}
