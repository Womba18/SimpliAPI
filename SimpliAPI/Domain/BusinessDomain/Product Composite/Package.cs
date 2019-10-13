using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.BusinessDomain
{
    public class Package : Service
    {
        public Dictionary<string, double> CostPerMinute { get; set; }
        public List<Service> Children { get; set; }
    }
}
