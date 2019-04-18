namespace Tiktack.Common.DataAccess
{
    public interface IRepositoryEvent
    {
        RepositoryEventType EventType { get; set; }
        object Entity { get; set; }
    }
}
