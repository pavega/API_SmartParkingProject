using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace apiProyectoSmart.Models
{
    public partial class ParkingLot
    {
        public ParkingLot()
        {
            Spots = new HashSet<Spot>();
            Tickets = new HashSet<Ticket>();
            Users = new HashSet<User>();
        }

        public int IdParkingLot { get; set; }
        public string Name { get; set; } = null!;
        public int CapacitySize { get; set; }
        public string Province { get; set; } = null!;
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        
        [JsonIgnore]
        public virtual ICollection<Spot> Spots { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }
       
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
