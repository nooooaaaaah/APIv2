using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public class Job
    {

        public int JobId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        List<Event> Events { get; set; }

    }
}