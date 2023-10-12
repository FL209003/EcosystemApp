using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace AccessLogic.Repositories
{
    public class EcosystemContext : DbContext
    {
        public DbSet<Ecosystem> Ecosystems { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Threat> Threats { get; set; }
        public DbSet<User> Users { get; set; }
              
        public EcosystemContext(DbContextOptions<EcosystemContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => {entity.HasIndex(e => e.Username).IsUnique();});
            
            modelBuilder.Entity<Ecosystem>().OwnsOne( e => e.EcosystemName).HasIndex(n => n.Value).IsUnique();
            modelBuilder.Entity<Ecosystem>().OwnsOne(e => e.EcoDescription);

            modelBuilder.Entity<Country>().OwnsOne(c => c.CountryName).HasIndex(n => n.Value).IsUnique();

            modelBuilder.Entity<Conservation>().OwnsOne(c => c.ConservationName).HasIndex(n => n.Value).IsUnique();

            modelBuilder.Entity<Species>().OwnsOne(s => s.SpeciesName).HasIndex(n => n.Value).IsUnique();
            modelBuilder.Entity<Species>().OwnsOne(e => e.SpeciesDescription);

            modelBuilder.Entity<Threat>().OwnsOne(t => t.ThreatName).HasIndex(n => n.Value).IsUnique();
            modelBuilder.Entity<Threat>().OwnsOne(e => e.ThreatDescription);
        }
    }
}