using ApplicationCore.Service.Service_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Domain;
using ApplicationCore.Domain.BusinessDomain;
using ApplicationCore.Domain.Repository_Interfaces;
using System.Linq;

namespace ApplicationCore.Service
{
    public class TrendService : ITrendService
    {
        private IRepository<Supplier> _supplierRepository;
        private ITrendRepository _trendRepository;
        public List<FamilyTrends> FamilyTrends { get; set; }

        public TrendService(IRepository<Supplier> supplierRepository, ITrendRepository trendRepository)
        {
            _supplierRepository = supplierRepository;
            _trendRepository = trendRepository;
            GenerateTrends();
        }

        public void GenerateTrends()
        {
            var listFamilyTrends = new List<FamilyTrends>();
            var listSupplier = _supplierRepository.ReadAll();

            var services = new HashSet<Domain.BusinessDomain.Service>();
            // all unique services
            foreach (var item in listSupplier)
            {
                foreach (var service in item.Services)
                {
                    services.Add(service);
                }
            }
            // gets all trendTypes
            var trendTypes = (TrendTypes[])Enum.GetValues(typeof(TrendTypes));
            // gets trend mathVariebels and creates a list of familytrends foreach service and trends
            foreach (var item in services)
            {
                var trends = new Dictionary<TrendTypes, Dictionary<MathVariable, double>>();
                foreach (var trendType in trendTypes)
                {
                    //get trends data from the database
                    var trend = _trendRepository.GetTrend(item, trendType);
                    if (trend != null)
                    {
                        trends.Add(trendType, trend);
                    }
                }
                if (trends.Count > 0)
                {
                listFamilyTrends.Add( new FamilyTrends { Service = item, Trends = trends });
                }
            }
            FamilyTrends = listFamilyTrends;
        }
    }
}
