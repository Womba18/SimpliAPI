using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.RepositoryDomain
{
    class Request
    {
        public string address { get; set; }
        public double amount { get; set; }
        public string comment { get; set; }
        public string date { get; set; }
        public int interval { get; set; }
        public string m2 { get; set; }
        public int minutes { get; set; }
        public string selectType { get; set; }
        public string status { get; set; }
        public int subscriptionId { get; set; }
        public string time { get; set; }
        public double transportCost { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string userUid { get; set; }
    }
}
