using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLabAPI.Models;

namespace VirtualLabAPITests
{
    [TestFixture]
    internal class ClassTests
    {
        [Test]
        public void Class_NameProperty_SetsAndGetsValue()
        {
            // Arrange
            var classObj = new Class();

            // Act
            classObj.Name = "TestClass";

            // Assert
            Assert.AreEqual("TestClass", classObj.Name);
        }

        [Test]
        public void Class_AttributesProperty_InitializesAsNull()
        {
            // Arrange
            var classObj = new Class();

            // Assert
            Assert.IsNull(classObj.attributes);
        }

        [Test]
        public void Class_MethodsProperty_InitializesAsNull()
        {
            // Arrange
            var classObj = new Class();

            // Assert
            Assert.IsNull(classObj.methods);
        }
        [Test]
        public void Class_RelatedClassesProperty_InitializesAsNull()
        {
            // Arrange
            var classObj = new Class();

            // Assert
            Assert.IsNull(classObj.relatedClasses);
        }

        [Test]
        public void Class_AddAttributeToAttributes_ListContainsAddedAttribute()
        {
            // Arrange
            var classObj = new Class { attributes = new List<string>() };

            // Act
            classObj.attributes.Add("TestAttribute");

            // Assert
            Assert.Contains("TestAttribute", classObj.attributes);
        }
        [Test]
        public void Class_AddMethodToMethods_ListContainsAddedMethod()
        {
            // Arrange
            var classObj = new Class { methods = new List<string>() };

            // Act
            classObj.methods.Add("TestMethod");

            // Assert
            Assert.Contains("TestMethod", classObj.methods);
        }

        [Test]
        public void Class_AddRelatedClassToRelatedClasses_ListContainsAddedDictionary()
        {
            // Arrange
            var classObj = new Class { relatedClasses = new List<Dictionary<string, string>>() };
            var relatedClass = new Dictionary<string, string> { { "key", "value" } };

            // Act
            classObj.relatedClasses.Add(relatedClass);

            // Assert
            Assert.Contains(relatedClass, classObj.relatedClasses);
        }
        [Test]
        public void Class_MultipleAttributes_CorrectlyStoredInList()
        {
            // Arrange
            var classObj = new Class { attributes = new List<string>() };
            var attributes = new List<string> { "attr1", "attr2", "attr3" };

            // Act
            classObj.attributes.AddRange(attributes);

            // Assert
            Assert.AreEqual(3, classObj.attributes.Count);
            Assert.AreEqual("attr1", classObj.attributes[0]);
            Assert.AreEqual("attr2", classObj.attributes[1]);
            Assert.AreEqual("attr3", classObj.attributes[2]);
        }
        [Test]
        public void Class_MultipleMethods_CorrectlyStoredInList()
        {
            // Arrange
            var classObj = new Class { methods = new List<string>() };
            var methods = new List<string> { "method1", "method2", "method3" };

            // Act
            classObj.methods.AddRange(methods);

            // Assert
            Assert.AreEqual(3, classObj.methods.Count);
            Assert.AreEqual("method1", classObj.methods[0]);
            Assert.AreEqual("method2", classObj.methods[1]);
            Assert.AreEqual("method3", classObj.methods[2]);
        }
        [Test]
        public void Class_MultipleRelatedClasses_CorrectlyStoredInList()
        {
            // Arrange
            var classObj = new Class { relatedClasses = new List<Dictionary<string, string>>() };
            var relatedClass1 = new Dictionary<string, string> { { "key1", "value1" } };
            var relatedClass2 = new Dictionary<string, string> { { "key2", "value2" } };

            // Act
            classObj.relatedClasses.Add(relatedClass1);
            classObj.relatedClasses.Add(relatedClass2);

            // Assert
            Assert.AreEqual(2, classObj.relatedClasses.Count);
            Assert.AreEqual(relatedClass1, classObj.relatedClasses[0]);
            Assert.AreEqual(relatedClass2, classObj.relatedClasses[1]);
        }
    }
}
