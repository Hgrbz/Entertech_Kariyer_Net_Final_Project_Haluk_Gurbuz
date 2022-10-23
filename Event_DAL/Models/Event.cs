using System;
using System.Collections.Generic;

namespace Event_DAL.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? EventLastApplicationDate { get; set; }
        public string? EventDescription { get; set; }
        public int? CityId { get; set; }
        public string? EventAddress { get; set; }
        public int? EventQuota { get; set; }
        public int? CategoryId { get; set; }
        public string? UserId { get; set; }
        public int? TicketFee { get; set; }

        public virtual Category? Category { get; set; }
        public virtual City? City { get; set; }
    }
}
