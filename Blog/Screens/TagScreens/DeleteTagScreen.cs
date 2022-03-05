using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class DeleteTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tExcluir uma tag");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\tInsira o Id da Tag que deseja excluir: ");
            var id = Console.ReadLine();
            
            Delete(int.Parse(id!));
            
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        
        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("\n\tTag excluída com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível deletar a tag");
                Console.WriteLine(e.Message);
            }
        }
    }
}