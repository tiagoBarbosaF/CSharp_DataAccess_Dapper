using System;

namespace Blog.Screens.PostScreens
{
    public class MenuPostScreen
    {
        public static void Load()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tGestão de Posts");
                Console.WriteLine("=================================================");
                Console.WriteLine("\n\t-- Menu Posts --");
                Console.WriteLine("\t1 - Listar posts");
                Console.WriteLine("\t2 - Cadastrar posts");
                Console.WriteLine("\t3 - Atualizar posts");
                Console.WriteLine("\t4 - Exluir posts");
                Console.WriteLine("\t0 - Voltar ao menu principal\n\n");
                Console.Write("Selecione a função que deseja executar:\t");
                var option = short.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 0:
                        Menu.Load();
                        break;
                    case 1:
                        ListPostScreen.Load();
                        break;
                    case 2:
                        CreatePostScreen.Load();
                        break;
                    case 3:
                        UpdatePostScreen.Load();
                        break;
                    case 4:
                        DeletePostScreen.Load();
                        break;
                    default:
                        continue;
                }
                break;
            }
        }
    }
}