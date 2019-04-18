using Microsoft.EntityFrameworkCore;
using System;
using Tiktack.Common.DataAccess;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.DataLayer.Infrastructure
{
    public class UnitOfWork : IDisposable
    {
        private readonly GraphQLDbContext _context;

        private bool _disposed;

        public UnitOfWork(DbContext context, IObservableRepository<Reservation, ReservationWithEvent> reservations)
        {
            _context = (GraphQLDbContext)context;
            ReservationRepository = reservations;
        }

        public IObservableRepository<Reservation, ReservationWithEvent> ReservationRepository { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing) _context.Dispose();

            _disposed = true;
        }
    }
}
