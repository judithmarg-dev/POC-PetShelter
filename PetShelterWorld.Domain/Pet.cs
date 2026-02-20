using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Domain
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string type { get; set; }
        public double age { get; set; }
        public string description { get; set; }
        public bool wasRescued { get; set; }
    }
}
