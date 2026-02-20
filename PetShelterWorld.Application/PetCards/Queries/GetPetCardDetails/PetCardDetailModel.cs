
namespace PetShelterWorld.Application.PetCards.Queries.GetPetCardDetails
{
    public class PetCardDetailModel
    {
        public int Id { get; set; }
        public DateTime DateAdoption { get; set; }
        public string AdoptantName { get; set; }
        public string AttendantName { get; set; }
        public string PetName { get; set; }
        public string Requirements { get; set; }
        public int DaysOnShelter { get; set; }
    }
}
