using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tCriar uma nova categoria");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\tNome: ");
            var name = Console.ReadLine();
            Console.Write("\tSlug: ");
            var slug = Console.ReadLine();

            Create(new Category
            {
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void Create(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Create(category);
                Console.WriteLine("\n\tCategoria cadastrada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível salvar a categoria");
                Console.WriteLine(e.Message);
            }
        }
    }
}