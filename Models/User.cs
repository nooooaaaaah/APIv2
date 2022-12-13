using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }

        List<Garden> Gardens { get; set; }
        List<Event> Events { get; set; }
        List<Job> Jobs { get; set; }
        List<Plant> Plants { get; set; }
        List<Sensor> Sensors { get; set; }

    }
}
