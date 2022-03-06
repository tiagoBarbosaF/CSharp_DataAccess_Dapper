using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ProfileScreens
{
    public static class ListProfileScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tLista de perfis");
            Console.WriteLine("-----------------------------------------");

            ListProfiles();

            Console.ReadKey();
            MenuProfileScreen.Load();
        }

        public static void ListProfiles()
        {
            var repository = new Repository<Role>(Database.Connection);
            var profiles = repository.GetAll();

            foreach (var item in profiles)
            {
                Console.WriteLine($"\t\t{item.Id} - {item.Name} ({item.Slug})");
            }
        }
    }
}