using Microsoft.AspNetCore.Mvc;
using PetShelterWorld.Application.PetCards.Commands.CreatePetCard;
using PetShelterWorld.Application.PetCards.Queries.GetPetCardDetails;
using PetShelterWorld.Application.PetCards.Queries.GetPetCardsList;

namespace PetShelterWorld.Presentation.Controllers.PetCard
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetCardController : ControllerBase
    {
        private readonly IGetPetCardsListQuery _queryList;
        private readonly IGetPetCardDetailQuery _queryDetail;
        private readonly ICreatePetCardCommand _commandCreate;

        public PetCardController(IGetPetCardsListQuery query, IGetPetCardDetailQuery detail, ICreatePetCardCommand command)
        {
            _queryList = query;
            _queryDetail = detail;
            _commandCreate = command;
        }

        [HttpGet]
        public ActionResult<List<PetCardsListItemModel>> GetPetCardList()
        {
            return Ok(_queryList.Execute());
        }

        [HttpGet("{id}")]
        public ActionResult<PetCardDetailModel> GetPetCardDetailByPetId(int id)
        {
            return Ok(_queryDetail.Execute(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePetCard([FromBody] CreatePetCardModel petCard)
        {
            await _commandCreate.ExecuteAsync(petCard);
            return CreatedAtAction(nameof(GetPetCardDetailByPetId), new { id = petCard.PetId }, null);
        }
    }
}
