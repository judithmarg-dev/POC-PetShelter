
namespace PetShelterWorld.Application.PetCards.Commands.CreatePetCard
{
    public interface ICreatePetCardCommand
    {
        Task ExecuteAsync(CreatePetCardModel model);
    }
}
