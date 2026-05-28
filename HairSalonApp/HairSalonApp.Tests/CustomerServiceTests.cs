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
    public class CustomerServiceTests
    {
        private Mock<CustomerRepository> _repoMock = null!;
        private CustomerService _service = null!;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<CustomerRepository>();
            _service = new CustomerService(_repoMock.Object);
        }

        [TestMethod]
        public void GetAllCustomers_ShouldReturnList()
        {
            // Arrange
            _repoMock.Setup(r => r.GetAll())
                .Returns(new List<Customer>());

            // Act
            var result = _service.GetAllCustomers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result?.Count ?? 0);
        }

        [TestMethod]
        public void SearchCustomers_ShouldReturnAll_WhenKeywordIsEmpty()
        {
            // Arrange
            _repoMock.Setup(r => r.GetAll())
                .Returns(new List<Customer>());

            // Act
            var result = _service.SearchCustomers("");

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SaveCustomer_ShouldFail_WhenFirstNameIsEmpty()
        {
            // Act
            var result = _service.SaveCustomer(0, "", "Papadopoulos", "6941234567", "test@test.com", "");

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Το Όνομα του πελάτη είναι υποχρεωτικό.", result.ErrorMessage);
        }

        [TestMethod]
        public void SaveCustomer_ShouldFail_WhenPhoneIsInvalid()
        {
            // Act
            var result = _service.SaveCustomer(0, "Nikos", "Papadopoulos", "123", "test@test.com", "");

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Το τηλέφωνο πρέπει να αποτελείται ακριβώς από 10 ψηφία.", result.ErrorMessage);
        }

        [TestMethod]
        public void DeleteCustomer_ShouldReturnSuccess_WhenRepositoryReturnsTrue()
        {
            // Arrange
            _repoMock.Setup(r => r.Delete(1)).Returns(true);

            // Act
            var result = _service.DeleteCustomer(1);

            // Assert
            Assert.IsTrue(result.Success);
        }
    }
}
