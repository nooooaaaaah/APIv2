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

        public int EventId { get; set; }
        public string? EventName { get; set; }
        public DateTime? DateTime { get; set; }
        public int GardenId { get; set; }

        public virtual Garden Garden { get; set; }
        public virtual ICollection<CalenderTask> CalenderTasks { get; set; }
    }
}
