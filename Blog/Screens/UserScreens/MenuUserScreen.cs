using System;

namespace Blog.Screens.UserScreens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\tGestão de Usuários");
                Console.WriteLine("=================================================");
                Console.WriteLine("\n\t-- Menu Usuários --");
                Console.WriteLine("\n\t1 - Listar Usuários");
                Console.WriteLine("\t2 - Cadastrar Usuário");
                Console.WriteLine("\t3 - Atualizar Usuário");
                Console.WriteLine("\t4 - Excluir Usuário");
                Console.WriteLine("\t0 - Voltar ao menu principal\n\n");
                Console.Write("Selecione a função que deseja executar: ");
                var option = short.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 0:
                        Menu.Load();
                        break;
                    case 1:
                        ListUsersScreen.Load();
                        break;
                    case 2:
                        CreateUserScreen.Load();
                        break;
                    case 3:
                        UpdateUserScreen.Load();
                        break;
                    case 4:
                        DeleteUserScreen.Load();
                        break;
                    default:
                        continue;
                }
                
                break;
            }
        }
    }
}