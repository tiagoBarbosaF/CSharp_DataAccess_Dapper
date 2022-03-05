using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[PostTag]")]
    public class PostTag
    {
        public Post PostId { get; set; }
        public Tag TagId { get; set; }
    }
}