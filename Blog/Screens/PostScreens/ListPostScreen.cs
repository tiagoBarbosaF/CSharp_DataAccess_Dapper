using System;
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
            var repository = new PostRepository(Database.Connection);
            var posts = repository.GetPostWithTag();

            foreach (var item in posts)
            {
                Console.WriteLine($"\n\t{item.Id} - {item.Title}, {item.Summary}, {item.Body}");
                Console.WriteLine("\n\tTags:");
                foreach (var tag in item.Tags)
                {
                    Console.WriteLine($"\t\t{tag.Id} - {tag.Name}, ({tag.Slug})");
                }

                Console.WriteLine("\n---------------------------------------------------------------");
            }
        }
    }
}