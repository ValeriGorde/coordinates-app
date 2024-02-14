using System.ComponentModel.DataAnnotations;

namespace Coordinates.API.DAL.Models;
public class Coordinate
{
    /// <summary>
    /// Широта
    /// </summary>
    [Required(ErrorMessage = "Необходимо указать Широту")]
    [Range(-90, 90, ErrorMessage = "Широта должна находиться в диапазоне [-90; 90]")]
    public double Latitude { get; set; }

    /// <summary>
    /// Долгота
    /// </summary>
    [Required(ErrorMessage = "Небходимо указать Долготу")]
    [Range(-180, 180, ErrorMessage = "Долгота должна находиться в диапазоне [-180; 180]")]
    public double Longitude { get; set; }
}
