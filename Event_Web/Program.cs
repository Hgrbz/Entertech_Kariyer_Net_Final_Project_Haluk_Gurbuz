using Event_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Event_BLL.Data;

using Event_BLL.Areas.Identity.Data;
using Event_DAL.Repositories.Abstract;
using Event_DAL.Repositories.Concrete;
using Event_BLL.Abstract;
using Event_BLL.Concrete;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("KariyerDatabase");
builder.Services.AddDbContext<Kariyer_ProjeContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Event_BLLUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Event_BLLContext>();
builder.Services.AddDbContext<Event_BLLContext>(options =>
    options.UseSqlServer(connectionString));

//bu ikisi denemeyi getirmesi için
builder.Services.AddMvc();
builder.Services.AddMvcCore();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IEventService, EventService>();
//

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
