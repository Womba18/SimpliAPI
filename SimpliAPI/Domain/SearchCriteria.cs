using ApplicationCore.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain
{
    public class SearchCriteria
    {
        public string SortOrder { get; set; }

        public Address DevAddress { get; set; }
    }
}
