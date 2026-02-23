using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShelterWorld.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Persistence.Pets
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pet");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Type)
                .IsRequired();

            builder.Property(p => p.Age)
                .IsRequired();

            builder.HasData(
                new Pet() { Id = 1, Name = "Tobby", Type = "Dog", Age = 2},
                new Pet() { Id = 2, Name = "Miau", Type = "Cat", Age = 5 });
        }
    }
}
