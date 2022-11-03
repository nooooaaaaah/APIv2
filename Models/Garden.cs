using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public class Garden
    {
        public int GardenId { get; set; }
        public string GardenName { get; set; } = null!;

        public string UserID { get; set; }
        public User User { get; set; }

    }
}