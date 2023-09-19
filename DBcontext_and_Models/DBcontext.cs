using Microsoft.EntityFrameworkCore;
namespace API_6._0_2.DBcontext

{
    public class EF_DBcontext : DbContext
    {
        public EF_DBcontext(DbContextOptions<EF_DBcontext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Huyen>()
             //   .HasKey(h => new { h.Tid, h.Hid }); // Composite key configuration
        }
        public DbSet<Tinh> Tinhs { get; set; }
        public DbSet<Huyen> Huyens { get; set; }
        public DbSet<Xa> Xas { get; set; }
    }
}