using Moq;
using Moq.EntityFrameworkCore;
using PetShelterWorld.Application.Pets.Queries.GetPets;
using PetShelterWorld.Application.Interfaces;
using PetShelterWorld.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Tests.PetsTest
{
    [TestFixture]
    public class GetPetListQueryTest
    {
        [Test]
        public void ExecuteWhenDataExistsReturnsProjectedList()
        {
            var data = new List<Pet>
            {
                new Pet { Id = 1, Name = "A", Age = 0, Type = "a"},
                new Pet { Id = 2, Name = "B", Age = 100, Type = "ab"}
            };

            var dbMock = new Mock<IDatabaseService>();
            dbMock.SetupGet(d => d.Pets).ReturnsDbSet(data);

            var queryMock = new GetPetListQuery(dbMock.Object);

            var result = queryMock.Execute();

            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.That(result[0].Name, Is.EqualTo("A"));
            Assert.That(result[0].Age, Is.EqualTo(0));
            Assert.That(result[0].Type, Is.EqualTo("a"));
            Assert.That(result[1].Id, Is.EqualTo(2));
            Assert.That(result[1].Name, Is.EqualTo("B"));
            Assert.That(result[1].Age, Is.EqualTo(100));
            Assert.That(result[1].Type, Is.EqualTo("ab"));
        }


        [Test]
        public void ExecuteWhenNoDataReturnsEmptyList()
        {
            var dbMock = new Mock<IDatabaseService>();
            dbMock.SetupGet(d => d.Pets).ReturnsDbSet(new List<Pet>());

            var queryMock = new GetPetListQuery(dbMock.Object);
            var result = queryMock.Execute();

            Assert.That(result, Is.Empty);
        }
    }
}
