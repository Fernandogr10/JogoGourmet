namespace JogoGourmet.Entities
{
    public class SubCategory
    {
        public SubCategory(string name, string baseCategoryName)
        {
            Name = name;
            BaseCategoryName = baseCategoryName;
        }
        
        public string Name { get; private set; }
        public string BaseCategoryName { get; private set; }
    }
}