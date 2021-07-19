using System.Collections.Generic;

namespace JogoGourmet.Entities
{
    public class Category
    {
        private readonly List<SubCategory> _subCategories;

        public Category(string name)
        {
            Name = name;
            _subCategories = new List<SubCategory>();
        }

        public string Name { get; private set; }
        public IReadOnlyList<SubCategory> SubCategories => _subCategories.ToArray();

        public void AddSubCategory(SubCategory subCategory)
        {
            if(string.IsNullOrEmpty(subCategory.Name) || string.IsNullOrWhiteSpace(subCategory.Name))
                return;
            
            _subCategories.Add(subCategory);
        }
    }
}