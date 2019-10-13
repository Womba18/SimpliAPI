using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.BusinessDomain
{
    public class ChatRoom : Entity
    {
        public Customer Customer { get; set; }
        public Supplier Supplier { get; set; }
        public List<Message> Messages { get; set; }
        public Task Task { get; set; }
    }
}
