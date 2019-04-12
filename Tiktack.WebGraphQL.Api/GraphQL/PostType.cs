using GraphQL.Types;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.Api.GraphQL
{
    public class PostType : ObjectGraphType<Post>
    {
        public PostType()
        {
            Field(x => x.Id);
            Field(x => x.Author);
            Field(x => x.Created);
            Field(x => x.Modified, true);
            Field(x => x.ModifiedBy);
            Field(x => x.Text);
            Field(x => x.Title);
        }
    }
}
