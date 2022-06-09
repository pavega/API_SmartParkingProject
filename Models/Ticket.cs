using System;
using System.Collections.Generic;

namespace apiProyectoSmart.Models
{
    public partial class Ticket
    {
        public int IdTicket { get; set; }
        public int? ParkingLotId { get; set; }
        public int? SpotId { get; set; }
        public int? UserId { get; set; }
        public int? RateTypeId { get; set; }
        public DateTime? StarDay { get; set; }
        public DateTime? EndDay { get; set; }

        public virtual ParkingLot? ParkingLot { get; set; }
        public virtual RateType? RateType { get; set; }
        public virtual Spot? Spot { get; set; }
        public virtual User? User { get; set; }
    }
}
