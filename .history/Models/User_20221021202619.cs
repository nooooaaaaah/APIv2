using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }

        public virtual List<Garden> Gardens { get; set; }
    }
}
