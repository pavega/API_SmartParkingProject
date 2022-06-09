using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace apiProyectoSmart.Models
{
    public partial class User
    {
        public User()
        {
            Tickets = new HashSet<Ticket>();
            ParkingLots = new HashSet<ParkingLot>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int IdUser { get; set; }
        public string Identification { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? TelNumber { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
       
        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<ParkingLot> ParkingLots { get; set; }
       
        [JsonIgnore]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
