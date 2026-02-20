using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Application.PetCards.Queries.GetPetCardsList
{
    public class PetCardsListItemModel
    {
        public int Id { get; set; }
        public DateTime DateAdoption { get; set; }
        public string AdoptantName { get; set; }
        public string AttendantName { get; set; }
        public string PetName { get; set; }
        public string Requirements { get; set; }
        public int DaysOnShelter { get; set; }
    }
}
