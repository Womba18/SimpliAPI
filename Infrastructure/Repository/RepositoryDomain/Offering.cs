using ApplicationCore.Domain;
using ApplicationCore.Domain.BusinessDomain;
using ApplicationCore.Domain.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.RepositoryDomain
{
    public class Offering : IMapTo<Package>
    {
        public string name { get; set; }
        public string what { get; set; }

        public string cost51to60 { get; set; }
        public string cost61to70 { get; set; }
        public string cost71to80 { get; set; }
        public string cost81to90 { get; set; }
        public string cost91to100 { get; set; }
        public string cost101to110 { get; set; }
        public string cost111to120 { get; set; }
        public string cost121to130 { get; set; }
        public string cost131to140 { get; set; }
        public string cost141to150 { get; set; }
        public string cost151to160 { get; set; }
        public string cost161to170 { get; set; }
        public string cost171to180 { get; set; }
        public string cost181to190 { get; set; }
        public string cost191to200 { get; set; }
        public string cost201to230 { get; set; }
        public string cost231to260 { get; set; }
        public string cost261to300 { get; set; }
        public string cost301to450 { get; set; }
        public string cost451to700 { get; set; }

        public string min51to60 { get; set; }
        public string min61to70 { get; set; }
        public string min71to80 { get; set; }
        public string min81to90 { get; set; }
        public string min91to100 { get; set; }
        public string min101to110 { get; set; }
        public string min111to120 { get; set; }
        public string min121to130 { get; set; }
        public string min131to140 { get; set; }
        public string min141to150 { get; set; }
        public string min151to160 { get; set; }
        public string min161to170 { get; set; }
        public string min171to180 { get; set; }
        public string min181to190 { get; set; }
        public string min191to200 { get; set; }
        public string min201to230 { get; set; }
        public string min231to260 { get; set; }
        public string min261to300 { get; set; }
        public string min301to450 { get; set; }
        public string min451to700 { get; set; }

        public Package MapTo(string key)
        {
            var costPerMin = new Dictionary<string, double> {
                { "cost51to60", Double.Parse(cost51to60.Replace(',','.')) },
                { "cost61to70", Double.Parse(cost61to70.Replace(',','.')) },
                { "cost71to80", Double.Parse(cost71to80.Replace(',','.')) },
                { "cost81to90", Double.Parse(cost81to90.Replace(',','.')) },
                { "cost91to100", Double.Parse(cost91to100.Replace(',','.')) },
                { "cost101to110", Double.Parse(cost101to110.Replace(',','.')) },
                { "cost111to120", Double.Parse(cost111to120.Replace(',','.')) },
                { "cost121to130", Double.Parse(cost121to130.Replace(',','.')) },
                { "cost131to140", Double.Parse(cost131to140.Replace(',','.')) },
                { "cost141to150", Double.Parse(cost141to150.Replace(',','.')) },
                { "cost151to160", Double.Parse(cost151to160.Replace(',','.')) },
                { "cost161to170", Double.Parse(cost161to170.Replace(',','.')) },
                { "cost171to180", Double.Parse(cost171to180.Replace(',','.')) },
                { "cost181to190", Double.Parse(cost181to190.Replace(',','.')) },
                { "cost191to200", Double.Parse(cost191to200.Replace(',','.')) },
                { "cost201to230", Double.Parse(cost201to230.Replace(',','.')) },
                { "cost231to260", Double.Parse(cost231to260.Replace(',','.')) },
                { "cost261to300", Double.Parse(cost261to300.Replace(',','.')) },
                { "cost301to450", Double.Parse(cost301to450.Replace(',','.')) },
                { "cost451to700", Double.Parse(cost451to700.Replace(',','.')) },

                { "min51to60", Double.Parse(min51to60.Replace(',','.')) },
                { "min61to70", Double.Parse(min61to70.Replace(',','.')) },
                { "min71to80", Double.Parse(min71to80.Replace(',','.')) },
                { "min81to90", Double.Parse(min81to90.Replace(',','.')) },
                { "min91to100", Double.Parse(min91to100.Replace(',','.')) },
                { "min101to110", Double.Parse(min101to110.Replace(',','.')) },
                { "min111to120", Double.Parse(min111to120.Replace(',','.')) },
                { "min121to130", Double.Parse(min121to130.Replace(',','.')) },
                { "min131to140", Double.Parse(min131to140.Replace(',','.')) },
                { "min141to150", Double.Parse(min141to150.Replace(',','.')) },
                { "min151to160", Double.Parse(min151to160.Replace(',','.')) },
                { "min161to170", Double.Parse(min161to170.Replace(',','.')) },
                { "min171to180", Double.Parse(min171to180.Replace(',','.')) },
                { "min181to190", Double.Parse(min181to190.Replace(',','.')) },
                { "min191to200", Double.Parse(min191to200.Replace(',','.')) },
                { "min201to230", Double.Parse(min201to230.Replace(',','.')) },
                { "min231to260", Double.Parse(min231to260.Replace(',','.')) },
                { "min261to300", Double.Parse(min261to300.Replace(',','.')) },
                { "min301to450", Double.Parse(min301to450.Replace(',','.')) },
                { "min451to700", Double.Parse(min451to700.Replace(',','.')) }
            };
            return new Package { Identity = key, Name = name, ProductType = ProductType.PACKAGE, Description = what, CostPerMinute = costPerMin };
        }
    }
}
