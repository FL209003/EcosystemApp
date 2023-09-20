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
    }
}