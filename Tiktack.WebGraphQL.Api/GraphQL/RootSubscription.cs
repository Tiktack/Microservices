using GraphQL.Resolvers;
using GraphQL.Types;
using Tiktack.WebGraphQL.Api.GraphQL.Types;
using Tiktack.WebGraphQL.DataLayer.Entities;
using Tiktack.WebGraphQL.DataLayer.Infrastructure;

namespace Tiktack.WebGraphQL.Api.GraphQL
{
    public sealed class RootSubscription : ObjectGraphType<object>
    {
        public RootSubscription(ReservationRepository reservationRepository)
        {
            Name = "Subscription";
            Description = "The subscription type, represents all updates can be pushed to the client in real time over web sockets.";

            AddField(new EventStreamFieldType
            {
                Name = "reservationCreated",
                Type = typeof(ReservationType),
                Resolver = new FuncFieldResolver<Reservation>(context => context.Source as Reservation),
                Subscriber = new EventStreamResolver<Reservation>(context => reservationRepository.ReservationCreated),
            });
        }
    }
}
