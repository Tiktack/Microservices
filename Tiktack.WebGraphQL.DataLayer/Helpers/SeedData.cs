using Microsoft.EntityFrameworkCore.Internal;
using System;
using Tiktack.WebGraphQL.DataLayer.Entities;
using Tiktack.WebGraphQL.DataLayer.Infrastructure;

namespace Tiktack.WebGraphQL.DataLayer.Helpers
{
    public static class SeedData
    {
        public static void GraphQLEnsureSeedData(this GraphQLDbContext dbContext)
        {
            if (!dbContext.Reservations.Any())
            {
                dbContext.Reservations.Add(new Reservation
                {
                    Room = new Room
                    {
                        Name = "customV1-room",
                        AllowedSmoking = true,
                        Status = RoomStatus.Unavailable,
                        Number = 106
                    },
                    Guest = new Guest
                    {
                        Name = "Siarhei Mokin",
                        RegisterDate = DateTime.Now.AddDays(-1),
                    },
                    CheckinDate = DateTime.Now.AddDays(-2),
                    CheckoutDate = DateTime.Now.AddDays(3)
                });
                dbContext.SaveChanges();
            }
        }
    }
}
