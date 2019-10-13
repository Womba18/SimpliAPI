using ApplicationCore.Domain.BusinessDomain;
using ApplicationCore.Domain.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.RepositoryDomain
{
    class Series
    {
        public List<string> done { get; set; }
        public List<string> future { get; set; }
        public Task master { get; set; }

    }
}
