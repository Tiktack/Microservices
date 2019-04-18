using GraphQL.Types;
using Tiktack.WebGraphQL.Api.GraphQL.Types;
using Tiktack.WebGraphQL.DataLayer.Entities;
using Tiktack.WebGraphQL.DataLayer.Infrastructure;

namespace Tiktack.WebGraphQL.Api.GraphQL.Methods
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation(UnitOfWork unitOfWork)
        {
            Field<ReservationType>(
                "addReservation",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReservationInputType>> { Name = "reservation" }
                ),
                resolve: context =>
                {
                    var reservation = context.GetArgument<Reservation>("reservation");
                    return unitOfWork.ReservationRepository.Add(reservation);
                });

            Field<ReservationType>(
                "RemoveReservation",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "reservationId" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("reservationId");
                    return unitOfWork.ReservationRepository.Remove(id);
                });

            Field<ReservationType>(
                "UpdateReservation",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReservationInputType>> { Name = "reservation" }
                ),
                resolve: context =>
                {
                    var reservation = context.GetArgument<Reservation>("reservation");
                    return unitOfWork.ReservationRepository.Update(reservation);
                });
        }
    }
}
