using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public partial class Task
    {
        public Task()
        {
            CalenderTasks = new HashSet<CalenderTask>();
        }

        public string TaskId { get; set; } = null!;
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }

        public virtual ICollection<CalenderTask> CalenderTasks { get; set; }
    }
}
