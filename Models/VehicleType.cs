using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace apiProyectoSmart.Models
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Rates = new HashSet<Rate>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int IdType { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Rate> Rates { get; set; }
       
        [JsonIgnore]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
