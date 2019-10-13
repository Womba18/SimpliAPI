using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.RepositoryDomain
{
    class Employee
    {
        public bool employeeDoesClean { get; set; }
        public string employeeEmail { get; set; }
        public string employeeFirstName { get; set; }
        public bool employeeIsAllowedCommunication { get; set; }
        public bool employeeIsSupervision { get; set; }
        public string employeeLastName { get; set; }
        public string employeePassword1 { get; set; }
        public string employeePassword2 { get; set; }
        public string employeePhoneNo { get; set; }
        public string pushtoken { get; set; }

    }
}
