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
    public class ServiceServiceTests
    {
        private Mock<ServiceRepository> _repoMock = null!;
        private ServiceService _service = null!;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<ServiceRepository>();
            _service = new ServiceService(_repoMock.Object);
        }

        [TestMethod]
        public void GetAllServices_ShouldReturnList()
        {
            // Arrange
            _repoMock.Setup(r => r.GetAll())
                .Returns(new List<Service>());

            // Act
            var result = _service.GetAllServices();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result?.Count ?? 0);
        }

        [TestMethod]
        public void GetServiceById_ShouldReturnNull_WhenExceptionOccurs()
        {
            // Arrange
            _repoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .Throws(new System.Exception());

            // Act
            var result = _service.GetServiceById(1);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteService_ShouldReturnSuccess_WhenRepositoryReturnsTrue()
        {
            // Arrange
            _repoMock.Setup(r => r.Delete(1)).Returns(true);

            // Act
            var result = _service.DeleteService(1);

            // Assert
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void SaveService_ShouldFail_WhenNameIsEmpty()
        {
            // Act
            var result = _service.SaveService(0, "", 10m, 30);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Το όνομα της υπηρεσίας είναι υποχρεωτικό.", result.ErrorMessage);
        }

        [TestMethod]
        public void SaveService_ShouldFail_WhenPriceNegative()
        {
            // Act
            var result = _service.SaveService(0, "Haircut", -5m, 30);

            // Assert
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void SaveService_ShouldFail_WhenDurationInvalid()
        {
            // Act
            var result = _service.SaveService(0, "Haircut", 10m, 0);

            // Assert
            Assert.IsFalse(result.Success);
        }
    }
}
