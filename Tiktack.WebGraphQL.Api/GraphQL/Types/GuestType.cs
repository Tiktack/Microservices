using GraphQL.Types;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.Api.GraphQL.Types
{
    public class GuestType : ObjectGraphType<Guest>
    {
        public GuestType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.RegisterDate);
        }
    }
}
