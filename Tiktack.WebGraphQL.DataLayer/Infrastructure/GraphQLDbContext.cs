using Microsoft.EntityFrameworkCore;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.DataLayer.Infrastructure
{
    public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions options)
            : base(options)
        { }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}
