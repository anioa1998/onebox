using Microsoft.EntityFrameworkCore;

namespace OneBox.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }

        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public  DbSet<ParcelLocker> ParcelLockers { get; set; } 
        public DbSet<PostBox> PostBoxes { get; set; } 
    }
}
