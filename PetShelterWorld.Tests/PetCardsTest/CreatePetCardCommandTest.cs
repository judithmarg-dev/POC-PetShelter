using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.AutoMock;
using Moq.EntityFrameworkCore;
using PetShelterWorld.Application.Interfaces;
using PetShelterWorld.Application.PetCards.Commands.CreatePetCard;
using PetShelterWorld.Application.PetCards.Commands.CreatePetCard.Factory;
using PetShelterWorld.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Tests.PetCardsTest
{
    public class CreatePetCardCommandTest
    {
        private ICreatePetCardCommand _command = default!;
        private AutoMocker _mocker = default!;
        private CreatePetCardModel _model = default!;
        private PetCard _petCard = default!;

        private const int AdoptantId = 1;
        private const int AttendantId = 2;
        private const int PetId = 3;
        private const int DaysOnShelter = 50;
        private const string Requirements = "Vaccine";

        [SetUp]
        public void SetUp()
        {
            var adoptant = new Adoptant { Id = AdoptantId, Name = "Ad1", HasPets = true };
            var attendant = new Attendant { Id = AttendantId, Name = "At1" };
            var pet = new Pet { Id = PetId, Name = "pet", Age = 2, Type = "dog" };

            _model = new CreatePetCardModel
            {
                AdoptantId = AdoptantId,
                AttendantId = AttendantId,
                PetId = PetId,
                DaysOnShelter = DaysOnShelter,
                Requirement = Requirements,
            };

            _petCard = new PetCard();

            _mocker = new AutoMocker();
            _mocker.GetMock<IDatabaseService>()
                   .SetupGet(p => p.Adoptants)
                   .ReturnsDbSet(new List<Adoptant> { adoptant });

            _mocker.GetMock<IDatabaseService>()
                   .SetupGet(p => p.Attendants)
                   .ReturnsDbSet(new List<Attendant> { attendant });

            _mocker.GetMock<IDatabaseService>()
                   .SetupGet(p => p.Pets)
                   .ReturnsDbSet(new List<Pet> { pet });

            var petCardsDbSetMock = new Mock<DbSet<PetCard>>();
            _mocker.GetMock<IDatabaseService>()
                   .SetupGet(p => p.PetCards)
                   .Returns(petCardsDbSetMock.Object);

            _mocker.GetMock<IAdoptionFactory>()
                   .Setup(f => f.Create(
                       It.IsAny<DateTime>(),
                       It.Is<Attendant>(a => a.Id == AttendantId),
                       It.Is<Adoptant>(a => a.Id == AdoptantId),
                       It.Is<Pet>(p => p.Id == PetId),
                       Requirements,
                       DaysOnShelter))
                   .Returns(_petCard);

            _command = _mocker.CreateInstance<CreatePetCardCommand>();
        }

        [Test]
        public async Task TestExecute_ShouldSaveChanges()
        {
            await _command.ExecuteAsync(_model);

            _mocker.GetMock<IDatabaseService>().Verify(db => db.Save(), Times.Once);
        }

        [Test]
        public async Task TestExecute_ShouldNotifyShelter()
        {
            await _command.ExecuteAsync(_model);

            _mocker.GetMock<IShelterService>()
                   .Verify(s => s.NotifyAdoptOccurredAsync(PetId, "pet"));
        }
    }
}
