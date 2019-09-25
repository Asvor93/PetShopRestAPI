using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.SQL
{
    public class PetShopContext: DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasOne(o => o.PreviousOwner).WithMany(p => p.Pets)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PetColor>().HasKey(pc => new {pc.ColorId, pc.PetId});

            modelBuilder.Entity<PetColor>().HasOne(pc => pc.Pet).WithMany(pc => pc.PetColors);
            modelBuilder.Entity<PetColor>().HasOne(pc => pc.Color).WithMany(pc => pc.PetList);

        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<PetColor> PetColors { get; set; }
    }
}