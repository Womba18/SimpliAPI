using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.Repository_Interfaces
{
    public interface ITrendRepository
    {
        Dictionary<MathVariable, double> GetTrend(Domain.BusinessDomain.Service service, TrendTypes trendType);
    }
}
