using System;

namespace Tiktack.Common.DataAccess
{
    public interface IObservableRepository<TDomain, out TEvent> : IRepository<TDomain>
        where TDomain : class
        where TEvent : IRepositoryEvent, new()
    {
        IObservable<TEvent> ObservableSubject();
    }
}
