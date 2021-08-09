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
                new Restaurant {Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican},
                new Restaurant {Id = 4, Name = "Kod Medveda", Location = "Arizona", Cuisine = CuisineType.Indian },
                new Restaurant {Id = 5, Name = "Vith George", Location = "Maryland", Cuisine = CuisineType.Croatian },
                new Restaurant {Id = 6, Name = "Blentava Glava", Location = "Maryland", Cuisine = CuisineType.Croatian },

            };
        }

        public Restaurant Add(Restaurant newRestarant)
        {
            restaurants.Add(newRestarant);
            newRestarant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestarant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants.Where(str => string.IsNullOrEmpty(name) || str.Name.StartsWith(name)).OrderBy(o => o.Name).ToList();
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}
