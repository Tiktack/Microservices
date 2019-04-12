using System.Collections.Generic;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.BusinessLayer
{
    public interface IPostProvider
    {
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        Post AddPost(Post getArgument);
    }
}