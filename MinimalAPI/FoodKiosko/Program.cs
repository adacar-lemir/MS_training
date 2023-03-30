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

app.MapGet("/foods", async (FoodDb db) => await db.Foods.ToListAsync());
app.MapGet("/food/{id}", async (FoodDb db, int id) => await db.Foods.FindAsync(id));
app.MapPost("/food", async (FoodDb db, Food food) =>
{
	await db.Foods.AddAsync(food);
	await db.SaveChangesAsync();
	return Results.Created($"/food/{food.Id}", food);
});
app.MapPut("/food/{id}", async (FoodDb db, Food updateFood, int id) => 
{
	var food = await db.Foods.FindAsync(id);
	if (food is null) return Results.NotFound();
	food.Name = updateFood.Name;
	food.Description = updateFood.Description;
	await db.SaveChangesAsync();
	return Results.NoContent();
});
app.MapDelete("/food/{id}", async (FoodDb db, int id) =>
{
	var food = await db.Foods.FindAsync(id);
	if (food is null)
	{
		return Results.NotFound();
	}
	db.Foods.Remove(food);
	await db.SaveChangesAsync();
	return Results.Ok();
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodKiosko API V1");
});

app.Run();
