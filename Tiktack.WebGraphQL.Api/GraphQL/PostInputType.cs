using GraphQL.Types;

namespace Tiktack.WebGraphQL.Api.GraphQL
{
    public class PostInputType : InputObjectGraphType
    {
        public PostInputType()
        {
            Name = "PostInput";
            Field<NonNullGraphType<StringGraphType>>("title");
        }
    }
}
