using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestGraphQL.GraphQL;
using Tiktack.WebGraphQL.BusinessLayer;

namespace TestGraphQL
{
    public class Bootstrapper : Tiktack.Common.Core.IoC.Bootstrapper
    {
        public override void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPostProvider, PostsProvider>();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<PostMutation>();
            services.AddSingleton<BlogQuery>();
            services.AddSingleton<PostType>();
            var sp = services.BuildServiceProvider();

            services.AddSingleton<ISchema>(new PostSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }
    }
}
