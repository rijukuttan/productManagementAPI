
using Microsoft.EntityFrameworkCore;
using productManagementAPI.Models;

namespace productManagementAPI.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

     
        public DbSet<User> User { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<productManagementAPI.Models.UserType>? UserType { get; set; }
    }
}
