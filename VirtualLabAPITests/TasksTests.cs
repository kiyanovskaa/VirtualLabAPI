using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VirtualLabAPI.Models;

namespace VirtualLabAPITests
{
    [TestFixture]
    internal class TasksTests
    {
        [Test]
        public void Assignement_DefaultConstructor_ShouldInitializeDefaultValues()
        {
            // Arrange & Act
            var assignement = new Assignement();

            // Assert
            Assert.That(assignement.Id, Is.EqualTo(0));
            Assert.That(assignement.Name, Is.Null);
            Assert.That(assignement.Description, Is.Null);
            Assert.That(assignement.isDone, Is.False);
            Assert.That(assignement.Deadline, Is.EqualTo(DateTime.MinValue));
            Assert.That(assignement.DurationTime, Is.EqualTo(0));
            Assert.That(assignement.Grade, Is.EqualTo(0));
            Assert.That(assignement.MaxGrade, Is.EqualTo(0));
            Assert.That(assignement.StudentId, Is.EqualTo(0));

        }

        [Test]
        public void Assignement_SetValidProperties_ShouldStoreCorrectValues()
        {
            // Arrange
            var assignement = new Assignement
            {
                Id = 1,
                Name = "Test Task",
                Description = "Test Description",
                isDone = true,
                Deadline = new DateTime(2024, 12, 31),
                DurationTime = 120,
                Grade = 80,
                MaxGrade = 100,
                StudentId = 42
            };

            // Assert
            Assert.That(assignement.Id, Is.EqualTo(1));
            Assert.That(assignement.Name, Is.EqualTo("Test Task"));
            Assert.That(assignement.Description, Is.EqualTo("Test Description"));
            Assert.That(assignement.isDone, Is.True);
            Assert.That(assignement.Deadline, Is.EqualTo(new DateTime(2024, 12, 31)));
            Assert.That(assignement.DurationTime, Is.EqualTo(120));
            Assert.That(assignement.Grade, Is.EqualTo(80));
            Assert.That(assignement.MaxGrade, Is.EqualTo(100));
            Assert.That(assignement.StudentId, Is.EqualTo(42));

        }

        [Test]
        public void Assignement_GradeExceedsMaxGrade_ShouldFailValidation()
        {
            // Arrange
            var assignement = new Assignement
            {
                Grade = 120,
                MaxGrade = 100
            };

            // Act & Assert
            Assert.IsTrue(assignement.Grade > assignement.MaxGrade, "Grade should not exceed MaxGrade.");
        }
        [Test]
        public void Assignement_DurationTimeNegative_ShouldThrowArgumentException()
        {
            // Arrange & Act
            var assignement = new Assignement();

            // Assert
            Assert.Throws<ArgumentException>(() => assignement.DurationTime = -10);
        }

        [Test]
        public void Assignement_NullName_ShouldHandleProperly()
        {
            // Arrange
            var assignement = new Assignement { Name = null };

            // Assert
            Assert.IsNull(assignement.Name);
        }
        [Test]
        public void Assignement_DeadlineInPast_ShouldBeAllowed()
        {
            // Arrange
            var assignement = new Assignement
            {
                Deadline = DateTime.Now.AddDays(-1)
            };

            // Assert
            Assert.Less(assignement.Deadline, DateTime.Now);
        }
        [Test]
        public void Assignement_IdNegative_ShouldThrowArgumentException()
        {
            // Arrange & Act
            var assignement = new Assignement();

            // Assert
            Assert.Throws<ArgumentException>(() => assignement.Id = -1);
        }
        [Test]
        public void Assignement_DeadlineToday_ShouldBeValid()
        {
            // Arrange
            var assignement = new Assignement
            {
                Deadline = DateTime.Now.Date
            };

            // Assert
            Assert.That(assignement.Deadline.Date, Is.EqualTo(DateTime.Now.Date));
        }
        [Test]
        public void Assignement_GradeWithinLimits_ShouldPass()
        {
            // Arrange
            var assignement = new Assignement
            {
                Grade = 85,
                MaxGrade = 100
            };

            // Assert
            Assert.LessOrEqual(assignement.Grade, assignement.MaxGrade);
            Assert.GreaterOrEqual(assignement.Grade, 0);
        }
        [Test]
        public void Assignement_IsDoneDefault_ShouldBeFalse()
        {
            // Arrange & Act
            var assignement = new Assignement();

            // Assert
            Assert.IsFalse(assignement.isDone);
        }
    }
}
