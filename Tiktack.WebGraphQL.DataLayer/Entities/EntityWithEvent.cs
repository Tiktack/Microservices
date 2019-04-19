using Tiktack.Common.DataAccess;
using Tiktack.Common.DataAccess.Repositories;
using Tiktack.Common.DataAccess.Repositories.Interfaces;

namespace Tiktack.WebGraphQL.DataLayer.Entities
{
    public class EntityWithEvent : IRepositoryEvent
    {
        public RepositoryEventType EventType { get; set; }
        public object Entity { get; set; }
    }
}
