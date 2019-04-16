using System.Collections.Generic;
using GraphQL.Resolvers;
using GraphQL.Types;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.Api.GraphQL
{
    public sealed class RootSubscription : ObjectGraphType<object>
    {
        public RootSubscription()
        {
            Name = "Subscription";
            Description = "The subscription type, represents all updates can be pushed to the client in real time over web sockets.";

            //AddField(new EventStreamFieldType
            //{
            //    Name = "reservationCreated",
            //    Type = typeof(HumanCreatedEvent),
            //    Resolver = new FuncFieldResolver<Reservation>(context => context.Source as Reservation),
            //    Subscriber = new EventStreamResolver<Reservation>(context =>
            //    {
            //        var homePlanets = context.GetArgument<List<string>>("homePlanets");
            //        return humanRepository
            //            .WhenHumanCreated
            //            .Where(x => homePlanets == null || homePlanets.Contains(x.HomePlanet));
            //    }),
            //});
        }
    }
}
