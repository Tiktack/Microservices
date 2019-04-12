using GraphQL.Types;
using Tiktack.WebGraphQL.BusinessLayer;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.Api.GraphQL
{
    public class PostMutation : ObjectGraphType
    {
        public PostMutation(IPostProvider postProvider)
        {
            Name = "CreatePostMutation";
            Field<PostType>(
                "createPost",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PostInputType>> { Name = "post" }),
                resolve: context => postProvider.AddPost(context.GetArgument<Post>("post")));
        }
    }
}
