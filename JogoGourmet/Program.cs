using System;
using System.Collections.Generic;
using System.Linq;
using JogoGourmet.Entities;

namespace JogoGourmet
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            menu.SetInitialDishes();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Pense em um prato que você gosta");
                Console.WriteLine();
                
                menu = AskDishCategory(menu);
            }
        }
        
        private static void ShowOptions()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
        }

        private static short UserOutput()
        {
            var answer = Console.ReadLine();

            if (answer == "1" || answer == "2") 
                return short.Parse(answer);
            
            Console.WriteLine("Opção invalida");
            return 0;
        }

        static Menu AskDishCategory(Menu menu)
        {
            var dishFromFirstCategory = menu.Dishes.FirstOrDefault(d => d.Category is not null && d.Name is null);
            
            if(dishFromFirstCategory is null) 
                return menu;
            
            Console.WriteLine($"O prato que você pensou é {dishFromFirstCategory.Category.Name}?");

            ShowOptions();
            
            var option = UserOutput();

            Console.WriteLine();
            
            switch (option)
            {
                case 1: 
                    return AskDishFromCategory(menu, dishFromFirstCategory);
                case 2: 
                    return AskDishName(menu, dishFromFirstCategory); 
                default: 
                    Console.WriteLine("Opção inválida");
                    break;
            }

            return menu;
        }

        static Menu AskDishName(Menu menu, Dish dish)
        {
            var otherDishes = menu.Dishes.Where(d => d.Category is not null 
                                                     && d.Category.Name != dish.Category.Name 
                                                     && d.Category.SubCategories.All(s => s.BaseCategoryName != dish.Category.Name)).ToList();
            
            var firstDish = otherDishes.FirstOrDefault(); 

            if (firstDish == null) 
                return menu;

            foreach (var item in otherDishes)
            {
                Console.WriteLine($"O prato que você pensou é {item.Name}?");

                ShowOptions();

                var option = UserOutput();

                Console.WriteLine();
            
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Acertei de novo!");
                        Console.WriteLine();
                        return menu;
                    case 2:
                        continue;
                    default:
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine();
                        break;
                }
            }
            
            menu.AddDish(AskDishDifference(firstDish));
            return menu;
        }
        
        static Menu AskDishFromCategory(Menu menu, Dish dish)
        {
            var dishesWithinCategory = new List<Dish>();
            var subCategoryNames = dish.Category.SubCategories.Select(s => s.Name);
            
            foreach (var subCategoryName in subCategoryNames)
            {
                dishesWithinCategory.AddRange(menu.Dishes.Where(d => d.SubCategory is not null && d.SubCategory.Name.Contains(subCategoryName)));
            }

            foreach (var item in dishesWithinCategory)
            {
                Console.WriteLine($"O prato que você pensou é {item.Name}?");

                ShowOptions();
            
                var option = UserOutput();

                Console.WriteLine();
            
                switch (option)
                {
                    case 1: 
                        Console.WriteLine("Acertei de novo!");
                        Console.WriteLine();
                        return menu;
                    case 2: 
                        continue;
                    default: 
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine();
                        break;
                }
            }
            
            var firstDishWithinCategory = menu.Dishes.FirstOrDefault(d => d.Category is not null && d.Category.Name == dish.Category.Name && d.Name is not null);
            menu.AddDish(AskDishDifference(firstDishWithinCategory, true));
            
            return menu;
        }
        
        static Dish AskDishDifference(Dish dish, bool isSubCategory = false)
        {
            Console.WriteLine("Qual prato você pensou?");

            var answer = Console.ReadLine();
            
            if(string.IsNullOrEmpty(answer) || string.IsNullOrWhiteSpace(answer))
                return null;

            Console.WriteLine("");
            Console.WriteLine($"{answer} é ________ mas {dish.Name} não");

            return ExecuteComplete(answer, dish, isSubCategory);
        }
        
        static Dish ExecuteComplete(string dishName, Dish dish, bool isSubCategory = false)
        {
            var answer = Console.ReadLine();

            if(string.IsNullOrEmpty(answer) || string.IsNullOrWhiteSpace(answer))
                return null;
            
            if(!isSubCategory)
                return new Dish(dishName, new Category(answer), null);

            var subCategory = new SubCategory(answer, dish.Category.Name);
            
            dish.Category.AddSubCategory(subCategory);
            return new Dish(dishName, null, subCategory);
        }
    }
}
