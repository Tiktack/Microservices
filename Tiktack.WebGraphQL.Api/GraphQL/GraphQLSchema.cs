using GraphQL;
using GraphQL.Types;
using Tiktack.WebGraphQL.Api.GraphQL.Methods;

namespace Tiktack.WebGraphQL.Api.GraphQL
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<RootQuery>();
            Mutation = dependencyResolver.Resolve<RootMutation>();
            Subscription = dependencyResolver.Resolve<RootSubscription>();
        }
    }
}
