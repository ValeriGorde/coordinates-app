using System.ComponentModel.DataAnnotations;

namespace Coordinates.API.DAL.Models
{
    /// <summary>
    /// Класс значений координат - широта и длина
    /// </summary>
    public class Coordinate
    {
        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Range(-180, 180)]
        public double Longitude { get; set; }
    }
}
