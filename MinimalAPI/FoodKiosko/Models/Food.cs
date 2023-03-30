using Microsoft.EntityFrameworkCore;

namespace FoodKiosko.Models
{
	public class Food
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
	}

	// dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0
	class FoodDb :DbContext
	{
		public FoodDb(DbContextOptions options) : base(options) { }
		public DbSet<Food> Foods { get; set; } = null!;
	}
}
