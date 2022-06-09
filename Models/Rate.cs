using System;
using System.Collections.Generic;

namespace apiProyectoSmart.Models
{
    public partial class Rate
    {
        public int IdRate { get; set; }
        public int TypeId { get; set; }
        public int RateTypeId { get; set; }

        public virtual RateType RateType { get; set; } = null!;
        public virtual VehicleType Type { get; set; } = null!;
    }
}
