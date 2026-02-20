
using PetShelterWorld.Application.Interfaces;

namespace PetShelterWorld.Application.Attendants.Queries.GetAttendants
{
    public class GetAttendantListQuery : IGetAttendantListQuery
    {
        private readonly IDatabaseService _database;

        public GetAttendantListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<AttendantModel> Execute()
        {
            var Attendants = _database.Attendants
                .Select(p => new AttendantModel()
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return Attendants.ToList();
        }
    }
}
