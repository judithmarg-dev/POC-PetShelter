using Moq;
using Moq.EntityFrameworkCore;
using PetShelterWorld.Application.Attendants.Queries.GetAttendants;
using PetShelterWorld.Application.Interfaces;
using PetShelterWorld.Domain;

namespace PetShelterWorld.Tests.AttendantTest
{
    [TestFixture]
    public class GetAttendantsQueryTest
    {

        [Test]
        public void ExecuteWhenDataExistsReturnsProjectedList()
        {
            var data = new List<Attendant>
            {
                new Attendant { Id = 1, Name = "A"},
                new Attendant { Id = 2, Name = "B"}
            };

            var dbMock = new Mock<IDatabaseService>();
            dbMock.SetupGet(d => d.Attendants).ReturnsDbSet(data);

            var queryMock = new GetAttendantListQuery(dbMock.Object);

            var result = queryMock.Execute();

            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.That(result[0].Name, Is.EqualTo("A"));
            Assert.That(result[1].Id, Is.EqualTo(2));
            Assert.That(result[1].Name, Is.EqualTo("B"));
        }


        [Test]
        public void ExecuteWhenNoDataReturnsEmptyList()
        {
            var dbMock = new Mock<IDatabaseService>();
            dbMock.SetupGet(d => d.Attendants).ReturnsDbSet(new List<Attendant>());

            var queryMock = new GetAttendantListQuery(dbMock.Object);
            var result = queryMock.Execute();

            Assert.That(result, Is.Empty);
        }

    }
}

