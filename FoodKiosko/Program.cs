// dotnet new web -o FoodKiosko -f net6.0

using FoodKiosko;
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

app.MapGet("/", () => "Hello World!");
app.MapGet("/food", () => "all food data"); // data
app.MapGet("/food/{id}", (int id) => $"food {id} data"); // data.SingleOrDefault(food => food.Id == id));
app.MapPost("/food", (Food food) => $"created food {food.Id} data");
app.MapPut("/food/{id}", (int id) => $"updated food {id} data");
app.MapDelete("/food/{id}", (int id) => $"deleted food {id} data");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodKiosko API V1");
});

app.Run();
