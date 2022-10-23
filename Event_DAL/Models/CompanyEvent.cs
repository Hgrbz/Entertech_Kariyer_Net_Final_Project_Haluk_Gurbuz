using System;
using System.Collections.Generic;

namespace Event_DAL.Models
{
    public partial class CompanyEvent
    {
        public int CompanyId { get; set; }
        public int PaidEventId { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
