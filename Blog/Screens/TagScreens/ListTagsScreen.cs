using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class ListTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tLista de tags");
            Console.WriteLine("-----------------------------------------");
            ListTags();
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void ListTags()
        {
            var repository = new Repository<Tag>(Database.Connection);
            var tags = repository.GetAll();
            foreach (var item in tags) Console.WriteLine($"\t\t{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}