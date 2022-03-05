using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class UpdateTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tAtualização de tag");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\tId: ");
            var id = Console.ReadLine();
            Console.Write("\tNome: ");
            var name = Console.ReadLine();
            Console.Write("\tSlug: ");
            var slug = Console.ReadLine();
            
            Update(new Tag
            {
                Id = int.Parse(id!),
                Name = name,
                Slug = slug
            });
            
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        
        private static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);
                Console.WriteLine("\n\tTag atualizada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível atualizar a tag");
                Console.WriteLine(e.Message);
            }
        }
    }
}