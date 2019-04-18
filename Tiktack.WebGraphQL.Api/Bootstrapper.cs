using System.Reactive.Subjects;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tiktack.Common.DataAccess;
using Tiktack.WebGraphQL.Api.GraphQL;
using Tiktack.WebGraphQL.Api.GraphQL.Methods;
using Tiktack.WebGraphQL.BusinessLayer;
using Tiktack.WebGraphQL.DataLayer.Entities;
using Tiktack.WebGraphQL.DataLayer.Infrastructure;

namespace Tiktack.WebGraphQL.Api
{
    public class Bootstrapper : Common.Core.IoC.Bootstrapper
    {
        public override void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPostProvider, PostsProvider>();
            services.AddTransient<IReservationProvider, ReservationProvider>();
            services.AddSingleton<ReservationRepository>();
            services.AddDbContext<DbContext, GraphQLDbContext>(options => options.UseSqlServer(configuration["ConnectionString"]));
            services.AddDbContext<GraphQLDbContext>(options => options.UseSqlServer(configuration["ConnectionString"]));

            services.AddGraphQL(x => x.ExposeExceptions = true)
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddWebSockets()
                .AddDataLoader();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<RootQuery>();
            services.AddSingleton<RootMutation>();
            services.AddSingleton<RootSubscription>();
            services.AddSingleton<ISubject<ReservationWithEvent>, Subject<ReservationWithEvent>>();
            services.AddTransient<UnitOfWork>();
            services.AddTransient<IObservableRepository<Reservation, ReservationWithEvent>, ObservableRepository<Reservation, ReservationWithEvent>>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new GraphQLSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }
    }
}
