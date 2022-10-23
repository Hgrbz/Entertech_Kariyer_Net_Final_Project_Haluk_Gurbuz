using System;
using System.Collections.Generic;

namespace Event_DAL.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int? PaidEventId { get; set; }
        public int? Quantity { get; set; }
        public int? QuantitySold { get; set; }
        public int? QuantityAvailable { get; set; }
        public int? AttendeeId { get; set; }
    }
}
