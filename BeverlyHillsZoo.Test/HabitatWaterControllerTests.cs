using BeverlyHillsZoo.Web.Controllers;
using BeverlyHillsZoo.Web.Data.Services;
using BeverlyHillsZoo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.ContentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeverlyHillsZoo.Test
{
    [TestClass]
    internal class HabitatWaterControllerTests
    {
        [TestMethod]
        public async Task TestIndex()
        {

            // Arrange

            // Create Mock of HabitatWaterService.
            var habitatMock = new Mock<HabitatWaterService>();

            // Create an instance of HabitatWaterController and inject the mock service.
            var controller = new HabitatWaterController(habitatMock.Object);

            // Act

            var result = await controller.Index();

            // Assert

            // Checks for Null.
            Assert.IsNotNull(result);

            // Checks if type is ViewResult.
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public async Task TestDetails()
        {

            // Arrange
            
            // Create a mock of HabitatWaterService
            var habitatWaterServiceMock = new Mock<HabitatWaterService>();
            
            // Create an instance of HabitatWater and inject the mock
            var controller = new HabitatWaterController(habitatWaterServiceMock.Object);


            // Sample 
            int habitatWaterId = 1;

            // Act

            var result = controller.Details(habitatWaterId);

            // Assert
            
            // Check for null
            Assert.IsNotNull(result);

            // Check for ViewResult
            Assert.IsInstanceOfType(result,typeof(ViewResult));
             

        }
        [TestMethod]
        public async Task TestCreate()
        { 
        
        // Arrange 
        
        // Create mock of HabitatService
        var habitatService = new Mock<HabitatWaterService>();

        // Create an instance of the HabitatWaterController and inject the mock
        var controller = new HabitatWaterController(habitatService.Object);

            // Act

            var result = controller.Create();

            // Assert

            // Check for Null
            Assert.IsNotNull(result);

            // Check for ViewResult
            Assert.IsInstanceOfType(result, typeof(ViewResult));


        
        }
        [TestMethod]
        public async Task TestEdit()

        {

            // Arrange

            // Create a Mock of HabitatWaterService
            var habitatService = new Mock<HabitatWaterService>();

            // Create an instance of HabitatWater and inject the mock
            var controller = new HabitatWaterController(habitatService.Object);

            // Act

            // Assume edit on item with Id 1
            var result = controller.Edit(1);
        
            // Assert 

            // Check for null
            Assert.IsNotNull(result);

            // Check for type ViewResult
            Assert.IsInstanceOfType(result, typeof(ViewResult));


        }
        [TestMethod]
        public async Task TestEdit_Post()
        {

            // Arrange

            // Create a mock

            var habitatService = new Mock<HabitatWaterService>();

            // Create instance and inject the mock

            var controller = new HabitatWaterController(habitatService.Object);
            // Create a HabitatWater model to simulate the data
            var habitatWaterModel = new HabitatWater
            {
                Id = 1,
                DivingDepth = 1,
                Name = "Generic name",
                IsDeleted = false,
            };
            // Act

            var result = controller.Edit(1, habitatWaterModel);

            // Assert

            // Check for null

            Assert.IsNotNull(result);

            // Check for ViewResult

            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }
        [TestMethod]
        public async Task TestDelete()
        {

            // Arrange 


            // Create a mock

            var habitatService = new Mock<HabitatWaterService>();

            // Create instance and inject the mock

            var controller = new HabitatWaterController(habitatService.Object);
            // Create a sample
            var habitatWaterModel = new HabitatWater
            {
                Id = 1,
                DivingDepth = 1,
                Name = "Generic Name",
                IsDeleted = false
            };

            // Set up mock service to return the sample model when GetById is called
            habitatService.Setup(s => s.GetHabitatWaterById(It.IsAny<int>()))
                .ReturnsAsync(habitatWaterModel);

            // Act
            var result = await controller.Delete(1);

            // Check for null
            Assert.IsNotNull(result);

            // Check for ViewResult
            Assert.IsInstanceOfType(result,typeof(ViewResult));
        }
        [TestMethod]
        public async Task TestDeleteConfirmed()
        {

            // Arrange 


            // Create a mock

            var habitatService = new Mock<HabitatWaterService>();

            // Create instance and inject the mock

            var controller = new HabitatWaterController(habitatService.Object);
            // Create a sample
            var habitatWaterModel = new HabitatWater
            {
                Id = 1,
                DivingDepth = 1,
                Name = "Generic Name",
                IsDeleted = false
            };

            // Set up mock service to return the sample model when GetById is called
            habitatService.Setup(s => s.GetHabitatWaterById(It.IsAny<int>()))
                .ReturnsAsync(habitatWaterModel);

            // Act
            var result = await controller.Delete(1);

            // Check for null
            Assert.IsNotNull(result);

            // Check for ViewResult
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            // Check if name is Index
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }
    }
}
