using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reactive.Subjects;
using Tiktack.Common.DataAccess.Repositories;
using Tiktack.Common.DataAccess.Repositories.Interfaces;
using Tiktack.WebGraphQL.Api.GraphQL;
using Tiktack.WebGraphQL.Api.GraphQL.Methods;
using Tiktack.WebGraphQL.BusinessLayer.Providers;
using Tiktack.WebGraphQL.DataLayer.Entities;
using Tiktack.WebGraphQL.DataLayer.Infrastructure;

namespace Tiktack.WebGraphQL.Api
{
    public class Bootstrapper : Common.Core.IoC.Bootstrapper
    {
        public override void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext, GraphQLDbContext>(options => options.UseSqlServer(configuration["ConnectionString"]));
            services.AddGraphQL(x => x.ExposeExceptions = true)
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddWebSockets()
                .AddDataLoader();

            services.AddHealthChecks();

            services.AddTransient<IRoomProvider, RoomProvider>();
            services.AddTransient<IGuestProvider, GuestProvider>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<RootQuery>();
            services.AddSingleton<RootMutation>();
            services.AddSingleton<RootSubscription>();
            services.AddSingleton<ISubject<EntityWithEvent>, Subject<EntityWithEvent>>();
            services.AddTransient<UnitOfWork>();
            services.AddTransient<IObservableRepository<Reservation, EntityWithEvent>, ObservableRepository<Reservation, EntityWithEvent>>();
            services.AddTransient<IObservableRepository<Guest, EntityWithEvent>, ObservableRepository<Guest, EntityWithEvent>>();
            services.AddTransient<IObservableRepository<Room, EntityWithEvent>, ObservableRepository<Room, EntityWithEvent>>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new GraphQLSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }
    }
}
