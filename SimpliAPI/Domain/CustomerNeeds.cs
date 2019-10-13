using ApplicationCore.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain
{
    public class CustomerNeeds
    {
        public BusinessDomain.Service Service { get; set; }
        public int Interval { get; set; }
    }
}
