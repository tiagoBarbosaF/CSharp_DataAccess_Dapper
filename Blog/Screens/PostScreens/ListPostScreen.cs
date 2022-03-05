using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class ListPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tPostagens");
            Console.WriteLine("-----------------------------------------");

            ListPost();

            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void ListPost()
        {
            var repository = new Repository<Post>(Database.Connection);
            var posts = repository.GetAll();

            foreach (var item in posts)
            {
                Console.WriteLine($"\n\t{item.Id} - {item.Title}, {item.Summary}, {item.Body}");
            }
        }
    }
}