using Moq;
using Moq.EntityFrameworkCore;
using PetShelterWorld.Application.Adoptants.Queries.GetAdoptants;
using PetShelterWorld.Application.Interfaces;
using PetShelterWorld.Domain;

namespace PetShelterWorld.Tests.AdoptantTest
{
    [TestFixture]
    public class GetAdoptantsQueryTest
    {

        [Test]
        public void ExecuteWhenDataExistsReturnsProjectedList()
        {
            var data = new List<Adoptant>
            {
                new Adoptant { Id = 1, Name = "A", HasPets = true },
                new Adoptant { Id = 2, Name = "B", HasPets = false }
            };

            var dbMock = new Mock<IDatabaseService>();
            dbMock.SetupGet(d => d.Adoptants).ReturnsDbSet(data);

            var queryMock = new GetAdoptantListQuery(dbMock.Object);

            var result = queryMock.Execute();

            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.That(result[0].Name, Is.EqualTo("A"));
            Assert.That(result[0].HasPets, Is.True);
            Assert.That(result[1].Id, Is.EqualTo(2));
            Assert.That(result[1].Name, Is.EqualTo("B"));
            Assert.That(result[1].HasPets, Is.False);
        }


        [Test]
        public void ExecuteWhenNoDataReturnsEmptyList()
        {
            var dbMock = new Mock<IDatabaseService>();
            dbMock.SetupGet(d => d.Adoptants).ReturnsDbSet(new List<Adoptant>());

            var queryMock = new GetAdoptantListQuery(dbMock.Object);
            var result = queryMock.Execute();
            
            Assert.That(result, Is.Empty);
        }

    }
}
