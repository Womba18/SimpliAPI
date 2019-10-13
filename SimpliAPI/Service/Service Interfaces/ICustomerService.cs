using ApplicationCore.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Service.Service_Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomer(string CustomerID);
    }
}
