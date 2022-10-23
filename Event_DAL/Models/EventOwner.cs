using System;
using System.Collections.Generic;

namespace Event_DAL.Models
{
    public partial class EventOwner
    {
        public string OwnerId { get; set; } = null!;
        public int EventId { get; set; }

        public virtual Event Event { get; set; } = null!;
        public virtual AspNetUser Owner { get; set; } = null!;
    }
}
