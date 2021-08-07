using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Restaurant {Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Italian },
                new Restaurant {Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mxican},
                new Restaurant {Id = 4, Name = "Kod Medveda", Location = "Arizona", Cuisine = CuisineType.Indian },
                new Restaurant {Id = 5, Name = "Vith George", Location = "Maryland", Cuisine = CuisineType.Croatian },
                new Restaurant {Id = 6, Name = "Blentava Glava", Location = "Maryland", Cuisine = CuisineType.Croatian },

            };
        }


        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(o => o.Name).ToList();
        }
    }
}
