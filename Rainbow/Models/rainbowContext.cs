using Microsoft.EntityFrameworkCore;

namespace Rainbow.Models
{
    public class rainbowContext : DbContext
    {
        // Constructor to pass DbContextOptions to the base class
        public rainbowContext(DbContextOptions<rainbowContext> options) : base(options) { }
public DbSet<Cake> cakes { get; set; }
public DbSet<Categoury> categories { get; set; }
public DbSet<Admin> admins { get; set; }
public DbSet<Offer> offers { get; set; }

        public DbSet<Review> Reviews { get; set; }




    }
}
