using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public partial class Garden
    {
        public Garden()
        {
            Calenders = new HashSet<Calender>();
            Plants = new HashSet<Plant>();
        }

        public int GardenId { get; set; }
        public string? GardenName { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Calender> Calenders { get; set; }
        public virtual ICollection<Plant> Plants { get; set; }
    }
}
