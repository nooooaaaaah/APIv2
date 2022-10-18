using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public partial class User
    {
        public User();
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }


    }
}
