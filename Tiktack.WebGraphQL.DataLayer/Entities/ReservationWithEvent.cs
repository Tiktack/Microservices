using Tiktack.Common.DataAccess;

namespace Tiktack.WebGraphQL.DataLayer.Entities
{
    public class ReservationWithEvent : IRepositoryEvent
    {
        public RepositoryEventType EventType { get; set; }
        public object Entity { get; set; }
    }
}
