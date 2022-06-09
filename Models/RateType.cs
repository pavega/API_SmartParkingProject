using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace apiProyectoSmart.Models
{
    public partial class RateType
    {
        public RateType()
        {
            Rates = new HashSet<Rate>();
            Tickets = new HashSet<Ticket>();
        }

        public int IdRateType { get; set; }
        public string BookingTime { get; set; } = null!;
        public double Amount { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Rate> Rates { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
