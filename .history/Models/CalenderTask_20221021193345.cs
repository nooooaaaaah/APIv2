﻿using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public partial class CalenderTask
    {
        public string EventTaskId { get; set; } = null!;
        public string EventId { get; set; } = null!;
        public int TaskId { get; set; };

        public virtual Calender Event { get; set; } = null!;
        public virtual Task Task { get; set; } = null!;
    }
}
