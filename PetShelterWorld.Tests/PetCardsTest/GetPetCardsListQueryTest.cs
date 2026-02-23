using Moq;
using Moq.EntityFrameworkCore;
using PetShelterWorld.Application.Interfaces;
using PetShelterWorld.Application.PetCards.Queries.GetPetCardsList;
using PetShelterWorld.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Tests.PetCardsTest
{
    [TestFixture]
    public class GetPetCardsListQueryTest
    {

        [Test]
        public void Execute_Should_Project_From_Mocked_DbSet()
        {
            var adoptant = new Adoptant { Id = 1, Name = "Lana", HasPets = true };
            var attendant = new Attendant { Id = 2, Name = "Ryan" };
            var pet = new Pet { Id = 3, Name = "Nina", Age = 2, Type = "dog" };

            var cards = new List<PetCard>
            {
                new PetCard
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

            var sut = new GetPetCardsListQuery(dbMock.Object);

            var result = sut.Execute();

            Assert.That(result, Has.Count.EqualTo(1));
            var item = result[0];
            Assert.That(item.Id, Is.EqualTo(10));
            Assert.That(item.DateAdoption, Is.EqualTo(new DateTime(2025, 02, 03)));
            Assert.That(item.AdoptantName, Is.EqualTo("Lana"));
            Assert.That(item.AttendantName, Is.EqualTo("Ryan"));
            Assert.That(item.PetName, Is.EqualTo("Nina"));
            Assert.That(item.Requirements, Is.EqualTo("Vaccine"));
            Assert.That(item.DaysOnShelter, Is.EqualTo(50));
        }

    }
}
