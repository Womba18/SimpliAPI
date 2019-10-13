using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.BusinessDomain
{
    public class Customer : User
    {
        public string ExclusiveTo { get; set; }
        public bool TermsOfService { get; set; }
        public List<ChatRoom> ChatRooms { get; set; }
        public List<Subscription> Subscriptions { get; set; }
        public Family Family { get; set; }

    }
}
