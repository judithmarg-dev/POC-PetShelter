
using PetShelterWorld.Application.Interfaces;

namespace PetShelterWorld.Application.PetCards.Queries.GetPetCardDetails
{
    public class GetPetCardDetailQuery : IGetPetCardDetailQuery
    {
        private readonly IDatabaseService _database;

        public GetPetCardDetailQuery(IDatabaseService database)
        {
            _database = database;
        }

        public PetCardDetailModel Execute(int petCardId)
        {
            var card = _database.PetCards
                .Where(p => p.Id == petCardId)
                .Select(p => new PetCardDetailModel()
                {
                    Id = p.Id,
                    DateAdoption = p.DateAdoption,
                    AdoptantName = p.Adoptant.Name,
                    AttendantName = p.Attendant.Name,
                    PetName = p.Pet.Name,
                    Requirements = p.Requirement,
                    DaysOnShelter = p.DaysOnShelter
                })
                .Single();

            return card;
        }
    }
}
