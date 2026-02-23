using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShelterWorld.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Persistence.Attendants
{
    public class AttendantConfiguration : IEntityTypeConfiguration<Attendant>
    {
        public void Configure(EntityTypeBuilder<Attendant> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new Attendant() { Id = 1, Name = "Ryan Feller" },
                new Attendant() { Id = 2, Name = "Emma Norm" },
                new Attendant() { Id = 3, Name = "Ely Wood" });
        }
    }
}
