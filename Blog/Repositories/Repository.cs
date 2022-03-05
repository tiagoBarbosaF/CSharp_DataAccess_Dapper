using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class
    {
        public Repository(SqlConnection connection)
        {
            
        }
        // private readonly SqlConnection _connection;
        //
        // public Repository(SqlConnection connection) => _connection = connection;

        public IEnumerable<T> GetAll() => Database.Connection.GetAll<T>();
        public T Get(int id) => Database.Connection.Get<T>(id);

        public void Create(T model) => Database.Connection.Insert(model);

        public void Update(T model) => Database.Connection.Update(model);

        public void Delete(T model) => Database.Connection.Delete(model);

        public void Delete(int id)
        {
            var model = Database.Connection.Get<T>(id);
            Database.Connection.Delete(model);
        }
    }
}