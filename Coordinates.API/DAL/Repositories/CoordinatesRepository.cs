using Coordinates.API.BLL.MathReseach;
using Coordinates.API.DAL.Models;

namespace Coordinates.API.DAL.Repositories;

public class CoordinatesRepository : ICoordinatesRepository
{
    private const int MIN_LATITUDE = -90;
    private const int MAX_LATITUDE = 90;
    private const int MIN_LONGITUDE = -180;
    private const int MAX_LONGITUDE = 180;

    public List<Coordinate> GetCoordinates(int quantity)
    {
        double latitude, longitude;

        List<Coordinate> coordinatesList = new();

        while(quantity > 0)
        {
            latitude = CoordinatesCalculation.GetRandomCoordinate(MIN_LATITUDE, MAX_LATITUDE);
            longitude = CoordinatesCalculation.GetRandomCoordinate(MIN_LONGITUDE, MAX_LONGITUDE);

            coordinatesList.Add(
                new Coordinate 
                { 
                    Latitude = latitude, 
                    Longitude = longitude 
                });

            quantity--;
        }

        return coordinatesList;
    }

    public Distance GetDistance(List<Coordinate> coordinates)
    {
        Distance distance = coordinates.Count < 2 ? new Distance { Metres = 0, Miles = 0 } : 
            CoordinatesCalculation.GetFullDistance(coordinates);

        return distance;
    }
}
