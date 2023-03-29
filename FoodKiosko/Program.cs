// dotnet new web -o FoodKiosko -f net6.0

using FoodKiosko.DB;
using Microsoft.OpenApi.Models; // dotnet add package Swashbuckle.AspNetCore --version 6.1.4

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => { });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{ 
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodKiosko", Description = "A Kiosko of food", Version = "v1" });
});

var app = builder.Build();

app.UseCors("some unique string");

app.MapGet("/", () => "Welcoming to FoodKiosko!");
app.MapGet("/food", () => FoodDB.GetFood());
app.MapGet("/food/{id}", (int id) => FoodDB.GetFood(id)); // data.SingleOrDefault(food => food.Id == id));
app.MapPost("/food", (Food food) => FoodDB.CreateFood(food));
app.MapPut("/food/{id}", (Food food) => FoodDB.UpdateFood(food));
app.MapDelete("/food/{id}", (int id) => FoodDB.RemoveFood(id));

app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodKiosko API V1");
});

app.Run();
