using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.BusinessDomain
{
    public abstract class User : Entity
    {
        public Address Address { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PushToken { get; set; }
        public string PhoneNumber { get; set; }
        public List<Message> Massages { get; set; }

    }
}
