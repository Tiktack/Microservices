using GraphQL;
using GraphQL.Types;

namespace TestGraphQL.GraphQL
{
    public class PostSchema : Schema
    {
        public PostSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<BlogQuery>();
            //Mutation = dependencyResolver.Resolve<PostMutation>();
        }
    }
}
