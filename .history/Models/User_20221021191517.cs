using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public partial class User
    {
        public User()
        {
            Gardens = new HashSet<Garden>();
        }

        public int UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }

        public virtual ICollection<Garden> Gardens { get; set; }
    }
}
