using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetCardShelterWorld.Persistence.PetCards;
using PetShelterWorld.Application.Interfaces;
using PetShelterWorld.Domain;
using PetShelterWorld.Persistence.Adoptants;
using PetShelterWorld.Persistence.Attendants;
using PetShelterWorld.Persistence.Pets;

namespace PetShelterWorld.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        private readonly IConfiguration _configuration;

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Attendant> Attendants { get; set; } = null!;
        public DbSet<Adoptant> Adoptants { get; set; } = null!;
        public DbSet<Pet> Pets { get; set; } = null!;
        public DbSet<PetCard> PetCards { get; set; } = null!;
        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("PetShelterWorld"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseService).Assembly);
            //new AttendantConfiguration().Configure(modelBuilder.Entity<Attendant>());
            //new AdoptantConfiguration().Configure(modelBuilder.Entity<Adoptant>());
            //new PetConfiguration().Configure(modelBuilder.Entity<Pet>());
            //new PetCardConfiguration().Configure(modelBuilder.Entity<PetCard>());
        }
    }
}
