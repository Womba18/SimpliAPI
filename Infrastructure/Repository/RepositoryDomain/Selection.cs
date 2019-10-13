using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.RepositoryDomain
{
    class Selection
    {
        public bool companyCollectiveAgreement { get; set; }
        public bool companyDoCommercial { get; set; }
        public bool companyDoPrivate { get; set; }
        public string companyMaxReach { get; set; }
        public bool companyNonBindingMeet { get; set; }
        public bool companySamePerson { get; set; }
        public bool companySatisfactionGuarantee { get; set; }
        public bool companySupplies { get; set; }
        public string companyTransportFee { get; set; }
        public string companyUBReach { get; set; }
        public string companyVideo { get; set; }
    }
}
