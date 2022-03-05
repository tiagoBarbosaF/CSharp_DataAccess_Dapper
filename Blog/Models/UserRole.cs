using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[UserRole]")]
    public class UserRole
    {
        public User UserId { get; set; }
        public Role RoleId { get; set; }
    }
}