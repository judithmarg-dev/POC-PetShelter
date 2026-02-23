
namespace PetShelterWorld.Application.Interfaces
{
    public interface IShelterService
    {
        Task NotifyAdoptOccurredAsync(int petId, string namePet);
    }
}
