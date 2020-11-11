using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Marco", Location="Gdańsk", Cusine=CusineType.Italian },
                new Restaurant { Id = 2, Name = "Kebab King", Location="Warszawa", Cusine=CusineType.Indian },
                new Restaurant { Id = 3, Name = "Gigar", Location="Ełk", Cusine=CusineType.Mexican },
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }


        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants
                .Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name))
                .OrderBy(r => r.Name);
        }
    }
}
