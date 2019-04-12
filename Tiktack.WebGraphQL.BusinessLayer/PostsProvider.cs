using System;
using System.Collections.Generic;
using System.Linq;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.BusinessLayer
{
    public class PostsProvider: IPostProvider
    {
        private IList<Post> _posts = new List<Post>();
        public PostsProvider()
        {
            _posts.Add(new Post
            {
                Author = "Aleh",
                Created = DateTime.Now,
                Id = 1,
                Text = "First post",
                Title = "NEW",
                Modified = DateTime.Now,
                ModifiedBy = "BY ME"
            });
            _posts.Add(new Post
            {
                Author = "Siarhei",
                Created = DateTime.Now,
                Id = 2,
                Text = "Second post",
                Title = "NOT NEW ",
                Modified = DateTime.Now,
                ModifiedBy = "BY ME"
            });
        }

        public IEnumerable<Post> GetAll()
        {
            return _posts;
        }

        public Post GetById(int id)
        {
            return _posts.First(x => x.Id == id);
        }

        public Post AddPost(Post getArgument)
        {
             _posts.Add(getArgument);
             return getArgument;
        }
    }
}
