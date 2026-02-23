using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetCardShelterWorld.Persistence.PetCards;
using PetShelterWorld.Application.Interfaces;
using PetShelterWorld.Domain;
using PetShelterWorld.Persistence.Adoptants;
using PetShelterWorld.Persistence.Attendants;
using PetShelterWorld.Persistence.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        private readonly IConfiguration _configuration;

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }

        public DbSet<Attendant> Attendants { get; set; }
        public DbSet<Adoptant> Adoptants { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetCard> PetsCards { get; set; }
        public DbSet<PetCard> PetCards { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("PetShelterWorld");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new AttendantConfiguration().Configure(modelBuilder.Entity<Attendant>());
            new AdoptantConfiguration().Configure(modelBuilder.Entity<Adoptant>());
            new PetConfiguration().Configure(modelBuilder.Entity<Pet>());
            new PetCardConfiguration().Configure(modelBuilder.Entity<PetCard>());
        }
    }
}
