using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain
{
    public class FamilyTrends
    {
        public Domain.BusinessDomain.Service Service { get; set; }
        public Dictionary<TrendTypes,Dictionary<MathVariable,double>> Trends { get; set; }

    }
}
