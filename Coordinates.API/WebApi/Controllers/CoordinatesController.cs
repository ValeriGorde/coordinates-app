using Coordinates.API.DAL.Models; // Coordinate
using Coordinates.API.DAL.Repositories; // ICoordinareRepostory
using Microsoft.AspNetCore.Mvc;

namespace Coordinates.API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinatesController(ICoordinatesRepository coordinatesRepository) : ControllerBase
    {
        private readonly ICoordinatesRepository _coordinatesRepository = coordinatesRepository;

        // GET: coordinates?count=<int>
        [HttpGet("{count}", Name = nameof(GetCoordinates))] //??
        [ProducesResponseType(200, Type = typeof(List<Coordinate>))]
        [ProducesResponseType(400)]
        public ActionResult<List<Coordinate>> GetCoordinates(int count)
        {
            if(count < 1)
            {
                return BadRequest("Количество координат должно быть больше 1");
            }

            List<Coordinate> randomCoordinates = _coordinatesRepository.GetCoordinates(count);

            return Ok(randomCoordinates);
        }


    }
}
