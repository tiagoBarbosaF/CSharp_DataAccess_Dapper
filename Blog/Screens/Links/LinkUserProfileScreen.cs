using System;
using System.Security.Cryptography.X509Certificates;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.ProfileScreens;

namespace Blog.Screens.Links
{
    public static class LinkUserProfileScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\t\tVinculo Usuário ao Perfil");
            Console.WriteLine("=================================================");
            Console.Write("\n\tInsira o Id do usuário: ");
            var userId = Console.ReadLine();
            var userRepository = new Repository<User>(Database.Connection);
            var user = userRepository.Get(int.Parse(userId!));
            Console.WriteLine($"\n\tUsuário selecionado: {user.Id} - {user.Name}");

            Console.WriteLine("\n\tPerfis:");
            ListProfileScreen.ListProfiles();
            Console.Write("\n\tInsira o Id do Perfil: ");
            var roleId = Console.ReadLine();

            CreateLink(new UserRole
            {
                UserId = int.Parse(userId),
                RoleId = int.Parse(roleId!)
            });

            Console.WriteLine("\n\tAperte ENTER para voltar ao menu principal.");
            Console.ReadKey();
            MenuLinkScreen.Load();
        }

        private static void CreateLink(UserRole userRole)
        {
            try
            {
                var repository = new Repository<UserRole>(Database.Connection);
                repository.Create(userRole);
                Console.WriteLine("\n\tVinculo criado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível criar o vinculo.");
                Console.WriteLine(e.Message);
            }
        }
    }
}