using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using Tiktack.WebGraphQL.Api.GraphQL.Types;
using Tiktack.WebGraphQL.BusinessLayer;
using Tiktack.WebGraphQL.DataLayer.Entities;
using Tiktack.WebGraphQL.DataLayer.Infrastructure;

namespace Tiktack.WebGraphQL.Api.GraphQL
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(IPostProvider postProvider, IReservationProvider reservationProvider,ReservationRepository reservationRepository)
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
            Field<ListGraphType<ReservationType>>(
                "reservations",
                resolve: context => reservationProvider.GetReservations());

            /*Version: 2 filtering*/
            Field<ListGraphType<ReservationType>>("reservationsV2",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IdGraphType>
                    {
                        Name = "id"
                    },
                    new QueryArgument<DateGraphType>
                    {
                        Name = "checkinDate"
                    },
                    new QueryArgument<DateGraphType>
                    {
                        Name = "checkoutDate"
                    },
                    new QueryArgument<BooleanGraphType>
                    {
                        Name = "roomAllowedSmoking"
                    },
                    new QueryArgument<RoomStatusType>
                    {
                        Name = "roomStatus"
                    }
                }),
                resolve: context =>
                {
                    var query = reservationRepository.GetQuery();

                    var reservationId = context.GetArgument<int?>("id");
                    if (reservationId.HasValue)
                    {
                        if (reservationId.Value <= 0)
                        {
                            context.Errors.Add(new ExecutionError("reservationId must be greater than zero!"));
                            return new List<Reservation>();
                        }

                        return reservationRepository.GetQuery().Where(r => r.Id == reservationId.Value);
                    }

                    var checkinDate = context.GetArgument<DateTime?>("checkinDate");
                    if (checkinDate.HasValue)
                    {
                        return reservationRepository.GetQuery()
                            .Where(r => r.CheckinDate.Date == checkinDate.Value.Date);
                    }

                    var checkoutDate = context.GetArgument<DateTime?>("checkoutDate");
                    if (checkoutDate.HasValue)
                    {
                        return reservationRepository.GetQuery()
                            .Where(r => r.CheckoutDate.Date >= checkoutDate.Value.Date);
                    }

                    var allowedSmoking = context.GetArgument<bool?>("roomAllowedSmoking");
                    if (allowedSmoking.HasValue)
                    {
                        return reservationRepository.GetQuery()
                            .Where(r => r.Room.AllowedSmoking == allowedSmoking.Value);
                    }

                    var roomStatus = context.GetArgument<RoomStatus?>("roomStatus");
                    if (roomStatus.HasValue)
                    {
                        return reservationRepository.GetQuery().Where(r => r.Room.Status == roomStatus.Value);
                    }

                    return query.ToList();
                }
            );
        }
    }
}
