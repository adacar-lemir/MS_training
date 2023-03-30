// dotnet new web -o FoodKiosko -f net6.0

using FoodKiosko.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; // dotnet add package Swashbuckle.AspNetCore --version 6.1.4

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => { });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<FoodDb>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddSwaggerGen(c => 
{ 
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodKiosko", Description = "A Kiosko of food", Version = "v1" });
});

var app = builder.Build();

app.UseCors("some unique string");

app.MapGet("/", () => "Welcoming to FoodKiosko!");
app.MapGet("/foods", async (FoodDb db) => await db.Foods.ToListAsync());

app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodKiosko API V1");
});

app.Run();
