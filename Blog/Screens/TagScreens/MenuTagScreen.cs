using System;

namespace Blog.Screens.TagScreens
{
    public static class MenuTagScreen
    {
        public static void Load()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tGestão de Tags");
                Console.WriteLine("=================================================");
                Console.WriteLine("\n\t-- Menu Tags --");
                Console.WriteLine("\t1 - Listar tags");
                Console.WriteLine("\t2 - Cadastrar tags");
                Console.WriteLine("\t3 - Atualizar tags");
                Console.WriteLine("\t4 - Exluir tags");
                Console.WriteLine("\t0 - Voltar ao menu principal\n\n");
                Console.Write("Selecione a função que deseja executar:\t");
                var option = short.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 0:
                        Menu.Load();
                        break;
                    case 1:
                        ListTagsScreen.Load();
                        break;
                    case 2:
                        CreateTagsScreen.Load();
                        break;
                    case 3:
                        UpdateTagsScreen.Load();
                        break;
                    case 4:
                        DeleteTagsScreen.Load();
                        break;
                    default:
                        continue;
                }

                break;
            }
        }
    }
}