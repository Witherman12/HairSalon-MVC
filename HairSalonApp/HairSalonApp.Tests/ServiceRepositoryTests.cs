using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalonApp.Data;
using HairSalonApp.Models;

namespace HairSalonApp.Tests
{
    [TestClass]
    public class ServiceRepositoryTests
    {
        private ServiceRepository _repo = null!;

        [TestInitialize]
        public void Setup()
        {
            _repo = new ServiceRepository();
        }

        [TestMethod]
        public void GetAll_ShouldReturnList()
        {
            var result = _repo.GetAll();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 0);
        }

        [TestMethod]
        public void Insert_ShouldReturnNewId()
        {
            var service = new Service
            {
                ServiceName = "Test Service",
                Price = 10,
                DurationMinutes = 30
            };

            var id = _repo.Insert(service);

            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void GetById_ShouldReturnService_WhenExists()
        {
            var service = new Service
            {
                ServiceName = "Temp Service",
                Price = 20,
                DurationMinutes = 45
            };

            int id = _repo.Insert(service);

            var result = _repo.GetById(id);

            Assert.IsNotNull(result);
            Assert.AreEqual("Temp Service", result.ServiceName);
        }

        [TestMethod]
        public void Update_ShouldReturnTrue_WhenValid()
        {
            var service = new Service
            {
                ServiceName = "Old Name",
                Price = 15,
                DurationMinutes = 20
            };

            int id = _repo.Insert(service);

            var updated = new Service
            {
                Id = id,
                ServiceName = "Updated Name",
                Price = 25,
                DurationMinutes = 40
            };

            var result = _repo.Update(updated);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Delete_ShouldReturnTrue_WhenExists()
        {
            var service = new Service
            {
                ServiceName = "Delete Me",
                Price = 5,
                DurationMinutes = 10
            };

            int id = _repo.Insert(service);

            var result = _repo.Delete(id);

            Assert.IsTrue(result);
        }
    }
}
