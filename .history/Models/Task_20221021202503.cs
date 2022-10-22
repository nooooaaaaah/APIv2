using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public class Task
    {

        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }

        public virtual List<CalenderTask> CalenderTasks { get; set; }
    }
}
