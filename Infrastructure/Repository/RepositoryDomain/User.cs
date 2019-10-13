using ApplicationCore.Domain.BusinessDomain;
using ApplicationCore.Domain.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.RepositoryDomain
{
    class User : IMapTo<ApplicationCore.Domain.BusinessDomain.Customer>
    {
        public string key { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string exclusiveTo { get; set; }
        public string pushtoken { get; set; }
        public bool terms { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }

        public ApplicationCore.Domain.BusinessDomain.Customer MapTo(string key)
        {
            List<string> temp = new List<string>(address.Split(new char[] {',',' '}, StringSplitOptions.RemoveEmptyEntries));
            
            return new ApplicationCore.Domain.BusinessDomain.Customer
            {
                Identity = key,
                Address = new Address {
                    StreetName = temp[0],
                    StreetNumber = temp[1],
                    PostalCode = temp[2]
                },
                Email = email,
                ExclusiveTo = exclusiveTo,
                FirstName = userFirstName,
                LastName = userLastName,
                PushToken = pushtoken,
                TermsOfService = terms
            };
        }
    }
}
