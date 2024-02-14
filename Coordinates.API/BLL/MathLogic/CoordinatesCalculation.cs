using Coordinates.API.DAL.Models;

namespace Coordinates.API.BLL.MathReseach
{
    public static class CoordinatesCalculation
    {
        private const double EARTH_RADIUS = 6371000d;
        private const double MILE_VALUE = 0.00062137d;

        public static double GetRandomCoordinate(int minValue, int maxValue)
        {
            Random randomNum = new();
            return Math.Round(randomNum.NextDouble() * (maxValue - minValue) + minValue, 6);
        }

        public static double ConvertToRadians(double degreeValue)
        {
            return Math.PI/180 * degreeValue;
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
            double latitudeDifference = ConvertToRadians(secondCoordinate.Latitude - firstCoordinate.Latitude);
            double longitudeDifference = ConvertToRadians(secondCoordinate.Longitude - firstCoordinate.Longitude);

            double rootExpression = Math.Pow(Math.Sin(latitudeDifference / 2), 2) + Math.Cos(firstCoordinate.Latitude) *
                Math.Cos(secondCoordinate.Latitude) * Math.Pow(Math.Sin(longitudeDifference / 2), 2);

            double finalDistant = 2*EARTH_RADIUS*Math.Asin(Math.Sqrt(rootExpression));

            return finalDistant;
        }

        /// <summary>
        /// Получение общего расстояния между всеми точками
        /// </summary>
        public static Distance GetFullDistance(List<Coordinate> coordinates)
        {
            Distance fullDistance = new();

            for(int i = 0; i < coordinates.Count - 1; i++)
            {
                fullDistance.Metres += GetHaversineDistance(coordinates[i], coordinates[i + 1]);
            }

            fullDistance.Miles = ConvertToMiles(fullDistance.Metres);

            return fullDistance;
        }

    }
}
