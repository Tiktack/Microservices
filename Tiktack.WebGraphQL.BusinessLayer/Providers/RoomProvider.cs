using System.Threading.Tasks;
using GraphQL.Types;
using Tiktack.WebGraphQL.DataLayer.Entities;
using Tiktack.WebGraphQL.DataLayer.Infrastructure;

namespace Tiktack.WebGraphQL.BusinessLayer.Providers
{
    public class RoomProvider : IRoomProvider
    {
        private readonly UnitOfWork _unitOfWork;

        public RoomProvider(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Room> AddRoom(ResolveFieldContext<object> context)
        {
            var room = context.GetArgument<Room>("room");
            return await _unitOfWork.RoomRepository.Add(room);
        }

        public async Task<Room> UpdateRoom(ResolveFieldContext<object> context)
        {
            var room = context.GetArgument<Room>("room");
            var id = context.GetArgument<int>("id");
            room.Id = id;
            return await _unitOfWork.RoomRepository.Update(room);
        }

        public async Task<Room> RemoveRoom(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<int>("id");
            return await _unitOfWork.RoomRepository.Remove(id);
        }
    }
}