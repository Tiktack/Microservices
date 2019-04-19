using System.Reactive.Linq;
using GraphQL.Resolvers;
using GraphQL.Types;
using Tiktack.Common.DataAccess;
using Tiktack.Common.DataAccess.Repositories;
using Tiktack.WebGraphQL.Api.GraphQL.Types;
using Tiktack.WebGraphQL.DataLayer.Entities;
using Tiktack.WebGraphQL.DataLayer.Infrastructure;

namespace Tiktack.WebGraphQL.Api.GraphQL.Methods
{
    public sealed class RootSubscription : ObjectGraphType<object>
    {
        public RootSubscription(UnitOfWork unitOfWork)
        {
            Name = "Subscription";
            Description = "The subscription type, represents all updates can be pushed to the client in real time over web sockets.";

            AddField(new EventStreamFieldType
            {
                Name = "reservationCreated",
                Type = typeof(ReservationType),
                Resolver = new FuncFieldResolver<Reservation>(context => (Reservation)((EntityWithEvent)context.Source).Entity),
                Subscriber = new EventStreamResolver<EntityWithEvent>(context => unitOfWork.ReservationRepository
                    .ObservableSubject()
                    .Where(x => x.EventType == RepositoryEventType.AddEvent)
                )
            });

            AddField(new EventStreamFieldType
            {
                Name = "reservationUpdated",
                Type = typeof(ReservationType),
                Resolver = new FuncFieldResolver<Reservation>(context => (Reservation)((EntityWithEvent)context.Source).Entity),
                Subscriber = new EventStreamResolver<EntityWithEvent>(context => unitOfWork.ReservationRepository
                    .ObservableSubject()
                    .Where(x => x.EventType == RepositoryEventType.UpdateEvent)
                )
            });

            AddField(new EventStreamFieldType
            {
                Name = "reservationRemoved",
                Type = typeof(ReservationType),
                Resolver = new FuncFieldResolver<Reservation>(context => (Reservation)((EntityWithEvent)context.Source).Entity),
                Subscriber = new EventStreamResolver<EntityWithEvent>(context => unitOfWork.ReservationRepository
                    .ObservableSubject()
                    .Where(x => x.EventType == RepositoryEventType.RemoveEvent)
                )
            });
        }
    }
}
