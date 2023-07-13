using Aviation.BL.Dto;
using Aviation.BL.Services;
using Aviation.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aviation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirCraftController : ControllerBase
    {
        private readonly IAirCraftService _airCraftService;

        public AirCraftController(IAirCraftService airCraftService)
        {
            _airCraftService = airCraftService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AirCraftGet>> FilterAirCrafts(string? searchTerm)
        {
            var airCrafts = _airCraftService.FilterAirCrafts(searchTerm);

            if (airCrafts != null)
                return Ok(airCrafts);

            return NotFound();
        }

        [HttpGet("{id}", Name = "GetAirCraftById")]
        public ActionResult<AirCraftGet> GetAirCraftById(int id)
        {
            var airCraft = _airCraftService.GetAirCraftById(id);

            if(airCraft != null)
                return Ok(airCraft);

            return NotFound();
        }

        [HttpPost]
        public ActionResult<AirCraftGet> AddAirCraft(AirCraftUpdate airCraft)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(airCraft.Id > 0)
            {
                _airCraftService.UpdateAirCraft(airCraft);
                return Ok();
            }

            _airCraftService.AddAirCraft(airCraft);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveAirCraft(int id)
        {
            _airCraftService.RemoveAirCraft(id);
            return NoContent();
        }
    }
}
