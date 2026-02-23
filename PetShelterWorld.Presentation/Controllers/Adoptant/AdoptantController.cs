using Microsoft.AspNetCore.Mvc;
using PetShelterWorld.Application.Adoptants.Queries.GetAdoptants;

namespace PetShelterWorld.Presentation.Controllers.Adoptant
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptantController : ControllerBase
    {
        private readonly IGetAdoptantListQuery _query;

        public AdoptantController(IGetAdoptantListQuery query)
        {
            _query = query;
        }

        [HttpGet]
        public ActionResult<List<AdoptantModel>> GetAttendantList()
        {
            return Ok(_query.Execute());
        }
    }
}
