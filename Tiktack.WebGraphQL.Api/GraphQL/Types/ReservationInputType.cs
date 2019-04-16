using GraphQL.Types;

namespace Tiktack.WebGraphQL.Api.GraphQL.Types
{
    public class ReservationInputType : InputObjectGraphType
    {
        public ReservationInputType()
        {
            Name = "ReservationInput";
            Field<NonNullGraphType<DateTimeGraphType>>("CheckinDate");
            Field<DateTimeGraphType>("CheckoutDate");
        }
    }
}