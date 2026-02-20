using PetShelterWorld.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Application.PetCards.Commands.CreatePetCard.Factory
{
    public interface IAdoptionFactory
    {
        PetCard Create(DateTime date, Attendant attendant, Adoptant adoptant, Pet pet, string requirements, int days);
    }
}
