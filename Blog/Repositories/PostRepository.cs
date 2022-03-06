using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;
        public PostRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public List<Post> GetPostWithTag()
        {
            var query = @"select
                                P.*,
                                T.*
                          from Post P
                          left join PostTag PT on PT.PostId = P.Id
                          left join Tag T on T.Id = PT.TagId";

            var posts = new List<Post>();

            var items = _connection.Query<Post, Tag, Post>(
                query,
                (post, tag) =>
                {
                    var pos = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (pos == null)
                    {
                        pos = post;
                        if (tag != null) pos.Tags.Add(tag);
                        posts.Add(pos);
                    }
                    else
                        pos.Tags.Add(tag);

                    return post;
                }, splitOn: "Id");
            return posts;
        }
    }
}