using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tCriar um novo usuário");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\n\tNome: ");
            var name = Console.ReadLine();
            Console.Write("\tEmail: ");
            var email = Console.ReadLine();
            Console.Write("\tPassword: ");
            var password = Console.ReadLine();
            Console.Write("\tBio: ");
            var bio = Console.ReadLine();
            Console.Write("\tImagem: ");
            var image = Console.ReadLine();
            Console.Write("\tSlug: ");
            var slug = Console.ReadLine();

            Create(new User
            {
                Name = name,
                Email = email,
                PasswordHash = password,
                Bio = bio,
                Image = image,
                Slug = slug
            });

            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(user);
                Console.WriteLine("\n\tUsuário cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível salvar o usuário.");
                Console.WriteLine(e.Message);
            }
        }
    }
}