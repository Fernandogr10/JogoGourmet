using System.Collections.Generic;
using System.Linq;

namespace JogoGourmet
{
    public class Menu
    {
        private List<Dish> _dishes;
        
        public Menu()
        {
            _dishes = new List<Dish>();
        }
        
        public IReadOnlyList<Dish> Dishes { get { return _dishes.ToArray(); } }

        public void AddDish(Dish dish)
        {
            if(string.IsNullOrEmpty(dish.Name) || string.IsNullOrWhiteSpace(dish.Name))
                return;
            
            _dishes.Add(dish);
        }
        
        public List<Dish> SetInitialDishes()
        {
            var firsDishCategory = new Category("Massa");
            var secondDishCategory = new Category("Bolo");
            var initialDishes = new List<Dish>
            {
                new Dish(null, firsDishCategory),
                new Dish(name: "Bolo de chocolate", secondDishCategory),
                new Dish(name: "Lasanha", firsDishCategory)
            };
            
            _dishes.AddRange(initialDishes);
            
            return _dishes;
        }
    }
}
