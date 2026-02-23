using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShelterWorld.Domain;

namespace PetShelterWorld.Persistence.Adoptants
{
    public class AdoptantConfiguration : IEntityTypeConfiguration<Adoptant>
    {
        public void Configure(EntityTypeBuilder<Adoptant> builder)
        {
            builder.ToTable("Adoptant");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.HasPets)
                .IsRequired();

            builder.HasData(
                new Adoptant() { Id = 1, Name = "Lana del Rey", HasPets = true},
                new Adoptant() { Id = 2, Name = "Billie Eilish", HasPets = false },
                new Adoptant() { Id = 3, Name = "Olivia Rodrigo", HasPets = false });
        }
    }
}
