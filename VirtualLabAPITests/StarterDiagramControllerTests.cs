using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLabAPI.Controllers;
using VirtualLabAPI.Handler;
using VirtualLabAPI.Models;

namespace VirtualLabAPITests
{
    internal class StarterDiagramControllerTests
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
        public void GetById_ValidId_ReturnAValidObject()
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


    }
    }
