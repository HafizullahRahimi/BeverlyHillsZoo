using BeverlyHillsZoo.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BeverlyHillsZoo.Web.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext(){ }

        //Set Models(Entity)
        public DbSet<Animal> Animals { get; set; }
        public virtual DbSet<HabitatAir> HabitatAir { get; set; } = default!;
        public DbSet<HabitatLand> HabitatLand { get; set; } = default!;
        public DbSet<HabitatWater> HabitatWaters { get; set; } = default!;
        public virtual DbSet<Visitor> Visitors { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Guide> Guides { get; set; }




        //On Configuring


        //On Model Creating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Animal
            builder.Entity<Animal>(x => {
                x.HasKey(m => m.Id);

                x.HasDiscriminator<int>("Type")
                    .HasValue<HabitatAir>(1)
                    .HasValue<HabitatLand>(2)
                    .HasValue<HabitatWater>(3);
            });
            builder.Entity<HabitatAir>(x => x.HasBaseType<Animal>());
            builder.Entity<HabitatLand>(x => x.HasBaseType<Animal>());
            builder.Entity<HabitatWater>(x => x.HasBaseType<Animal>());

            //Guide
            builder.Entity<Guide>().HasKey(g=> g.Id); 
            builder.Entity<Guide>().Property(g => g.Name).IsRequired();
            builder.Entity<Guide>().Property(g => g.CompetenceType).IsRequired();
        }

    }
}
