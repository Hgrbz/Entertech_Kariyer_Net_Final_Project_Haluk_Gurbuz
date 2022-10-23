using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_DAL.Models
{
    public partial class Company
    {
        public Company()
        {
            CompanyEvents = new HashSet<CompanyEvent>();
        }
        
        protected internal int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? Domain { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        protected internal virtual ICollection<CompanyEvent> CompanyEvents { get; set; }
    }
}
