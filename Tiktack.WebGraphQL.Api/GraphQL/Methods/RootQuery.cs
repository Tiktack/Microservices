using GraphQL.Types;
using Tiktack.WebGraphQL.Api.GraphQL.Types;
using Tiktack.WebGraphQL.DataLayer.Infrastructure;

namespace Tiktack.WebGraphQL.Api.GraphQL.Methods
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(UnitOfWork unitOfWork)
        {
            Field<ListGraphType<ReservationType>>(
                "reservations",
                resolve: context => unitOfWork.ReservationRepository.GetAll(includeProperties:
                    string.Join(',',
                        context.SubFields.Keys
                    )));

            Field<ReservationType>(
                "reservation",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                {
                    Name = "id"
                }),
                resolve: context => unitOfWork.ReservationRepository
                    .GetById(context.GetArgument<int>("id")));

            Field<ListGraphType<GuestType>>(
                "guests",
                resolve: context => unitOfWork.GuestRepository.GetAll(includeProperties:
                    string.Join(',',
                        context.SubFields.Keys
                    )));

            Field<ListGraphType<RoomType>>(
                "rooms",
                resolve: context => unitOfWork.RoomRepository.GetAll(includeProperties:
                    string.Join(',',
                        context.SubFields.Keys
                    )));
        }
    }
}
