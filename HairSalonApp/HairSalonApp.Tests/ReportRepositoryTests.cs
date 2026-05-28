using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalonApp.Data;
using System;

namespace HairSalonApp.Tests
{
    [TestClass]
    public class ReportRepositoryTests
    {
        private ReportRepository _repo = null!;

        [TestInitialize]
        public void Setup()
        {
            _repo = new ReportRepository();
        }

        [TestMethod]
        public void GetTotalRevenue_ShouldReturnNonNegative()
        {
            var result = _repo.GetTotalRevenue();

            Assert.IsTrue(result >= 0);
        }

        [TestMethod]
        public void GetAppointmentsByDate_ShouldReturnList()
        {
            var result = _repo.GetAppointmentsByDate();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 0);
        }

        [TestMethod]
        public void GetAppointmentsByDate_Filtered_ShouldReturnList()
        {
            var result = _repo.GetAppointmentsByDate(
                DateTime.Now.AddMonths(-1),
                DateTime.Now
            );

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAppointmentsByEmployee_ShouldReturnList()
        {
            var result = _repo.GetAppointmentsByEmployee();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 0);
        }

        [TestMethod]
        public void GetAppointmentsByEmployee_Filtered_ShouldReturnList()
        {
            var result = _repo.GetAppointmentsByEmployee(
                DateTime.Now.AddMonths(-1),
                DateTime.Now
            );

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetPopularServices_ShouldReturnList()
        {
            var result = _repo.GetPopularServices();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetRevenueByService_ShouldReturnList()
        {
            var result = _repo.GetRevenueByService();

            Assert.IsNotNull(result);
        }
    }
}
