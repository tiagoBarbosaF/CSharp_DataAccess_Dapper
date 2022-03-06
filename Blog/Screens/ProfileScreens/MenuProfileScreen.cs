using System;

namespace Blog.Screens.ProfileScreens
{
    public static class MenuProfileScreen
    {
        public static void Load()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tGestão de Tags");
                Console.WriteLine("=================================================");
                Console.WriteLine("\n\t-- Menu Perfis --");
                Console.WriteLine("\t1 - Listar perfis");
                Console.WriteLine("\t2 - Cadastrar perfis");
                Console.WriteLine("\t3 - Atualizar perfis");
                Console.WriteLine("\t4 - Exluir perfis");
                Console.WriteLine("\t0 - Voltar ao menu principal\n\n");
                Console.Write("Selecione a função que deseja executar:\t");
                var option = short.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 0:
                        Menu.Load();
                        break;
                    case 1:
                        ListProfileScreen.Load();
                        break;
                    case 2:
                        CreateProfileScreen.Load();
                        break;
                    case 3:
                        UpdateProfileScreen.Load();
                        break;
                    case 4:
                        DeleteProfileScreen.Load();
                        break;
                    default:
                        continue;
                }
                break;
            }
        }
    }
}