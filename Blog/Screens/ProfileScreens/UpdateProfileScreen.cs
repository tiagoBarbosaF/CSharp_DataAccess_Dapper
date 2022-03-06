using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ProfileScreens
{
    public static class UpdateProfileScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tAtualização de perfil");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\n\tId: ");
            var id = Console.ReadLine();
            Console.Write("\tNome: ");
            var name = Console.ReadLine();
            Console.Write("\tSlug: ");
            var slug = Console.ReadLine();

            UpdateProfile(new Role
            {
                Id = int.Parse(id!),
                Name = name,
                Slug = slug
            });

            Console.WriteLine("\n\tAperte ENTER para voltar ao menu de Perfis.");
            MenuProfileScreen.Load();
        }

        private static void UpdateProfile(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Update(role);
                Console.WriteLine("\n\tPerfil atualizado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível atualizar o perfil.");
                Console.WriteLine(e.Message);
            }
        }
    }
}