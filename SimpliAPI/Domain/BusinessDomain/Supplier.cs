using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.BusinessDomain
{
    public class Supplier : Entity
    {
        public string Name { get; set; }
        public string VATNo { get; set; }
        public Address Address { get; set; }
        public string Avatar { get; set; }
        public string CoverImage { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public DateTime Signup { get; set; }
        public string ContactEmail { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public List<Subscription> Subscriptions { get; set; }
        public List<Employee> Employees { get; set; }
        public List<ChatRoom> ChatRooms { get; set; }
        public List<Service> Services { get; set; }
        public List<string> Coverage { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
