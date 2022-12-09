using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public class Garden
    {
        public int GardenId { get; set; }
        public string GardenName { get; set; } = null!;
        public int UserId { get; set; }
        User User { get; set; }
        List<Plant> Plants { get; set; }
        List<Sensor> Sensors { get; set; }
    }
}