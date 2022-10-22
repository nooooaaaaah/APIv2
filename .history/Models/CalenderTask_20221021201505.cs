using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public partial class CalenderTask
    {
        public int EventTaskId { get; set; }
        public int EventId { get; set; }
        public int TaskId { get; set; }

        public virtual Calender Event { get; set; } = null!;
        public virtual Task Task { get; set; }
    }
}
