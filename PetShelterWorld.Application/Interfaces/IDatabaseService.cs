using Microsoft.EntityFrameworkCore;
using PetShelterWorld.Domain;

namespace PetShelterWorld.Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<Attendant> Attendants { get; set; }
        DbSet<Adoptant> Adoptants { get; set; }
        DbSet<Pet> Pets { get; set; }
        DbSet<PetCard> PetCards { get; set; }

        void Save();
    }
}
