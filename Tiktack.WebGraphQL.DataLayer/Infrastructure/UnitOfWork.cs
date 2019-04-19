using Microsoft.EntityFrameworkCore;
using System;
using Tiktack.Common.DataAccess;
using Tiktack.Common.DataAccess.Repositories.Interfaces;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.DataLayer.Infrastructure
{
    public class UnitOfWork : IDisposable
    {
        private readonly GraphQLDbContext _context;

        private bool _disposed;

        public UnitOfWork(DbContext context, IObservableRepository<Reservation, EntityWithEvent> reservations, IObservableRepository<Guest, EntityWithEvent> guestRepository, IObservableRepository<Room, EntityWithEvent> roomRepository)
        {
            _context = (GraphQLDbContext)context;
            ReservationRepository = reservations;
            GuestRepository = guestRepository;
            RoomRepository = roomRepository;
        }

        public IObservableRepository<Reservation, EntityWithEvent> ReservationRepository { get; }
        public IObservableRepository<Guest, EntityWithEvent> GuestRepository { get; }
        public IObservableRepository<Room, EntityWithEvent> RoomRepository { get; }

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
