using System.Collections.Generic;

namespace JogoGourmet.Entities
{
    public class Menu
    {
        private readonly List<Dish> _dishes;
        
        public Menu()
        {
            _dishes = new List<Dish>();
        }
        
        public IReadOnlyList<Dish> Dishes => _dishes.ToArray();

        public void AddDish(Dish dish)
        {
            if(string.IsNullOrEmpty(dish.Name) || string.IsNullOrWhiteSpace(dish.Name))
                return;
            
            _dishes.Add(dish);
        }
        
        public List<Dish> SetInitialDishes()
        {
            var massa = new Category("Massa");
            var massaItaliana = new SubCategory("Italiana", massa.Name);
            
            massa.AddSubCategory(massaItaliana);
            
            var initialDishes = new List<Dish>
            {
                new Dish(null, massa, null),
                new Dish(name: "Bolo de chocolate", new Category("Bolo"), null),
                new Dish(name: "Lasanha", massa, massaItaliana)
            };
            
            _dishes.AddRange(initialDishes);
            
            return _dishes;
        }
    }
}