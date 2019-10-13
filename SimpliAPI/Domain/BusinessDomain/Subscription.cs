using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.BusinessDomain
{
    public class Subscription : Entity
    {
        public Status Status { get; set; }
        public Address DeliveryAddress { get; set; }
        public Customer Customer { get; set; }
        public Supplier Supplier { get; set; }
        public List<Task> Active { get; set; }
        public List<Task> History { get; set; }
        public int Interval { get; set; }
        public Task TaskBluePrint { get; set; }
        public double Price { get; set; }
    }
}
