using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ProfileScreens
{
    public static class DeleteProfileScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tExcluir um perfil");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\tInsira o Id do perfil que deseja excluir: ");
            var id = Console.ReadLine();

            DeleteProfile(int.Parse(id!));

            Console.WriteLine("\n\tAperte ENTER para voltar ao menu de Perfis.");
            MenuProfileScreen.Load();
        }

        private static void DeleteProfile(int id)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("\n\tPerfil excluído com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível excluir o perfil.");
                Console.WriteLine(e.Message);
            }
        }
    }
}