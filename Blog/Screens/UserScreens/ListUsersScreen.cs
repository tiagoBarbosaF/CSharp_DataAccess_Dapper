using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class ListUsersScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tUsuários cadastrados");
            Console.WriteLine("-----------------------------------------");

            ListUsers();

            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void ListUsers()
        {
            var repository = new Repository<User>(Database.Connection);
            var users = repository.GetAll();

            foreach (var item in users)
            {
                Console.WriteLine($"\tUsuário: {item.Name}, {item.Email}");
            }
        }
    }
}