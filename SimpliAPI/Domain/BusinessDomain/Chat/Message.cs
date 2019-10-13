using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.BusinessDomain
{
    public class Message : Entity
    {
        public User User { get; set; }
        public string Content { get; set; }
        public ChatRoom ChatRoom { get; set; }
    }
}
