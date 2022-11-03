using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public partial class Calender
    {
        public Calender()
        {
            CalenderTasks = new HashSet<CalenderTask>();
        }

        public int EventId { get; set; } = null!;
        public string? EventName { get; set; }
        public DateTime? DateTime { get; set; }
        public string GardenId { get; set; } = null!;

        public virtual Garden Garden { get; set; } = null!;
        public virtual ICollection<CalenderTask> CalenderTasks { get; set; }
    }
}
