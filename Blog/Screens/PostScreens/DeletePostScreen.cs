using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class DeletePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tExcluir uma postagem");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\n\tInsira o Id da postagem que deseja excluir: ");
            var id = Console.ReadLine();

            DeletePost(int.Parse(id!));

            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void DeletePost(int id)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("\n\tPostagem excluída com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível excluir a postagem.");
                Console.WriteLine(e.Message);
            }
        }
    }
}