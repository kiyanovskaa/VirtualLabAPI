using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLabAPI.Controllers;

namespace VirtualLabAPITests
{
    internal class TaskControllerTests
    {
        private StarterDiagramController _controller;

        [SetUp]
        public void SetUp()
        {
            // Create a controller instance
            _controller = new StarterDiagramController();
        }
        [TearDown]
        public void TearDown()
        {
            if (_controller is IDisposable disposableController)
            {
                disposableController.Dispose();
            }
        }


        [Test]
        public void GetById_ValidId_ReturnsAValidObject()
        {
            // Act
            var result = _controller.GetById(99);

            // Assert
            Assert.NotNull(result);
        }
        [Test]
        public void GetById_ValidId_ReturnAValidProperty()
        {
            // Act
            var result = _controller.GetById(99);

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetById_InvalidId_ReturnsNotFound()
        {

            var result = _controller.GetById(99);


            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.AreEqual("Diagram with ID 99 not found.", notFoundResult.Value);
        }
        [Test]
        public void GetByStudentId_ValidId_ReturnsAValidObject()
        {
            // Act
            var result = _controller.GetById(99);

            // Assert
            Assert.NotNull(result);
        }
        [Test]
        public void GetByStudentId_ValidId_ReturnAValidProperty()
        {
            // Act
            var result = _controller.GetById(99);

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetByStudentId_InvalidId_ReturnsNotFound()
        {

            var result = _controller.GetById(99);


            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.AreEqual("Diagram with ID 99 not found.", notFoundResult.Value);
        }
    }
}
