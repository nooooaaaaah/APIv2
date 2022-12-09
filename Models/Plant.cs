using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; } = null!;
        public string PlantVariety { get; set; } = null!;
        public int GardenId { get; set; }
        public int UserId { get; set; }
        User User { get; set; }
        Garden Garden { get; set; }
        List<Sensor> Sensors { get; set; }

    }
}