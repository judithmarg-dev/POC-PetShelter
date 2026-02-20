using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterWorld.Application.PetCards.Queries.GetPetCardDetails
{
    public interface IGetPetCardDetailQuery
    {
        PetCardDetailModel Execute(int petCardId);
    }
}
