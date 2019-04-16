using System;
using Microsoft.EntityFrameworkCore;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.DataLayer.Infrastructure
{
    public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options)
            : base(options)
        { }
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Room> Rooms { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //GUESTS
        //    modelBuilder.Entity<Guest>().HasData(new Guest
        //    {
        //        Name = "Alper Ebicoglu",
        //        RegisterDate = DateTime.Now.AddDays(-10),
        //        Id = 1
        //    });
        //    modelBuilder.Entity<Guest>().HasData(new Guest
        //    {
        //        Name = "George Michael",
        //        RegisterDate = DateTime.Now.AddDays(-5),
        //        Id = 2
        //    });
        //    modelBuilder.Entity<Guest>().HasData(new Guest
        //    {
        //        Name = "Daft Punk",
        //        RegisterDate = DateTime.Now.AddDays(-1),
        //        Id = 3
        //    });

        //    //ROOMS
        //    modelBuilder.Entity<Room>().HasData(new Room
        //    {
        //        Id = 1,
        //        Name = "yellow-room",
        //        AllowedSmoking = false,
        //        Status = RoomStatus.Available,
        //        Number = 101
        //    });
        //    modelBuilder.Entity<Room>().HasData(new Room
        //    {
        //        Id = 2,
        //        Name = "blue-room",
        //        AllowedSmoking = false,
        //        Status = RoomStatus.Available,
        //        Number = 102
        //    });
        //    modelBuilder.Entity<Room>().HasData(new Room
        //    {
        //        Id = 3,
        //        Name = "white-room",
        //        AllowedSmoking = true,
        //        Status = RoomStatus.Unavailable,
        //        Number = 103
        //    });
        //    modelBuilder.Entity<Room>().HasData(new Room
        //    {
        //        Id = 4,
        //        Name = "black-room",
        //        AllowedSmoking = true,
        //        Status = RoomStatus.Unavailable,
        //        Number = 104
        //    });

        //    //RESERVATIONS
        //    modelBuilder.Entity<Reservation>().HasData(new Reservation
        //    {
        //        Id = 1,
        //        Room = new Room
        //        {
        //            Id = 5,
        //            Name = "custom-room",
        //            AllowedSmoking = true,
        //            Status = RoomStatus.Unavailable,
        //            Number = 105
        //        },
        //        Guest = new Guest
        //        {
        //            Name = "Aleh Khantsevich",
        //            RegisterDate = DateTime.Now.AddDays(-1),
        //            Id = 4
        //        },
        //        CheckinDate = DateTime.Now.AddDays(-2),
        //        CheckoutDate = DateTime.Now.AddDays(3)
        //    });

        //    modelBuilder.Entity<Reservation>().HasData(new Reservation
        //    {
        //        Id = 2,
        //        Room = new Room
        //        {
        //            Id = 6,
        //            Name = "customV1-room",
        //            AllowedSmoking = true,
        //            Status = RoomStatus.Unavailable,
        //            Number = 106
        //        },
        //        Guest = new Guest
        //        {
        //            Name = "Siarhei Mokin",
        //            RegisterDate = DateTime.Now.AddDays(-1),
        //            Id = 5
        //        },
        //        CheckinDate = DateTime.Now.AddDays(-2),
        //        CheckoutDate = DateTime.Now.AddDays(3)
        //    });

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
