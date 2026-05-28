using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using HairSalonApp.Services;
using HairSalonApp.Data;
using HairSalonApp.Models;

namespace HairSalonApp.Tests
{
    [TestClass]
    public class ReportServiceTests
    {
        private Mock<ReportRepository> _repoMock = null!;
        private ReportService _service = null!;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<ReportRepository>();
            _service = new ReportService(_repoMock.Object);
        }

        [TestMethod]
        public void GetTotalRevenue_ShouldReturnValue()
        {
            // Arrange
            _repoMock.Setup(r => r.GetTotalRevenue())
                .Returns(100m);

            // Act
            var result = _service.GetTotalRevenue();

            // Assert
            Assert.AreEqual(100m, result);
        }

        [TestMethod]
        public void GetAppointmentsByDate_ShouldReturnList()
        {
            // Arrange
            _repoMock.Setup(r => r.GetAppointmentsByDate())
                .Returns(new List<AppointmentsByDateReport>());

            // Act
            var result = _service.GetAppointmentsByDate();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result?.Count ?? 0);
        }

        [TestMethod]
        public void GetAppointmentsByEmployee_ShouldReturnList()
        {
            // Arrange
            _repoMock.Setup(r => r.GetAppointmentsByEmployee())
                .Returns(new List<EmployeeAppointmentsReport>());

            // Act
            var result = _service.GetAppointmentsByEmployee();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result?.Count ?? 0);
        }

        [TestMethod]
        public void GetPopularServices_ShouldReturnList()
        {
            // Arrange
            _repoMock.Setup(r => r.GetPopularServices())
                .Returns(new List<ServiceUsageReport>());

            // Act
            var result = _service.GetPopularServices();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result?.Count ?? 0);
        }

        [TestMethod]
        public void GetRevenueByService_ShouldReturnList()
        {
            // Arrange
            _repoMock.Setup(r => r.GetRevenueByService())
                .Returns(new List<RevenueByServiceReport>());

            // Act
            var result = _service.GetRevenueByService();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result?.Count ?? 0);
        }
    }
}
