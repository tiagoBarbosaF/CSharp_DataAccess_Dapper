using System;

namespace Blog.Screens.CategoryScreens
{
    public static class MenuCategoryScreen
    {
        public static void Load()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tGestão de categorias");
                Console.WriteLine("=================================================");
                Console.WriteLine("\n\t-- Menu Categorias --");
                Console.WriteLine("\n\t1 - Listar as categorias");
                Console.WriteLine("\t2 - Cadastrar uma categoria");
                Console.WriteLine("\t3 - Atualizar uma categoria");
                Console.WriteLine("\t4 - Excluir uma categoria");
                Console.WriteLine("\t0 - Voltar ao menu principal\n\n");
                Console.Write("Selecione a função que deseja executar:\t");
                var option = short.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 0:
                        Menu.Load();
                        break;
                    case 1:
                        ListCategoryScreen.Load();
                        break;
                    case 2:
                        CreateCategoryScreen.Load();
                        break;
                    case 3:
                        UpdateCategoryScreen.Load();
                        break;
                    case 4:
                        DeleteCategoryScreen.Load();
                        break;
                    default:
                        continue;
                }
                break;
            }
        }
    }
}