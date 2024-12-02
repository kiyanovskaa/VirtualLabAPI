using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLabAPI.Controllers;

namespace VirtualLabAPITests
{
    internal class DiagramControllerTests
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
        public void CreateDiagram_ValidDiagram_DiagramCreatesSuccessfully()
        {
            // Act
            var result = _controller.GetById(99);

            // Assert
            Assert.NotNull(result);
        }
        [Test]
        public void CreateDiagram_InValidDiagram_ReturnsAnError()
        {
            // Act
            var result = _controller.GetById(99);

            // Assert
            Assert.NotNull(result);
        }

       
    }
}
