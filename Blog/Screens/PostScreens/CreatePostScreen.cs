using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;
using Blog.Screens.UserScreens;

namespace Blog.Screens.PostScreens
{
    public static class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\tCriar uma nova postagem");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\n\tTitulo: ");
            var title = Console.ReadLine();
            Console.Write("\tSumário: ");
            var summary = Console.ReadLine();
            Console.Write("\tPostagem: ");
            var body = Console.ReadLine();
            Console.Write("\tSlug: ");
            var slug = Console.ReadLine();
            Console.WriteLine("\tCategorias\n");
            ListCategoryScreen.ListCategories();
            Console.Write("\n\tInsira o Id de uma das categorias abaixo: ");
            var categoryId = Console.ReadLine();
            Console.WriteLine("\n\tAutor\n");
            ListUsersScreen.ListUsers();
            Console.Write("\n\tInsira o Id de um(a) autor(ar) abaixo: ");
            var authorId = Console.ReadLine();

            CreatePost(new Post
            {
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                CategoryId = int.Parse(categoryId!),
                AuthorId = int.Parse(authorId!)
            });

            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void CreatePost(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Create(post);
                Console.WriteLine("\n\tPostagem criada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possível cadastrar a postagem.");
                Console.WriteLine(e.Message);
            }
        }
    }
}