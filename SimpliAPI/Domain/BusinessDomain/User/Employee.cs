using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.BusinessDomain
{
    public class Employee : User
    {
        public string password1 { get; set; }
        public string password2 { get; set; }
        public bool DoesCleaning { get; set; }
        public bool IsSupervisor { get; set; }
        public bool IsAllowedCommunication { get; set; }
        public List<Task> Tasks { get; set; }
        public Supplier Supplier { get; set; }
    }
}
