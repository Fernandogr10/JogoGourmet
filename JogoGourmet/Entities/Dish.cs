using System.Collections.Generic;

namespace JogoGourmet
{
    public class Dish
    { 
        public Dish(string name, Category category)
        {
            Name = name;
            Category = category;
        }
        
        public string Name { get; private set; }
        public Category Category { get; private set; }
    }
}