using System;
using System.Collections.Generic;

namespace APIv2
{
    public partial class Plant
    {
        public string PlantId { get; set; } = null!;
        public string? PlantName { get; set; }
        public string? PlantVariety { get; set; }
        public string? PlantDate { get; set; }
        public string GardenId { get; set; } = null!;

        public virtual Garden Garden { get; set; } = null!;
    }
}
