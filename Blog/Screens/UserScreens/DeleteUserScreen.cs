using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tExcluir um usuário");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\n\tInsira o Id do usuário que deseja excluir: ");
            var id = Console.ReadLine();

            Delete(int.Parse(id!));

            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("\n\tUsuário excluído com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\tNão foi possível excluir o usuário.");
                Console.WriteLine(e.Message);
            }
        }
    }
}