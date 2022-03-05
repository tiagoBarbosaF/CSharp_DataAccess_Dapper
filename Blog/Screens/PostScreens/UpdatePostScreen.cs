using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;
using Blog.Screens.UserScreens;

namespace Blog.Screens.PostScreens
{
    public static class UpdatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tAtualização de postagem");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\n\tId: ");
            var id = Console.ReadLine();
            Console.Write("\tTitulo: ");
            var title = Console.ReadLine();
            Console.Write("\tSumário: ");
            var summary = Console.ReadLine();
            Console.Write("\tPostagem: ");
            var body = Console.ReadLine();
            Console.Write("\tSlug: ");
            var slug = Console.ReadLine();
            Console.WriteLine("\tCategorias");
            Console.Write("\tInsira o Id de uma das categorias abaixo: ");
            var categoryId = Console.ReadLine();
            ListCategoryScreen.ListCategories();
            Console.WriteLine("\tAutor");
            Console.Write("\tEInsira o Id de um(a) autor(ar) abaixo: ");
            var authorId = Console.ReadLine();
            ListUsersScreen.ListUsers();

            UpdatePost(new Post
            {
                Id = int.Parse(id!),
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                LastUpdateDate = DateTime.Now,
                CategoryId = int.Parse(categoryId!),
                AuthorId = int.Parse(authorId!)
            });
        }

        private static void UpdatePost(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Update(post);
                Console.WriteLine("\n\tPostagem atualizada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível atualizar a postagem.");
                Console.WriteLine(e.Message);
            }
        }
    }
}