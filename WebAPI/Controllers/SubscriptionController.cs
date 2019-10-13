using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Domain.BusinessDomain;
using ApplicationCore.Domain;
using ApplicationCore.Service.Service_Interfaces;
using ApplicationCore.Domain.Repository_Interfaces;
using ApplicationCore.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SubscriptionController : Controller
    {
        private ISubscriptionService _subscriptionService;
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        
        [Route("GenerateSubscriptions/{customerID}")]
        [HttpPut("{customerID}")]
        public Dictionary<string,List<Subscription>> GenerateSubscriptions(string customerID, [FromBody]SearchCriteria searchCriteria)
        {
            return _subscriptionService.GenerateSubscriptions(customerID, searchCriteria);
        }

        // GET api/values/5
        [HttpOptions]
        public string Options()
        {
            return "PUT route/{CustomerID}";
        }

        [Route("MergeProductPackageAndExtras/{customerID}")]
        [HttpPut("{customerID}")]
        public string MergeProductPackageAndExtras(string customerID, Supplier supplier)
        {
            return _subscriptionService.MergeProductPackageAndExtras(customerID, supplier);
        }

        [Route("MergeTaskDates/{customerID}")]
        [HttpPut("{customerID}")]
        public string MergeTaskDates(string customerID)
        {
            return _subscriptionService.MergeTaskDates(customerID);
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
