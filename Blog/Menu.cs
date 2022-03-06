using System;
using Blog.Screens.CategoryScreens;
using Blog.Screens.Links;
using Blog.Screens.PostScreens;
using Blog.Screens.ProfileScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;

namespace Blog
{
    public static class Menu
    {
        public static void Load()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tBlog");
                Console.WriteLine("=================================================");
                Console.WriteLine("\n\t-- Menu --");
                Console.WriteLine("\n\t1 - Gestão de usuário");
                Console.WriteLine("\t2 - Gestão de perfil");
                Console.WriteLine("\t3 - Gestão de categoria");
                Console.WriteLine("\t4 - Gestão de tag");
                Console.WriteLine("\t5 - Gestão de postagens");
                Console.WriteLine("\t6 - Vinculos");
                Console.WriteLine("\t7 - Relatórios\n\n");
                Console.Write("Selecione a função que deseja executar:\t");
                var option = short.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 1:
                        MenuUserScreen.Load();
                        break;
                    case 2:
                        MenuProfileScreen.Load();
                        break;
                    case 3:
                        MenuCategoryScreen.Load();
                        break;
                    case 4:
                        MenuTagScreen.Load();
                        break;
                    case 5:
                        MenuPostScreen.Load();
                        break;
                    case 6:
                        MenuLinkScreen.Load();
                        break;
                    default:
                        continue;
                }

                break;
            }
        }
    }
}