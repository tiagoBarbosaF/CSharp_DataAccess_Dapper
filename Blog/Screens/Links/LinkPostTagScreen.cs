using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;

namespace Blog.Screens.Links
{
    public static class LinkPostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("\t\tVinculo Post com Tag");
            Console.WriteLine("=================================================");
            Console.Write("\n\tInsira o Id da postagem: ");
            var postId = Console.ReadLine();
            var postRepository = new Repository<Post>(Database.Connection);
            var post = postRepository.Get(int.Parse(postId!));
            Console.WriteLine($"\n\tPostagem selecionada: {post.Title}, {post.Summary}");

            Console.WriteLine("\n\tTags:");
            ListTagsScreen.ListTags();
            Console.Write("\n\tInsira o Id da Tag: ");
            var tagId = Console.ReadLine();

            CreateLink(new PostTag
            {
                PostId = int.Parse(postId),
                TagId = int.Parse(tagId!)
            });

            Console.WriteLine("\n\tAperte ENTER para voltar ao Menu anterior.");
            Console.ReadKey();
            MenuLinkScreen.Load();
        }

        private static void CreateLink(PostTag postTag)
        {
            try
            {
                var repository = new Repository<PostTag>(Database.Connection);
                repository.Create(postTag);
                Console.WriteLine("\n\tVínculo criado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tNão foi possivel criar o vínculo da postagem com a tag.");
                Console.WriteLine(e.Message);
            }
        }
    }
}