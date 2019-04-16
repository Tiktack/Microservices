using GraphQL.Types;
using Tiktack.WebGraphQL.Api.GraphQL.Types;
using Tiktack.WebGraphQL.DataLayer.Entities;
using Tiktack.WebGraphQL.DataLayer.Infrastructure;

namespace Tiktack.WebGraphQL.Api.GraphQL
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation(ReservationRepository reservationRepository)
        {
            Name = "AddReservationMutation";

            Field<ReservationType>(
                "addReservation",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReservationInputType>> { Name = "reservation" }
                ),
                resolve: context =>
                {
                    var reservation = context.GetArgument<Reservation>("reservation");
                    return reservationRepository.Add(reservation);
                });
        }
    }
}
