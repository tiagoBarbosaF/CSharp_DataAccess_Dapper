using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tExcluir uma categoria");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\tInsira o Id da categoria que deseja excluir: ");
            var id = Console.ReadLine();

            Delete(int.Parse(id!));

            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("\n\tCategoria excluída com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível excluir a categoria");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}