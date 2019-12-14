using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCrossing;
using AnimalCrossing.Controllers;
using AnimalCrossing.Models;
using AnimalCrossing.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AnimalCrossingTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddWithTwoPositiveNumbers()
        {

            //Arrange - instan. classes
            TestServiceForAdd testService = new TestServiceForAdd();

            //Act - call the method to test
            int result = testService.Add(2,5);

            //Assert - Check if you get the right result back
            Assert.Equal(7, result);
        }

        [Fact]
        public void TestSpeciesIndex()
        {
            // Arrange
            var mockRepo = new Mock<ISpeciesRepository>();
            mockRepo.Setup(repo => repo.Get())
                .Returns(TestService.GetTestSpecies());
            var controller = new SpeciesController(mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Species>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());

        }

        
        [Fact]

        public void TestSpeciesCreatePost_ReturnsViewWithSpecies_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<ISpeciesRepository>();
            Species species = new Species();

            species.SpeciesId = 1;
            species.Name = "";
            species.Description = "Wildcats are wild";
            
            var controller = new SpeciesController(mockRepo.Object);
            controller.ModelState.AddModelError("Name", "Required");
            

            // Act
            var result = controller.Create(species);

            // Assert
            var ViewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Species>(
                ViewResult.ViewData.Model);
            Assert.IsType<Species>(model);

        }
        [Fact]
        public void CreatePost_SaveThroughRepository_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepo = new Mock<ISpeciesRepository>();
            mockRepo.Setup(repo => repo.Save(It.IsAny<Species>()))
            //.Returns(Task.CompletedTask)
            .Verifiable();
            var controller = new SpeciesController(mockRepo.Object);
            Species s = new Species()
            {
                Name = "Human",
                Description = "Don't listen to scientists"
            };

            // Act
            var result = controller.Create(s);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        }

        [Fact]
        public void TestCateDateIndex() {

            // Arrange
            var mockRepo = new Mock<ICatDateRepository>();
            mockRepo.Setup(repo => repo.Get())
                .Returns(TestService.GetCatDates());
            var controller = new CatDateController(mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CatDate>>(
                viewResult.ViewData.Model);
            Assert.Equal(1, model.Count());
        }

        [Fact]
        public void TestDeleteCatWorks_In_Controller()
        {
            //Arrange
            var catId = 1;
            var mockRepo = new Mock<IAnimalRepository>();
            var mockSpeciesRepo = new Mock<ISpeciesRepository>();
            mockRepo.Setup(repo => repo.Delete(catId)).Verifiable();
            var controller = new AnimalController(mockRepo.Object,mockSpeciesRepo.Object);

            //Act
            var result = controller.DeleteCat(catId);

            //Assert
            Assert.IsType<ViewResult>(result);
            mockRepo.Verify();

        }
    }
}
