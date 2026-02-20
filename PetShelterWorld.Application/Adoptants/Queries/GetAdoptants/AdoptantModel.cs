using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Application.Adoptants.Queries.GetAdoptants
{
    public class AttendantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasPets { get; set; }
    }
}
