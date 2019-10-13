using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.BusinessDomain
{
    public class Address
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int HouseSize { get; set; }
        public string Floor { get; set; }
        public string Door { get; set; }
    }
}
