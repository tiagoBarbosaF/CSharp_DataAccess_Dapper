using System;

namespace Blog.Screens.Links
{
    public class MenuLinkScreen
    {
        public static void Load()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tVinculos");
                Console.WriteLine("=================================================");
                Console.WriteLine("\n\t-- Menu de vinculos --");
                Console.WriteLine("\n\t1 - Vincular Usuário ao perfil");
                Console.WriteLine("\t2 - Vincular Postagem a Tag");
                Console.WriteLine("\t0 - Voltar ao menu principal\n\n");
                Console.Write("Selecione a função que deseja executar:\t");
                var option = short.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 0:
                        Menu.Load();
                        break;
                    case 1:
                        LinkUserProfileScreen.Load();
                        break;
                    case 2:
                        LinkPostTagScreen.Load();
                        break;
                    default:
                        continue;
                }

                break;
            }
        }
    }
}