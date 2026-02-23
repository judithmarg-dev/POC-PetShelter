using Moq;
using Moq.EntityFrameworkCore;
using PetShelterWorld.Application.Interfaces;
using PetShelterWorld.Application.PetCards.Queries.GetPetCardDetails;
using PetShelterWorld.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Tests.PetCardsTest
{
    [TestFixture]
    public class GetPetCardDetailQueryTests
    {

        [Test]
        public void Execute_WhenIdExists_ReturnsProjectedDetail()
        {
            var adoptant = new Adoptant { Id = 1, Name = "Lana", HasPets = true };
            var attendant = new Attendant { Id = 2, Name = "Ryan" };
            var pet = new Pet { Id = 3, Name = "Nina", Age = 2, Type = "dog" };

            var cards = new List<PetCard>{ new PetCard
                {
                    Id = 10,
                    DateAdoption = new DateTime(2025, 02, 03),
                    Adoptant = adoptant,
                    Attendant = attendant,
                    Pet = pet,
                    Requirement = "Vaccine",
                    DaysOnShelter = 50
                }
            };

            var dbMock = new Mock<IDatabaseService>();
            dbMock.SetupGet(d => d.PetCards).ReturnsDbSet(cards);

            var cardMock = new GetPetCardDetailQuery(dbMock.Object);

            var result = cardMock.Execute(10);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(10));
            Assert.That(result.DateAdoption, Is.EqualTo(new DateTime(2025, 02, 03)));
            Assert.That(result.AdoptantName, Is.EqualTo("Lana"));
            Assert.That(result.AttendantName, Is.EqualTo("Ryan"));
            Assert.That(result.PetName, Is.EqualTo("Nina"));
            Assert.That(result.Requirements, Is.EqualTo("Vaccine"));
            Assert.That(result.DaysOnShelter, Is.EqualTo(50));
        }

    }
}
