
using PetShelterWorld.Application.Interfaces;

namespace PetShelterWorld.Application.Adoptants.Queries.GetAdoptants
{
    public class GetAdoptantListQuery : IGetAdoptantListQuery
    {
        private readonly IDatabaseService _database;

        public GetAdoptantListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<AttendantModel> Execute()
        {
            var adoptants = _database.Adoptants
                .Select(p => new AttendantModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    HasPets = p.HasPets
                });

            return adoptants.ToList();
        }
    }
}
