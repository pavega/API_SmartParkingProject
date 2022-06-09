using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace apiProyectoSmart.Models
{
    public partial class Spot
    {
        public Spot()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdSpot { get; set; }
        public int Number { get; set; }
        public string Type { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int? VehicleId { get; set; }
        public int ParkingLotId { get; set; }

        public virtual ParkingLot ParkingLot { get; set; } = null!;
        public virtual Vehicle? Vehicle { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
