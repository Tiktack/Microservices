using GraphQL.Types;
using Tiktack.WebGraphQL.BusinessLayer;

namespace Tiktack.WebGraphQL.Api.GraphQL
{
    public class BlogQuery : ObjectGraphType
    {
        public BlogQuery(IPostProvider postProvider)
        {
            Field<PostType>(
                "post",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return postProvider.GetById(id);
                });

            Field<ListGraphType<PostType>>(
                "posts",
                resolve: context =>
                    postProvider.GetAll()

            );
        }
    }
}
