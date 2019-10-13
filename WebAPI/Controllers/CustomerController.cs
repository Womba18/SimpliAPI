using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Service.Service_Interfaces;
using ApplicationCore.Domain.BusinessDomain;

namespace WebAPI.Controllers
{ 

    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public Customer Get(string id)
        {
            return _customerService.GetCustomer(id);
        }
        
        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
