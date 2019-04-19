using System;
using System.Threading.Tasks;
using GraphQL.Types;
using Tiktack.WebGraphQL.DataLayer.Entities;
using Tiktack.WebGraphQL.DataLayer.Infrastructure;

namespace Tiktack.WebGraphQL.BusinessLayer.Providers
{
    public class GuestProvider : IGuestProvider
    {
        private readonly UnitOfWork _unitOfWork;

        public GuestProvider(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guest> AddGuest(ResolveFieldContext<object> context)
        {
            var guest = context.GetArgument<Guest>("guest");
            guest.RegisterDate = DateTime.Now;
            return await _unitOfWork.GuestRepository.Add(guest);
        }

        public async Task<Guest> UpdateGuest(ResolveFieldContext<object> context)
        {
            var guest = context.GetArgument<Guest>("guest");
            var id = context.GetArgument<int>("id");
            guest.Id = id;
            return await _unitOfWork.GuestRepository.Update(guest);
        }

        public async Task<Guest> RemoveGuest(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<int>("id");
            return await _unitOfWork.GuestRepository.Remove(id);
        }
    }
}