using ApplicationCore.Domain.BusinessDomain;
using ApplicationCore.Domain.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository.RepositoryDomain
{
    class Supplier : IMapTo<ApplicationCore.Domain.BusinessDomain.Supplier>
    {
        public Dictionary<string, Extra> extras { get; set; }
        public MasterData masterData { get; set; }
        public Dictionary<string, Offering> offerings { get; set; }
        public Selection selections { get; set; }
        public Dictionary<string, Customer> customers { get; set; }

        public ApplicationCore.Domain.BusinessDomain.Supplier MapTo(string key)
        {
            List<string> temp = masterData.companyAddressRoad?.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
           
            List<Service> services = new List<Service>();

            foreach (var item in extras)
            {
                services.Add(item.Value.MapTo(item.Key));
            }
            foreach (var item in offerings)
            {
                services.Add(item.Value.MapTo(item.Key));
            }

            List<Subscription> subscriptions = new List<Subscription>();
            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    foreach (var series in customer.Value.series)
                    {
                        var sub = new Subscription
                        {
                            Identity = series.Key,
                            DeliveryAddress = new Address
                            {
                                HouseSize = Int32.Parse(series.Value.master.m2)
                            },
                            Customer = new ApplicationCore.Domain.BusinessDomain.Customer
                            {
                                Identity = customer.Key
                            }
                        };

                        subscriptions.Add(sub);
                    }
                } 
            }

            return new ApplicationCore.Domain.BusinessDomain.Supplier
            {
                Identity = key,
                Name = masterData.companyName,
                VATNo = masterData.cvrNo,
                Address = new Address {
                    PostalCode = masterData.companyAddressPostal,
                    StreetName = temp.Count > 0 ? temp[0] : null,
                    StreetNumber = temp.Count > 1 ? temp[1] : null,
                    Floor = temp.Count > 2 ? temp[2] : null,
                    Door = temp.Count > 3 ? temp[3] : null,
                },
                Latitude = masterData.companyLat,
                Longtitude = masterData.companyLng,
                Services = services,
                ContactEmail = masterData.contactEmail,
                ContactFirstName = masterData.contactFirstName,
                ContactLastName = masterData.contactLastName,
                ContactPhoneNumber = masterData.contactPhoneNo,
                Subscriptions = subscriptions
            };
        }
    }
}
