using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using HairSalonApp.Services;
using HairSalonApp.Data;
using HairSalonApp.Models;
using HairSalonApp.Helpers;

namespace HairSalonApp.Tests
{
    [TestClass]
    public class EmployeeServiceTests
    {
        private Mock<EmployeeRepository> _repoMock = null!;
        private EmployeeService _service = null!;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<EmployeeRepository>();
            _service = new EmployeeService(_repoMock.Object);
        }

        [TestMethod]
        public void GetAllEmployees_ShouldReturnList()
        {
            // Arrange
            _repoMock.Setup(r => r.GetAll())
                .Returns(new List<Employee>());

            // Act
            var result = _service.GetAllEmployees();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result?.Count ?? 0);
        }

        [TestMethod]
        public void GetEmployeeById_ShouldReturnNull_WhenExceptionOccurs()
        {
            // Arrange
            _repoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .Throws(new System.Exception());

            // Act
            var result = _service.GetEmployeeById(1);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteEmployee_ShouldReturnSuccess_WhenRepositoryReturnsTrue()
        {
            // Arrange
            _repoMock.Setup(r => r.Delete(1)).Returns(true);

            // Act
            var result = _service.DeleteEmployee(1);

            // Assert
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void SaveEmployee_ShouldFail_WhenFirstNameIsEmpty()
        {
            // Act
            var result = _service.SaveEmployee(0, "", "Papadopoulos", "6912345678", "Barber");

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Το Όνομα του υπαλλήλου είναι υποχρεωτικό.", result.ErrorMessage);
        }

        [TestMethod]
        public void SaveEmployee_ShouldFail_WhenPhoneInvalid()
        {
            // Act
            var result = _service.SaveEmployee(0, "Nikos", "Papadopoulos", "123", "Barber");

            // Assert
            Assert.IsFalse(result.Success);
        }
    }
}