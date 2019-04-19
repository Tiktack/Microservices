namespace Tiktack.Common.DataAccess.Repositories.Interfaces
{
    public interface IRepositoryEvent
    {
        RepositoryEventType EventType { get; set; }
        object Entity { get; set; }
    }
}
