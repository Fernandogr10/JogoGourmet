namespace JogoGourmet.Entities
{
    public class Dish
    { 
        public Dish(string name, Category category, SubCategory subCategory)
        {
            Name = name;
            Category = category;
            SubCategory = subCategory;
        }
        
        public string Name { get; private set; }
        public Category Category { get; private set; }
        public SubCategory SubCategory { get; private set; }
    }
}