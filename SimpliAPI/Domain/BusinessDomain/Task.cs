using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.BusinessDomain
{
    public class Task : Entity
    {
        public Subscription Subscription { get; set; }
        public Rating Rating { get; set; }
        public List<Service> Services { get; set; }
        public ChatRoom ChatRoom { get; set; }
        public List<Employee> Employees { get; set; }
        public DateTime Start { get; set; }
        public DateTime Completion { get; set; }
        //Skal endtimeorg være med?
    }
}
