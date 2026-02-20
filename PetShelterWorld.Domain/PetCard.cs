using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Domain
{
    public class PetCard
    {
        public int Id { get; set; }
        public DateTime DateAdoption { get; set; }
        public Pet Pet { get; set; }
        public Adoptant Adoptant { get; set; }
        public Attendant Attendant { get; set; }
        public int DaysOnShelter { get; set; }
        public string Requirement { get; set; }

    }
}
