using JWTImplementation.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTImplementation.DatabaseContext
{
    public class JwtDbContext : DbContext
    {
        public JwtDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<User> Users {get; set; } // This will generate table
        public DbSet<Employee> Employees {get; set; }
    }
}
