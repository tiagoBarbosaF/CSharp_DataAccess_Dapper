using System;
using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=S4k0r400;TrustServerCertificate=True";
        
        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            Menu.Load();

            Console.ReadKey();
            Database.Connection.Close();
        }

        //TODO criar os itens de create, update e delete
        // public static void ReadUsersWithRoles(SqlConnection connection)
        // {
        //     var repository = new UserRepository(connection);
        //     var items = repository.GetWithRoles();
        //
        //     foreach (var item in items)
        //     {
        //         Console.WriteLine(item.Name);
        //         foreach (var role in item.Roles)
        //         {
        //             Console.WriteLine($" - {role.Name}");
        //         }
        //     }
        // }
        //
        // public static void ReadRoles(SqlConnection connection)
        // {
        //     var repository = new Repository<Role>(connection);
        //     var items = repository.GetAll();
        //
        //     foreach (var item in items) Console.WriteLine(item.Name);
        // }
        //
        // public static void ReadTags(SqlConnection connection)
        // {
        //     var repository = new Repository<Tag>(connection);
        //     var items = repository.GetAll();
        //
        //     foreach (var item in items) Console.WriteLine(item.Name);
        // }
    }
}
