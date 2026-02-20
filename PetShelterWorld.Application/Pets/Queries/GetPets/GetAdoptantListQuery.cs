
using PetShelterWorld.Application.Interfaces;

namespace PetShelterWorld.Application.Pets.Queries.GetPets
{
    public class GetPetListQuery : IGetPetListQuery
    {
        private readonly IDatabaseService _database;

        public GetPetListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<PetModel> Execute()
        {
            var pets = _database.Pets
                .Select(p => new PetModel()
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return pets.ToList();
        }
    }
}
