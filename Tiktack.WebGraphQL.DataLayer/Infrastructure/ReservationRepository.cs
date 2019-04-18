using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.DataLayer.Infrastructure
{
    public class ReservationRepository
    {
        private readonly GraphQLDbContext _myHotelDbContext;
        private readonly Subject<Reservation> _subject;

        public ReservationRepository(GraphQLDbContext myHotelDbContext)
        {
            _myHotelDbContext = myHotelDbContext;
            _subject = new Subject<Reservation>();
        }

        public IObservable<Reservation> ReservationCreated => _subject.AsObservable();

        public async Task<List<T>> GetAll<T>()
        {
            return await GetQuery().ProjectTo<T>().ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _myHotelDbContext
                .Reservations
                .Include(x => x.Room)
                .Include(x => x.Guest)
                .ToListAsync();
        }

        public async Task<Reservation> Add(Reservation reservation)
        {
            var entity = await _myHotelDbContext.Reservations.AddAsync(reservation);
            await _myHotelDbContext.SaveChangesAsync();
            return entity.Entity;
        }
        public async Task<Reservation> AddWithGuest(Reservation reservation)
        {
            //find guest
            var guest = await _myHotelDbContext.Guests.FirstAsync();
            reservation.Guest = guest;
            //save to db
            var entity = await _myHotelDbContext.Reservations.AddAsync(reservation);
            await _myHotelDbContext.SaveChangesAsync();
            //notify
            _subject.OnNext(reservation);

            return entity.Entity;
        }

        public Reservation Get(int id)
        {
            return GetQuery().Single(x => x.Id == id);
        }

        public IIncludableQueryable<Reservation, Guest> GetQuery()
        {
            return _myHotelDbContext
                .Reservations
                .Include(x => x.Room)
                .Include(x => x.Guest);
        }
    }
}
