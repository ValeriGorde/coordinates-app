using System.ComponentModel.DataAnnotations;

namespace Coordinates.API.DAL.Models;

/// <summary>
/// Класс значений координат - широта и длина
/// </summary>
public class Coordinate
{
    [Required(ErrorMessage = "Необходимо указать Широту")]
    [Range(-90, 90, ErrorMessage = "Широта должна находиться в диапазоне [-90; 90]")]
    public double Latitude { get; set; }

    [Required(ErrorMessage = "Небходимо указать Долготу")]
    [Range(-180, 180, ErrorMessage = "Долгота должна находиться в диапазоне [-180; 180]")]
    public double Longitude { get; set; }
}
