using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public class Garden
    {
        public int GardenId { get; set; }
        public string? GardenName { get; set; }
        public int UserId { get; set; }

        //public virtual User User { get; set; }
        public virtual List<Calender> Calenders { get; set; }
        public virtual List<Plant> Plants { get; set; }
    }
}
