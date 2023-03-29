namespace FoodKiosko.DB
{
	public record Food
	{
		public int Id { get; set; }
		public string ? Name { get; set; }
	}

	public class FoodDB
	{
		private static List<Food> _food = new List<Food>()
		{
			new Food { Id=1, Name="SpagguItaly" },
			new Food { Id=2, Name="BarbaQueue" },
			new Food { Id=3, Name="JamBurger" }
		};

		public static List<Food> GetFood()
		{
			return _food;
		}

		public static Food ? GetFood(int id)
		{
			return _food.SingleOrDefault(food => food.Id == id);
		}

		public static Food CreateFood(Food food)
		{
			_food.Add(food);
			return food;
		}

		public static Food UpdateFood(Food foodUpdate)
		{ 
			_food = _food.Select(food =>
			{
				if (food.Id == foodUpdate.Id)
				{
					food.Name = foodUpdate.Name;
				}
				return food;
			}).ToList();

			return foodUpdate;
		}

		public static void RemoveFood(int id)
		{
			_food = _food.FindAll(food => food.Id != id).ToList(); // trampa
		}
	}
}
