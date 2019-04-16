using GraphQL;
using GraphQL.Types;

namespace Tiktack.WebGraphQL.Api.GraphQL
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<RootQuery>();
            Mutation = dependencyResolver.Resolve<RootMutation>();
        }
    }
}
