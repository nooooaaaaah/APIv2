using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public partial class CalenderTask
    {
        public int EventTaskId { get; set; }
        public string EventId { get; set; } = null!;
        public int TaskId { get; set; }

        public virtual Calender Event { get; set; } = null!;
        public virtual Task Task { get; set; } = null!;
    }
}
