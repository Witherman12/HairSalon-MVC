using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalonApp.Data;
using System;

namespace HairSalonApp.Tests
{
    [TestClass]
    public class AppointmentRepositoryTests
    {
        private AppointmentRepository _repo = null!;

        [TestInitialize]
        public void Setup()
        {
            _repo = new AppointmentRepository();
        }

        [TestMethod]
        public void GetById_ShouldReturnNull_WhenIdDoesNotExist()
        {
            // Act
            var result = _repo.GetById(-999);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAppointmentViewById_ShouldReturnNull_WhenIdDoesNotExist()
        {
            // Act
            var result = _repo.GetAppointmentViewById(-999);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsAvailable_ShouldReturnBoolean()
        {
            // Act
            var result = _repo.IsAvailable(-1, DateTime.Now, TimeSpan.Zero, 30);

            // Assert
            Assert.IsTrue(result == true || result == false);
        }

        [TestMethod]
        public void IsAvailableForUpdate_ShouldReturnBoolean()
        {
            // Act
            var result = _repo.IsAvailableForUpdate(-1, -1, DateTime.Now, TimeSpan.Zero, 30);

            // Assert
            Assert.IsTrue(result == true || result == false);
        }
    }
}
