using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;

namespace PortalDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString =
                "Server=localhost,1433;Database=tiagoPortal;User ID=sa;Password=S4k0r400;TrustServerCertificate=True";


            using (var connection = new SqlConnection(connectionString))
            {
                // CreateCategory(connection);
                // CreateManyCategories(connection);
                // UpdateCategory(connection);
                // ListCategories(connection);
                // GetCategory(connection);
                // CreateCategory(connection);
                // ExecuteProcedure(connection);
                // ExecuteReadProcedure(connection);
                // ExecuteScalar(connection);
                // ReadView(connection);
                // OneToOne(connection);
                // OneToMany(connection);
                // QueryMutiple(connection);
                // SelectIn(connection);
                // Like(connection, "api");
                Transaction(connection);
            }
        }

        private static void CreateCategory(SqlConnection connection)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Title = "Amazon AWS",
                Url = "amazon",
                Description = "Categoria destinada a serviços do AWS",
                Order = 8,
                Summary = "AWS Cloud",
                Featured = false
            };

            var insertSql =
                "INSERT INTO [Category] VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"{rows} linha(s) inserida(s)");
        }

        private static void CreateManyCategories(SqlConnection connection)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Title = "Amazon AWS",
                Url = "amazon",
                Description = "Categoria destinada a serviços do AWS",
                Order = 8,
                Summary = "AWS Cloud",
                Featured = false
            };
            var category2 = new Category
            {
                Id = Guid.NewGuid(),
                Title = "Categoria nova",
                Url = "categoria-nova",
                Description = "Categoria nova",
                Order = 9,
                Summary = "Categoria",
                Featured = true
            };

            var insertSql =
                "INSERT INTO [Category] VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

            var rows = connection.Execute(insertSql, new[]
            {
                new {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                },
                new {
                    category2.Id,
                    category2.Title,
                    category2.Url,
                    category2.Summary,
                    category2.Order,
                    category2.Description,
                    category2.Featured
                }
            });

            Console.WriteLine($"{rows} linha(s) inserida(s)");
        }

        private static void ListCategories(SqlConnection connection)
        {
            var categories =
                connection.Query<Category>(
                    sql: "SELECT \n    [Id], \n    [Title] \nFROM \n    [Category] ORDER BY [Order]");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        private static void GetCategory(SqlConnection connection)
        {
            var category = connection.QueryFirstOrDefault<Category>("SELECT TOP 1 [Id], [Title] FROM [Category] WHERE [Id] = @id", new
            {
                id = "AF3407AA-11AE-4621-A2EF-2028B85507C4"
            });

            Console.WriteLine($"{category.Id} - {category.Title}");
        }

        private static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";

            var rows = connection.Execute(updateQuery, new
            {
                id = new Guid("AF3407AA-11AE-4621-A2EF-2028B85507C4"),
                title = "Frontend 2022"
            });

            Console.WriteLine($"{rows} linha(s) atualizada(s)");
        }

        private static void ExecuteProcedure(SqlConnection connection)
        {
            var procedure = "[spDeleteStudent]";
            var pars = new
            {
                StudentId = "73A4223A-A3F4-42F5-AB27-EC153F2DF484"
            };
            var affectedRows = connection.Execute(procedure, pars, commandType: CommandType.StoredProcedure);

            Console.WriteLine($"{affectedRows} linha(s) afetada(s)");
        }
        
        private static void ExecuteReadProcedure(SqlConnection connection)
        {
            var procedure = "[spGetCoursesByCategory]";
            var pars = new
            {
                CategoryId = "09CE0B7B-CFCA-497B-92C0-3290AD9D5142"
            };
            var courses = connection.Query<Category>(procedure, pars, commandType: CommandType.StoredProcedure);

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        private static void ExecuteScalar(SqlConnection connection)
        {
            var category = new Category
            {
                Title = "AWS",
                Url = "amazon",
                Description = "Categoria destinada a serviços do AWS",
                Order = 8,
                Summary = "AWS Cloud",
                Featured = false
            };

            var insertSql =
                "INSERT INTO [Category] OUTPUT inserted.[Id] VALUES (NEWID(), @Title, @Url, @Summary, @Order, @Description, @Featured)";

            var id = connection.ExecuteScalar<Guid>(insertSql, new
            {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"A categoria inserida foi: {id}");
        }

        static void ReadView(SqlConnection connection)
        {
            var sql = "SELECT * FROM [vwCourses]";
            var courses = connection.Query(sql);

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void OneToOne(SqlConnection connection)
        {
            var sql = "SELECT * FROM CareerItem INNER JOIN Course  on CareerItem.CourseId = Course.Id";

            var items = connection.Query<CareerItem, Course, CareerItem>(
                sql,
                (careerItem, course) =>
                {
                    careerItem.Course = course;
                    return careerItem;
                }, splitOn: "Id");

            foreach (var item in items)
            {
                Console.WriteLine($"CareerItem: {item.Title} - Course: {item.Course.Title}");
            }
        }
        
        static void OneToMany(SqlConnection connection)
        {
            var sql = "SELECT Career.Id, Career.Title, CareerItem.CareerId, CareerItem.Title FROM Career INNER JOIN CareerItem on CareerItem.CareerId = Career.Id ORDER BY Career.Title";

            var careers = new List<Career>();
            var items = connection.Query<Career, CareerItem, Career>(
                sql,
                (career, careerItem) =>
                {
                    var car = careers.FirstOrDefault(x => x.Id == career.Id);
                    if (car == null)
                    {
                        car = career;
                        car.CareerItems.Add(careerItem);
                        careers.Add(car);
                    }
                    else
                    {
                        car.CareerItems.Add(careerItem);
                    }
                    return career;
            }, splitOn: "CareerId");

            foreach (var career in careers)
            {
                Console.WriteLine($"CareerItem: {career.Title}");
                foreach (var item in career.CareerItems)
                {
                    Console.WriteLine($" - {item.Title}");
                }
            }
        }

        static void QueryMutiple(SqlConnection connection)
        {
            var sql = "SELECT * FROM Category; SELECT * FROM Course;";

            using (var multi = connection.QueryMultiple(sql))
            {
                var categories = multi.Read<Category>();
                var courses = multi.Read<Course>();
                Console.WriteLine("\nCategorias:");
                foreach (var item in categories)
                {
                    Console.WriteLine($" - {item.Title}");
                }

                Console.WriteLine("\nCursos:");
                foreach (var item in courses)
                {
                    Console.WriteLine($" - {item.Title}");
                }
            }
        }

        static void SelectIn(SqlConnection connection)
        {
            var query = "SELECT * FROM Career WHERE Id IN @Id";

            var items = connection.Query<Career>(query, new
            {
                Id = new[]
                {
                    "4327AC7E-963B-4893-9F31-9A3B28A4E72B",
                    "01AE8A85-B4E8-4194-A0F1-1C6190AF54CB"
                }
            });

            foreach (var item in items)
            {
                Console.WriteLine(item.Title);
            }
        }
        
        static void Like(SqlConnection connection, string term)
        {
            var query = "SELECT * FROM Course WHERE Title LIKE @exp";

            var items = connection.Query<Course>(query, new
            {
                exp = $"%{term}%"
            });

            foreach (var item in items)
            {
                Console.WriteLine(item.Title);
            }
        }
        
        private static void Transaction(SqlConnection connection)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Title = "Teste",
                Url = "amazon",
                Description = "Categoria destinada a serviços do AWS",
                Order = 10,
                Summary = "AWS Cloud",
                Featured = false
            };

            var insertSql =
                "INSERT INTO [Category] VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";
            
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
                var rows = connection.Execute(insertSql, new
                {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                },transaction);
                
                // transaction.Rollback();
                transaction.Commit();

                Console.WriteLine($"{rows} linha(s) inserida(s)");
            }
        }
    }
}