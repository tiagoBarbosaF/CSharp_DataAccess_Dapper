using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class ListUsersRolesScreen
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
            var repository = new UserRepository(Database.Connection);
            var users = repository.GetWithRoles();

            foreach (var item in users)
            {
                Console.WriteLine($"\n\tUsuário: {item.Id} - {item.Name}, {item.Email}\n");
                Console.WriteLine("\tPerfis do usuário:");
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($"\t\t{role.Id} - {role.Name}, ({role.Slug})");
                }

                Console.WriteLine("\n---------------------------------------------------------------");
            }
        }
    }
}