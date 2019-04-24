using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiktack.Common.DataAccess.Helpers;
using Tiktack.Common.DataAccess.Repositories.Interfaces;

namespace Tiktack.Common.DataAccess.Repositories
{
    public class ObservableRepository<TDomain, TEvent> : IObservableRepository<TDomain, TEvent>
        where TDomain : class
        where TEvent : IRepositoryEvent, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<TDomain> _dbSet;
        private readonly ISubject<TEvent> _observable;

        public IObservable<TEvent> ObservableSubject() => _observable.AsObservable();

        public ObservableRepository(DbContext context, ISubject<TEvent> observable)
        {
            _context = context;
            _observable = observable;
            _dbSet = _context.Set<TDomain>();
        }

        public async Task<TDomain> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TDomain> Add(TDomain entity)
        {
            var entry = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            Notify(entry.Entity, RepositoryEventType.AddEvent);

            return entry.Entity;
        }

        public async Task AddRange(IEnumerable<TDomain> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<TDomain> Update(TDomain entity)
        {
            var entry = _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            Notify(entry.Entity, RepositoryEventType.UpdateEvent);

            return entry.Entity;
        }

        public async Task<TDomain> Remove(int id)
        {
            var entity = await GetById(id);
            var entry = _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            Notify(entry.Entity, RepositoryEventType.RemoveEvent);

            return entry.Entity;
        }

        public IQueryable<TDomain> GetAll(
            Expression<Func<TDomain, bool>> filter = null,
            Func<IQueryable<TDomain>, IOrderedQueryable<TDomain>> orderBy = null,
            string includeProperties = null)
        {
            var query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                var navigationProps = typeof(TDomain).GetNavigationProps();
                query = includeProperties
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => char.ToUpper(x[0]) + x.Substring(1))
                    .Intersect(navigationProps)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            return orderBy != null ? orderBy(query) : query;
        }

        private void Notify(TDomain domain, RepositoryEventType eventType)
        {
            var tEvent = new TEvent
            {
                Entity = domain,
                EventType = eventType
            };
            _observable.OnNext(tEvent);
        }

        
    }
}