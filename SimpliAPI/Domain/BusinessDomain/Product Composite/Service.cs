using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.BusinessDomain
{
    public abstract class Service : Entity
    {
        public Service Parent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public ProductType ProductType { get; set; }
        public override bool Equals(object obj)
        {
            var item = obj as Service;
            return Name.Equals(item?.Name) && Description.Equals(item?.Description);
        }

        public override int GetHashCode()
        {
            return Identity.GetHashCode();
        }
    }
}
