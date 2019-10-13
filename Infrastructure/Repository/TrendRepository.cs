using ApplicationCore.Domain.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Domain;
using ApplicationCore.Domain.BusinessDomain;

namespace Infrastructure.Repository
{
    public class TrendRepository : ITrendRepository
    {
        public Dictionary<MathVariable, double> GetTrend(Service service, TrendTypes trendType)
        {
            //HARDCODED the data is supposed to come from the database
            if (service.Name.Equals("Almindelig rengøring"))
            {
                if (trendType == TrendTypes.PET)
                {
                    return new Dictionary<MathVariable, double>
                    {
                        {MathVariable.k, -0.283 },
                        {MathVariable.c, 40.328 }
                    };
                }
                if (trendType == TrendTypes.CHILDREN)
                {
                    return new Dictionary<MathVariable, double>
                    {
                        {MathVariable.k, -0.139 },
                        {MathVariable.c, 35.16 }
                    };
                }
                if (trendType == TrendTypes.COHABITANTS)
                {
                    return new Dictionary<MathVariable, double>
                    {
                        { MathVariable.k, -0.235 },
                        { MathVariable.c, 51.355 }
                    };
                }

            }
            return null;
        }
    }
}
