using System;
using System.Collections.Generic;

namespace Event_DAL.Models
{
    public partial class Attendee
    {
        public int EventId { get; set; }
        public string UserId { get; set; } = null!;

        public virtual Event Event { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}
