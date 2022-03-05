using System;
using System.Collections.Generic;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;

namespace Blog.Screens.CategoryScreens
{
    public static class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tLista de Categorias");
            Console.WriteLine("-----------------------------------------");
            ListCategories();
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void ListCategories()
        {
            var repository = new Repository<Category>(Database.Connection);
            var categories = repository.GetAll();

            foreach (var item in categories) Console.WriteLine($"\t\tCategoria: {item.Id} - {item.Name} ({item.Slug})");
        }
    }
}