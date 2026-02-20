using PetShelterWorld.Application.Interfaces;

namespace PetShelterWorld.Application.PetCards.Queries.GetPetCardsList
{
    public class GetPetCardsListQuery : IGetPetCardsListQuery
    {
        private readonly IDatabaseService _database;

        public GetPetCardsListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<PetCardsListItemModel> Execute()
        {
            var cards = _database.PetCards
                .Select(p => new PetCardsListItemModel()
                {
                    Id= p.Id,
                    DateAdoption= p.DateAdoption,
                    AdoptantName= p.Adoptant.Name,
                    AttendantName= p.Attendant.Name,
                    PetName= p.Pet.Name,
                    Requirements= p.Requirement,
                    DaysOnShelter= p.DaysOnShelter
                });
            return cards.ToList();
        }
    }
}
