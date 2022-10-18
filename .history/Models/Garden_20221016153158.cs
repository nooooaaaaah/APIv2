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

        public string GardenId { get; set; } = null!;
        public string? GardenName { get; set; }
        public string UserId { get; set; } = null!;

        public virtual ICollection<Calender> Calenders { get; set; }
        public virtual ICollection<Plant> Plants { get; set; }
    }
}
