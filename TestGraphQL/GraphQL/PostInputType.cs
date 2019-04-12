using GraphQL.Types;

namespace TestGraphQL.GraphQL
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
