using System;
using System.Collections.Generic;

namespace APIv2
{
    public partial class CalenderTask
    {
        public string EventId { get; set; } = null!;
        public string TaskId { get; set; } = null!;

        public virtual Calender Event { get; set; } = null!;
        public virtual Task Task { get; set; } = null!;
    }
}
