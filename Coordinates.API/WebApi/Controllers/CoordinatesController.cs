global using Coordinates.API.DAL.Models; // Coordinate
using Coordinates.API.DAL.Repositories; // ICoordinareRepostory
using Microsoft.AspNetCore.Mvc;

namespace Coordinates.API.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoordinatesController(ICoordinatesRepository coordinatesRepository) : ControllerBase
{
    private readonly ICoordinatesRepository _coordinatesRepository = coordinatesRepository;

    /// <summary>
    /// Получение случайных координат (широта и долгота)
    /// </summary>
    /// <remarks>Количество не должно быть меньше 1</remarks>
    /// <param name="count">Количество необходимых координат</param>

    // GET: api/coordinates?count=<int>
    [HttpGet("{count}", Name = nameof(GetCoordinates))] 
    [ProducesResponseType(200, Type = typeof(List<Coordinate>))]
    [ProducesResponseType(400)]
    public IActionResult GetCoordinates(int count)
    {
        if(count < 1)
        {
            return BadRequest("Количество координат должно быть больше 1");
        }

        List<Coordinate> randomCoordinates = _coordinatesRepository.GetCoordinates(count);

        return Ok(randomCoordinates);
    }

    /// <summary>
    /// Нахождение суммарной дистанции между заданных координат
    /// </summary>
    /// <remarks>Широта задается в диапазоне [-90;90]
    /// Долгота задается в диапазоне [-180;180]</remarks>
    /// <param name="coordinates">Массив содержащий пару значений координат</param>

    // POST: api/coordinates
    [HttpPost]
    [ProducesResponseType(200, Type = typeof(Distance))]
    public IActionResult FindFullCoordinateDistance(List<Coordinate> coordinates)
    {
        Distance distance = _coordinatesRepository.GetDistance(coordinates);
        return Ok(distance);
    }
}
