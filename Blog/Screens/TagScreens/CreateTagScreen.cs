using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class CreateTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tCriar uma nova tag");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\tNome: ");
            var name = Console.ReadLine();
            Console.Write("\tSlug: ");
            var slug = Console.ReadLine();
            
            Create(new Tag
            {
                Name = name,
                Slug = slug
            });
            
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Create(tag);
                Console.WriteLine("\n\tTag cadastrada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível salvar a tag");
                Console.WriteLine(e.Message);
            }
        }
    }
}