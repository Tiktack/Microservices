using GraphQL.Types;

namespace Tiktack.WebGraphQL.Api.GraphQL.Types
{
    public class GuestInputType : InputObjectGraphType
    {
        public GuestInputType()
        {
            Name = "GuestInput";
            Field<NonNullGraphType<StringGraphType>>("Name");
        }
    }
}
