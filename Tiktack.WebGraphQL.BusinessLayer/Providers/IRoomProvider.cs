using System.Threading.Tasks;
using GraphQL.Types;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.BusinessLayer.Providers
{
    public interface IRoomProvider
    {
        Task<Room> AddRoom(ResolveFieldContext<object> context);
        Task<Room> UpdateRoom(ResolveFieldContext<object> context);
        Task<Room> RemoveRoom(ResolveFieldContext<object> context);
    }
}
