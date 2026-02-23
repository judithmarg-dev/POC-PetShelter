using PetShelterWorld.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Application.PetCards.Commands.CreatePetCard.Factory
{

    [TestFixture]
    public class AdoptionFactoryTests
    {
        private AdoptionFactory _factory = default!;
        private Adoptant _adoptant = default!;
        private Attendant _attendant = default!;
        private Pet _pet = default!;

        private static readonly DateTime Date = new(2025, 02, 03);
        private const int DaysOnShelter = 50;
        private const string Requirements = "Vaccine";

        [SetUp]
        public void SetUp()
        {
            _factory = new AdoptionFactory();

            _adoptant = new Adoptant
            {
                Id = 1,
                Name = "Lana del Rey",
                HasPets = true
            };

            _attendant = new Attendant
            {
                Id = 2,
                Name = "Ryan Feller"
            };

            _pet = new Pet
            {
                Id = 3,
                Name = "pet",
                Age = 2,
                Type = "dog"
            };
        }

        [Test]
        public void Create_ShouldPopulateAllFields()
        {
            // Act
            var result = _factory.Create(Date, _attendant, _adoptant, _pet, Requirements, DaysOnShelter);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.DateAdoption, Is.EqualTo(Date));
            Assert.That(result.Attendant, Is.EqualTo(_attendant));
            Assert.That(result.Adoptant, Is.EqualTo(_adoptant));
            Assert.That(result.Pet, Is.EqualTo(_pet));
            Assert.That(result.Requirement, Is.EqualTo(Requirements));
            Assert.That(result.DaysOnShelter, Is.EqualTo(DaysOnShelter));

        }
    }
}
