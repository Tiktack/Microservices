using System;
using System.Collections.Generic;
using System.Linq;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.BusinessLayer
{
    public class ReservationProvider : IReservationProvider
    {
        private readonly IList<Reservation> _reservations = new List<Reservation>();
        private readonly IList<Guest> _guests = new List<Guest>();
        private readonly IList<Room> _rooms = new List<Room>();

        public ReservationProvider()
        {
            _reservations.Add(new Reservation
            {
                CheckinDate = DateTime.Now,
                CheckoutDate = DateTime.Now,
                Id = 1
            });
            _reservations.Add(new Reservation
            {
                CheckinDate = DateTime.Now - TimeSpan.FromHours(2),
                CheckoutDate = DateTime.Now - TimeSpan.FromHours(2),
                Id = 2
            });

            _guests.Add(new Guest
            {
                Name = "Aleh",
                Id = 1,
                RegisterDate = DateTime.MaxValue
            });

            _guests.Add(new Guest
            {
                Name = "Siarhey",
                Id = 2,
                RegisterDate = DateTime.MinValue
            });

            _rooms.Add(new Room
            {
                Name = "509",
                Id = 1,
                AllowedSmoking = false,
                Number = 509,
                Status = RoomStatus.Available
            });
            _rooms.Add(new Room
            {
                Name = "604",
                Id = 2,
                AllowedSmoking = true,
                Number = 604,
                Status = RoomStatus.Unavailable
            });
        }

        public IList<Room> GetRooms() => _rooms;
        public IList<Reservation> GetReservations() => _reservations;
        public IList<Guest> GetGuests() => _guests;
        public Reservation GetReservation(int id) => _reservations.First(x => x.Id == id);
        public Room GetRoom(int id) => _rooms.First(x => x.Id == id);
        public Guest GetGuest(int id) => _guests.First(x => x.Id == id);
    }
}
