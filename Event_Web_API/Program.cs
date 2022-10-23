using Event_DAL.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("KariyerDatabase");
builder.Services.AddDbContext<Kariyer_ProjeContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddMvc(options =>
{

    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

}).AddXmlSerializerFormatters();
builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
}).AddXmlSerializerFormatters();
    


builder.Services.AddSwaggerGen();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
