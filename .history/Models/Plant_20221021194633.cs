using System;
using System.Collections.Generic;

namespace APIv2.models
{
    public partial class Plant
    {
        public int PlantId { get; set; }
        public string? PlantName { get; set; }
        public string? PlantVariety { get; set; }
        public string? PlantDate { get; set; }
        public int GardenId { get; set; }

        public virtual Garden Garden { get; set; } = null!;
    }
}
