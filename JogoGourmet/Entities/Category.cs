using System.Collections.Generic;

namespace JogoGourmet
{
    public class Category
    {
        private readonly List<Category> _subCategories;

        public Category(string name)
        {
            Name = name;
            _subCategories = new List<Category>();
        }

        public string Name { get; private set; }
        public IReadOnlyList<Category> SubCategories { get { return _subCategories.ToArray(); } }
        
        public void AddCategory(Category category)
        {
            if(string.IsNullOrEmpty(category.Name) || string.IsNullOrWhiteSpace(category.Name))
                return;
            
            _subCategories.Add(category);
        }
    }
}