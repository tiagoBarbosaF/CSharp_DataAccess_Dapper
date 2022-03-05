using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tAtualização de usuário");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\n\tId: ");
            var id = Console.ReadLine();
            Console.Write("\tNome: ");
            var name = Console.ReadLine();
            Console.Write("\tEmail: ");
            var email = Console.ReadLine();
            Console.Write("\tPassword: ");
            var password = Console.ReadLine();
            Console.Write("\tBio: ");
            var bio = Console.ReadLine();
            Console.Write("\tSlug: ");
            var slug = Console.ReadLine();

            Update(new User
            {
                Id = int.Parse(id!),
                Name = name,
                Email = email,
                PasswordHash = password,
                Bio = bio,
                Slug = slug
            });

            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Update(user);
                Console.WriteLine("\tUsuário atualizado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\tNão foi possivel atualizar o usuário.");
                Console.WriteLine(e.Message);
            }
        }
    }
}