using GraphQL.Types;

namespace Tiktack.WebGraphQL.Api.GraphQL.Types
{
    public class RoomInputType : InputObjectGraphType
    {
        public RoomInputType()
        {
            Name = "RoomInput";

            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<IntGraphType>>("number");
            Field<NonNullGraphType<BooleanGraphType>>("allowedSmoking");
        }
    }
}