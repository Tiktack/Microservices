using GraphQL.Types;
using Tiktack.WebGraphQL.Api.GraphQL.Types;
using Tiktack.WebGraphQL.BusinessLayer.Providers;
using Tiktack.WebGraphQL.DataLayer.Entities;
using Tiktack.WebGraphQL.DataLayer.Infrastructure;

namespace Tiktack.WebGraphQL.Api.GraphQL.Methods
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation(UnitOfWork unitOfWork,
            IGuestProvider guestProvider,
            IRoomProvider roomProvider)
        {
            Name = "Mutation";

            #region Reservations
            Field<ReservationType>(
                "addReservation",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReservationInputType>>
                    {
                        Name = "reservation"
                    }
                ),
                resolve: context =>
                {
                    var reservation = context.GetArgument<Reservation>("reservation");
                    return unitOfWork.ReservationRepository.Add(reservation);
                });

            Field<ReservationType>(
                "RemoveReservation",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "reservationId"
                    }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("reservationId");
                    return unitOfWork.ReservationRepository.Remove(id);
                });

            Field<ReservationType>(
                "UpdateReservation",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReservationInputType>>
                    {
                        Name = "reservation"
                    }
                ),
                resolve: context =>
                {
                    var reservation = context.GetArgument<Reservation>("reservation");
                    return unitOfWork.ReservationRepository.Update(reservation);
                });
            #endregion

            #region Guests

            Field<GuestType>(
                "addGuest",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<GuestInputType>>
                    {
                        Name = "guest"
                    }
                ),
                resolve: guestProvider.AddGuest
            );

            Field<GuestType>(
                "UpdateGuest",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "id"
                    },
                    new QueryArgument<NonNullGraphType<GuestInputType>>
                    {
                        Name = "guest"
                    }
                ),
                resolve: guestProvider.UpdateGuest
            );

            Field<GuestType>(
                "RemoveGuest",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "id"
                    }
                ),
                resolve: guestProvider.RemoveGuest
            );
            #endregion

            #region Rooms

            Field<RoomType>(
                "addRoom",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<RoomInputType>>
                    {
                        Name = "room"
                    }
                ),
                resolve: roomProvider.AddRoom
            );

            Field<RoomType>(
                "UpdateRoom",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "id"
                    },
                    new QueryArgument<NonNullGraphType<RoomInputType>>
                    {
                        Name = "room"
                    }
                ),
                resolve: roomProvider.UpdateRoom
            );

            Field<RoomType>(
                "RemoveRoom",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "id"
                    }
                ),
                resolve: roomProvider.RemoveRoom
            );
            #endregion

        }
    }
}