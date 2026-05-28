using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using HairSalonApp.Services;
using HairSalonApp.Data;
using HairSalonApp.Models;

namespace HairSalonApp.Tests
{
    [TestClass]
    public class AppointmentServiceTests
    {
        private Mock<AppointmentRepository> _repoMock = null!;
        private AppointmentService _service = null!;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<AppointmentRepository>();
            _service = new AppointmentService(_repoMock.Object);
        }

        [TestMethod]
        public void GetAllAppointments_ShouldReturnList()
        {
            // Arrange
            _repoMock.Setup(r => r.GetAll())
                .Returns(new List<AppointmentView>());

            // Act
            var result = _service.GetAllAppointments();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result?.Count ?? 0);
        }

        [TestMethod]
        public void AddAppointment_ShouldFail_WhenCustomerIsInvalid()
        {
            // Arrange
            var app = new Appointment
            {
                CustomerId = 0,
                EmployeeId = 1,
                ServiceId = 1,
                AppDate = DateTime.Today,
                AppTime = TimeSpan.FromHours(10)
            };

            // Act
            var result = _service.AddAppointment(app, 30);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Παρακαλώ επιλέξτε πελάτη.", result.ErrorMessage);
        }

        [TestMethod]
        public void AddAppointment_ShouldFail_WhenDurationIsInvalid()
        {
            // Arrange
            var app = new Appointment
            {
                CustomerId = 1,
                EmployeeId = 1,
                ServiceId = 1,
                AppDate = DateTime.Today,
                AppTime = TimeSpan.FromHours(10)
            };

            // Act
            var result = _service.AddAppointment(app, 0);

            // Assert
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void CancelAppointment_ShouldReturnSuccess_WhenRepositoryReturnsTrue()
        {
            // Arrange
            _repoMock.Setup(r => r.Cancel(1)).Returns(true);

            // Act
            var result = _service.CancelAppointment(1);

            // Assert
            Assert.IsTrue(result.Success);
        }
    }
}