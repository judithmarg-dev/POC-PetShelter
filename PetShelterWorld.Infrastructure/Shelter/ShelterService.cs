using Microsoft.Extensions.Logging;
using PetShelterWorld.Application.Interfaces;

namespace PetShelterWorld.Infrastructure.Shelter
{
    public sealed class ShelterService : IShelterService
    {
        private readonly ILogger<ShelterService> _logger;

        public ShelterService(ILogger<ShelterService> logger)
        {
            _logger = logger;
        }

        public Task NotifyAdoptOccurredAsync(int petId, string requirement)
        {
            _logger.LogInformation("Stub: NotifyAdoptOccurredAsync(petId: {PetId}, requirement: {Requirement}) invocado.", petId, requirement);
            return Task.CompletedTask;
        }

    }
}
