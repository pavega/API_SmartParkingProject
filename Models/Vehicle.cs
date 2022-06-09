using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace apiProyectoSmart.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Spots = new HashSet<Spot>();
            Users = new HashSet<User>();
        }

        public int IdVehicle { get; set; }
        public string LicensePlate { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int? Weight { get; set; }
        public string Brand { get; set; } = null!;
        public int TypeId { get; set; }

        public virtual VehicleType Type { get; set; } = null!;
       
        [JsonIgnore]
        public virtual ICollection<Spot> Spots { get; set; }
       
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
