using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public class Job
    {

        public int JobId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Summary { get; set; }

    }
}