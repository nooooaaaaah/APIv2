using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public class Event
    {

        public int EventId { get; set; }
        public string? EventName { get; set; }
        public string? EventDescription { get; set; }

        public int TaskId { get; set; }
        Job Task { get; set; }
    }
}