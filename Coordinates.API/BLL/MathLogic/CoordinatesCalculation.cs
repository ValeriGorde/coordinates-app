namespace Coordinates.API.BLL.MathReseach;

public static class CoordinatesCalculation
{
    private const double EARTH_RADIUS = 6371000d;
    private const double MILE_VALUE = 0.00062137d;

    public static double GetRandomCoordinate(int minValue, int maxValue)
    {
        Random randomNum = new();
        double coordinate = randomNum.NextDouble() * (maxValue - minValue) + minValue;

        return Math.Round(coordinate, 6);
    }

    public static double ConvertToRadians(double degreeValue)
    {
        return Math.PI / 180 * degreeValue;
    }

    public static double ConvertToMiles(double meterValue)
    {
        return meterValue * MILE_VALUE;
    }

    /// <summary>
    /// Нахождение расстояния между двумя координатами по формуле Гаверсинуса
    /// </summary>
    /// <returns>Расстояние в метрах</returns>
    public static double GetHaversineDistance(Coordinate firstCoordinate, Coordinate secondCoordinate)
    {
        double firstLatitudeToRadians = ConvertToRadians(firstCoordinate.Latitude);
        double secondLatitudeToRadians = ConvertToRadians(secondCoordinate.Latitude);

        double latitudeDifference = ConvertToRadians(secondCoordinate.Latitude - firstCoordinate.Latitude);
        double longitudeDifference = ConvertToRadians(secondCoordinate.Longitude - firstCoordinate.Longitude);

        double rootExpression = Math.Pow(Math.Sin(latitudeDifference / 2), 2) + Math.Cos(firstLatitudeToRadians) *
            Math.Cos(secondLatitudeToRadians) * Math.Pow(Math.Sin(longitudeDifference / 2), 2);

        double finalDistant = 2 * EARTH_RADIUS * Math.Asin(Math.Sqrt(rootExpression));

        return finalDistant;
    }

    /// <summary>
    /// Получение суммарного расстояния между всеми точками
    /// </summary>
    public static Distance GetFullDistance(List<Coordinate> coordinates)
    {
        Distance fullDistance = new();

        double metersDistant = 0d;

        for (int i = 0; i < coordinates.Count - 1; i++)
        {
            metersDistant += GetHaversineDistance(coordinates[i], coordinates[i + 1]);
        }

        fullDistance.Metres = Math.Round(metersDistant, 3);
        fullDistance.Miles = Math.Round(ConvertToMiles(metersDistant), 3);

        return fullDistance;
    }

}
