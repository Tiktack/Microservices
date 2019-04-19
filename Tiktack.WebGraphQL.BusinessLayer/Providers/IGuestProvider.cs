using System.Threading.Tasks;
using GraphQL.Types;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.BusinessLayer.Providers
{
    public interface IGuestProvider
    {
        Task<Guest> AddGuest(ResolveFieldContext<object> context);
        Task<Guest> UpdateGuest(ResolveFieldContext<object> context);
        Task<Guest> RemoveGuest(ResolveFieldContext<object> context);
    }
}
