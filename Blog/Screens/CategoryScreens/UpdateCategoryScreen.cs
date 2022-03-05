using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tAtualização da categoria");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\tId: ");
            var id = Console.ReadLine();
            Console.Write("\tNome: ");
            var name = Console.ReadLine();
            Console.Write("\tSlug: ");
            var slug = Console.ReadLine();

            Update(new Category
            {
                Id = int.Parse(id!),
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void Update(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Update(category);
                Console.WriteLine("\n\tCategoria atualizada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível atualizar a categoria.");
                Console.WriteLine(e.Message);
            }
        }
    }
}