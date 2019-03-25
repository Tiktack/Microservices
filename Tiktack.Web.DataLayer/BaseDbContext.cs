using Microsoft.EntityFrameworkCore;
using Tiktack.Web.DataLayer.Entities;

namespace Tiktack.Web.DataLayer
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
