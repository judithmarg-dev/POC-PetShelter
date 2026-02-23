using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShelterWorld.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCardShelterWorld.Persistence.PetCards
{
    public class PetCardConfiguration : IEntityTypeConfiguration<PetCard>
    {
        public void Configure(EntityTypeBuilder<PetCard> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.DateAdoption)
                .IsRequired();

            builder.HasOne(c => c.Attendant);
            builder.Navigation(c => c.Attendant)
                .IsRequired()
                .AutoInclude();

            builder.HasOne(c => c.Adoptant);
            builder.Navigation(c => c.Adoptant)
                .IsRequired()
                .AutoInclude();

            builder.HasOne(c => c.Pet);
            builder.Navigation(c => c.Pet)
                .IsRequired()
                .AutoInclude();

            builder.Property(c => c.Requirement)
                .IsRequired();

            builder.Property(c => c.DaysOnShelter)
                .IsRequired();

            builder.HasData(
                new { Id=1, DateAdoption=DateTime.Parse("2026-02-02"), AttendantId=1, AdoptantId=1,PetId=1, Requirement="Happiness", DaysOnShelter=14 },
                new { Id=2, DateAdoption=DateTime.Parse("2026-02-03"), AttendantId=2, AdoptantId=2,PetId=2, Requirement="Food", DaysOnShelter=24 }
             );
        }
    }
}
