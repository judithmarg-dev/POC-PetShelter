using PetShelterWorld.Domain;

namespace PetShelterWorld.Application.PetCards.Commands.CreatePetCard.Factory
{
    public class AdoptionFactory : IAdoptionFactory
    {
        public PetCard Create(DateTime date, Attendant attendant, Adoptant adoptant, Pet pet, string requirements, int days)
        {
            var card = new PetCard();
            card.DateAdoption = date;
            card.Attendant = attendant;
            card.Adoptant = adoptant;
            card.Pet = pet;
            card.Requirement = requirements;
            card.DaysOnShelter = days;
            return card;
        }
    }
}
