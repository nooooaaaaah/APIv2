using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public partial class Task
    {
        public string TaskId { get; set; } = null!;
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
    }
}
