using Coordinates.API.DAL.Models;

namespace Coordinates.API.DAL.Repositories;

public interface ICoordinatesRepository
{
    public List<Coordinate> GetCoordinates(int quantity);
    Distance GetDistance(List<Coordinate> coordinates);

}
