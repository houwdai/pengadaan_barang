using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Catalog> Catalog { get; set; }
    }
}
