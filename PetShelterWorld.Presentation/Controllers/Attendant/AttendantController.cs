using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShelterWorld.Application.Attendants.Queries.GetAttendants;

namespace PetShelterWorld.Presentation.Controllers.Attendant
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetCardController : ControllerBase
    {
        private readonly IGetAttendantListQuery _query;

        public PetCardController(IGetAttendantListQuery query)
        {
            _query = query;
        }

        [HttpGet]
        public ActionResult<List<AttendantModel>> GetAttendantList()
        {
            return Ok(_query.Execute());
        }
    }
}
