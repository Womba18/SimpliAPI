using ApplicationCore.Domain;
using ApplicationCore.Domain.BusinessDomain;
using ApplicationCore.Domain.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.RepositoryDomain
{
    public class Extra : IMapTo<Product>
    {
        public double cost { get; set; }
        public int min { get; set; }
        public string name { get; set; }

        public Product MapTo(string key)
        {
            return new Product { Identity = key, Cost = cost, Name = name, Duration = min, ProductType = ProductType.EXTRA };
        }
    }
}
