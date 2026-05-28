using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HairSalonApp.Services;
using HairSalonApp.Data;
using HairSalonApp.Models;
using HairSalonApp.Helpers;

namespace HairSalonApp.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<UserRepository> _repoMock = null!;
        private UserService _service = null!;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<UserRepository>();
            _service = new UserService(_repoMock.Object);
        }

        [TestMethod]
        public void Login_ShouldFail_WhenUsernameOrPasswordEmpty()
        {
            // Act
            var result = _service.Login("", "");

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Παρακαλώ συμπληρώστε το Όνομα Χρήστη και τον Κωδικό.", result.ErrorMessage);
        }

        [TestMethod]
        public void Login_ShouldFail_WhenUserNotFound()
        {
            // Arrange
            _repoMock.Setup(r => r.GetByUsername("admin"))
                .Returns((User?)null);

            // Act
            var result = _service.Login("admin", "123");

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Λάθος όνομα χρήστη.", result.ErrorMessage);
        }

        [TestMethod]
        public void Login_ShouldFail_WhenPasswordIncorrect()
        {
            // Arrange
            var user = new User
            {
                Username = "admin",
                Password = BCrypt.Net.BCrypt.HashPassword("correct")
            };

            _repoMock.Setup(r => r.GetByUsername("admin"))
                .Returns(user);

            // Act
            var result = _service.Login("admin", "wrong");

            // Assert
            Assert.IsFalse(result.Success);
        }
    }
}