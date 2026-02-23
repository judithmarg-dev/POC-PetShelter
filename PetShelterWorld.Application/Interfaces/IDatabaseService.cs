using Microsoft.EntityFrameworkCore;
using PetShelterWorld.Domain;

namespace PetShelterWorld.Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<Attendant> Attendants { get; }
        DbSet<Adoptant> Adoptants { get; }
        DbSet<Pet> Pets { get;  }
        DbSet<PetCard> PetCards { get; }

        void Save();
    }
}
