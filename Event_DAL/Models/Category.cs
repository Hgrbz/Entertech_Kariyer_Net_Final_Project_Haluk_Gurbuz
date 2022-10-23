using System;
using System.Collections.Generic;

namespace Event_DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            Events = new HashSet<Event>();
        }

        public int CategoryId { get; set; }
        public string? CategoriyName { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
