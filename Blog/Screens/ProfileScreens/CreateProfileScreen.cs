using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ProfileScreens
{
    public static class CreateProfileScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tCriar um novo perfil");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\n\tNome: ");
            var name = Console.ReadLine();
            Console.Write("\tSlug: ");
            var slug = Console.ReadLine();

            CreateProfile(new Role
            {
                Name = name,
                Slug = slug
            });

            Console.WriteLine("\n\n\tAperte ENTER para voltar ao menu de perfis");
            Console.ReadKey();
            MenuProfileScreen.Load();
        }

        private static void CreateProfile(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Create(role);
                Console.WriteLine("\n\tPerfil criado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível criar o perfil.");
                Console.WriteLine(e.Message);
            }
        }
    }
}