using PetShelterWorld.Application.Interfaces;
using PetShelterWorld.Application.PetCards.Commands.CreatePetCard.Factory;

namespace PetShelterWorld.Application.PetCards.Commands.CreatePetCard
{
    public class CreatePetCardCommand : ICreatePetCardCommand
    {
        private readonly IDatabaseService _database;
        private readonly IAdoptionFactory _factory;
        private readonly IShelterService _shelterService;

        public CreatePetCardCommand(
            IDatabaseService database,
            IAdoptionFactory factory,
            IShelterService shelterService)
        {
            _database = database;
            _factory = factory;
            _shelterService = shelterService;
        }

        public async Task ExecuteAsync(CreatePetCardModel model)
        {
            var date = DateTime.UtcNow;

            var attendant = _database.Attendants
                .Single(p => p.Id == model.AttendantId);

            var adoptant = _database.Adoptants
                .Single(p => p.Id == model.AdoptantId);

            var pet = _database.Pets
                .Single(p => p.Id == model.PetId);

            var requirement = model.Requirement;
            var daysOnShelter = model.DaysOnShelter;

            var card = _factory.Create(date, attendant, adoptant, pet, requirement, daysOnShelter);

            _database.PetCards.Add(card);
            _database.Save();
            _shelterService.NotifyAdoptOccurredAsync(pet.Id, pet.Name);
        }
    }
}
