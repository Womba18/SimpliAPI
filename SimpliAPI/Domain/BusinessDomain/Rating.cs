using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.BusinessDomain
{
    public class Rating : Entity
    {
        public int Score { get; set; }
        public string Comment { get; set; }
        public Supplier Supplier { get; set; }
    }
}
