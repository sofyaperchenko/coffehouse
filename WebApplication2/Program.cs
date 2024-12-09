using Microsoft.EntityFrameworkCore;
using WebApplication2.ActionClaas;
using WebApplication2.Interfes;
using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);

var connectingString = builder.Configuration.GetConnectionString("ConnectDb"); 
builder.Services.AddDbContext<CoffeHouseContext>(options => options.UseSqlServer(connectingString));

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IClient, ClientClass>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
