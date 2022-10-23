using Event_BLL.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Event_DAL.Models;

namespace Event_BLL.Data;

public class Event_BLLContext : IdentityDbContext<Event_BLLUser>
{
    public Event_BLLContext(DbContextOptions<Event_BLLContext> options)
        : base(options)
    {
    }
    protected  Event_BLLContext(DbContextOptions options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public DbSet<Event_DAL.Models.Event> Event { get; set; }
    
}
