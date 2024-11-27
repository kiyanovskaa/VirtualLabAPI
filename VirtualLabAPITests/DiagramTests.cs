using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLabAPI.Models;

namespace VirtualLabAPITests
{
    [TestFixture]
    internal class DiagramTests
    {
        [Test]
        public void Diagram_IdProperty_SetsAndGetsValue()
        {
            // Arrange
            var diagram = new Diagram();

            // Act
            diagram.Id = 10;

            // Assert
            Assert.AreEqual(10, diagram.Id);
        }

        [Test]
        public void Diagram_ClassesProperty_InitializesAsEmptyList()
        {
            // Arrange
            var diagram = new Diagram();

            // Assert
            Assert.IsNotNull(diagram.classes);
            Assert.IsEmpty(diagram.classes);
        }
        [Test]
        public void Diagram_MultipleClasses_CorrectlyStoredInList()
        {
            // Arrange
            var diagram = new Diagram();
            var class1 = new Class { Name = "Class1" };
            var class2 = new Class { Name = "Class2" };

            // Act
            diagram.classes = new List<Class> { class1, class2 };

            // Assert
            Assert.AreEqual(2, diagram.classes.Count);
            Assert.AreEqual("Class1", diagram.classes[0].Name);
            Assert.AreEqual("Class2", diagram.classes[1].Name);
        }
        [Test]
        public void Diagram_EmptyDiagram_HasDefaultIdAndEmptyClasses()
        {
            // Arrange
            var diagram = new Diagram();

            // Assert
            Assert.AreEqual(0, diagram.Id);
            Assert.IsNotNull(diagram.classes);
            Assert.IsEmpty(diagram.classes);
        }
    }
}
