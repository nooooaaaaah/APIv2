using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public string SensorType { get; set; }
        public int SensorData { get; set; }
        public int UserId { get; set; }
        public int GardenId { get; set; }
        public int PlantId { get; set; }

        User User { get; set; }
        Garden Garden { get; set; }
        Plant Plant { get; set; }
    }
}