using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Application.PetCards.Commands.CreatePetCard
{
    public class CreatePetCardModel
    {
        public int AttendantId { get; set; }
        public int AdoptantId { get; set; }
        public int PetId { get; set; }
        public int DaysOnShelter { get; set; }
        public string? Requirement { get; set; }
    }
}
