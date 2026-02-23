using Microsoft.AspNetCore.Mvc;
using PetShelterWorld.Application.Pets.Queries.GetPets;

namespace PetShelterWorld.Presentation.Controllers.Pet
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IGetPetListQuery _query;

        public PetController(IGetPetListQuery query)
        {
            _query = query;
        }

        [HttpGet]
        public ActionResult<List<PetModel>> GetPetList()
        {
            return Ok(_query.Execute());
        }
    }
}
