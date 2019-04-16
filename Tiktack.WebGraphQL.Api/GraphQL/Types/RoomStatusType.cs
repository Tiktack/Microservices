using GraphQL.Types;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.Api.GraphQL.Types
{
    public class RoomStatusType : EnumerationGraphType<RoomStatus>
    {
        public RoomStatusType()
        {
            Description = "Shows if the room is available or not.";
        }
    }
}
