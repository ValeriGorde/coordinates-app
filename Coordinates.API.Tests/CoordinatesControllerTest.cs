using Coordinates.API.DAL.Models;
using Coordinates.API.DAL.Repositories;
using Coordinates.API.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Sdk;

namespace Coordinates.API.Tests
{
    public class CoordinatesControllerTest
    {
        private readonly CoordinatesController _controller;
        private readonly ICoordinatesRepository _coordinatesRepository;

        public CoordinatesControllerTest()
        {
            _coordinatesRepository = new CoordinatesRepository();
            _controller = new CoordinatesController(_coordinatesRepository);
        }

        [Fact]
        public void GetCoordinates_WithMoreThanOneCount_ReturnsOkResult()
        {
            // Arrange
            int count = 3;

            // Act
            IActionResult result = _controller.GetCoordinates(count);

            // Assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public void GetCoordinates_WithLessThanOneCount_ReturnsBadResult()
        {
            // Arrange
            int count = 0;

            // Act
            IActionResult result = _controller.GetCoordinates(count);

            // Assert];
            Assert.IsType<BadRequestObjectResult>(result as BadRequestObjectResult);
        }

        [Fact]
        public void GetDistance_WithNotEmptyListCoordinates_ReturnsOkResult()
        {
            // Arrange
            Distance expectedDistance = new()
            {
                Metres = 3937.089,
                Miles = 2.446
            };

            // Act
            var result = _controller.FindFullCoordinateDistance(GetTestCoordinates()) as OkObjectResult;


            // Assert
            var actualDistance = result.Value as Distance;
            Assert.Equal(expectedDistance.Metres, actualDistance.Metres);
            Assert.Equal(expectedDistance.Miles, actualDistance.Miles);
        }

        private List<Coordinate> GetTestCoordinates()
        {            
            return new List<Coordinate>()
            {
                new Coordinate{ Latitude = 60.021158, Longitude = 30.321135 },
                new Coordinate{ Latitude = 60.024157, Longitude = 30.323133 },
                new Coordinate{ Latitude = 60.051155, Longitude = 30.341132 },
            };
        }

        [Fact]
        public void GetDistance_WithEmptyListCoordinates_ReturnsNullResult()
        {
            // Arrange
            Distance expectedDistance = new()
            {
                Metres = 0.0,
                Miles = 0.0
            };

            List<Coordinate> emptyList = new();

            // Act
            var result = _controller.FindFullCoordinateDistance(emptyList) as OkObjectResult;
            

            // Assert
            var actualDistance = result.Value as Distance;
            Assert.Equal(expectedDistance.Metres, actualDistance.Metres);
            Assert.Equal(expectedDistance.Miles, actualDistance.Miles);
        }
    }
}