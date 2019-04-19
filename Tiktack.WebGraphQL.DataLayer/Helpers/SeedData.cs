using Microsoft.EntityFrameworkCore.Internal;
using System;
using Microsoft.EntityFrameworkCore;
using Tiktack.WebGraphQL.DataLayer.Entities;
using Tiktack.WebGraphQL.DataLayer.Infrastructure;

namespace Tiktack.WebGraphQL.DataLayer.Helpers
{
    public static class SeedData
    {
        public static void GraphQLEnsureSeedData(this DbContext _dbContext)
        {
            var dbContext = (GraphQLDbContext)_dbContext;

            if (!dbContext.Rooms.Any())
            {
                dbContext.Rooms.Add(new Room
                {
                    Name = "Room 601",
                    AllowedSmoking = false,
                    Number = 601,
                    Status = RoomStatus.Available
                });
                dbContext.Rooms.Add(new Room
                {
                    Name = "Room 605",
                    AllowedSmoking = true,
                    Number = 605,
                    Status = RoomStatus.Unavailable
                });
                dbContext.SaveChanges();
            }

            if (!dbContext.Guests.Any())
            {
                dbContext.Guests.Add(new Guest
                {
                    Name = "Artur",
                    RegisterDate = DateTime.Now
                });
                dbContext.Guests.Add(new Guest
                {
                    Name = "Aleh",
                    RegisterDate = DateTime.Now
                });
                dbContext.Guests.Add(new Guest
                {
                    Name = "Siarhey",
                    RegisterDate = DateTime.Now
                });
                dbContext.SaveChanges();
            }

            if (!dbContext.Reservations.Any())
            {
                dbContext.Reservations.Add(new Reservation
                {
                    GuestId = 2,
                    RoomId = 2,
                    CheckinDate = DateTime.Now.AddDays(-2),
                    CheckoutDate = DateTime.Now.AddDays(3)
                });
                dbContext.SaveChanges();
                dbContext.Reservations.Add(new Reservation
                {
                    GuestId = 3,
                    RoomId = 3,
                    CheckinDate = DateTime.Now.AddDays(-5),
                    CheckoutDate = DateTime.Now.AddDays(10)
                });
                dbContext.Reservations.Add(new Reservation
                {
                    GuestId = 4,
                    RoomId = 2,
                    CheckinDate = DateTime.Now.AddDays(-5),
                    CheckoutDate = DateTime.Now.AddDays(10)
                });

                dbContext.SaveChanges();
            }
        }
    }
}
