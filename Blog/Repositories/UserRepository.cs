using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public List<User> GetWithRoles()
        {
            var query = @"select U.*,
                                 R.*
                          from [User] U
                          left join [UserRole] UR on UR.UserId = U.Id
                          left join [Role] R on R.Id = UR.RoleId";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null) usr.Roles.Add(role);
                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");
            return users;
        }
    }
}