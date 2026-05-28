using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalonApp.Data;
using HairSalonApp.Models;

namespace HairSalonApp.Tests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        private EmployeeRepository _repo = null!;

        [TestInitialize]
        public void Setup()
        {
            _repo = new EmployeeRepository();
        }

        [TestMethod]
        public void GetAll_ReturnsList()
        {
            var result = _repo.GetAll();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 0);
        }

        [TestMethod]
        public void Insert_ShouldReturnValidId()
        {
            var employee = new Employee
            {
                FirstName = "Test",
                LastName = "User",
                Phone = "6900000000",
                Specialty = "Test"
            };

            int id = _repo.Insert(employee);

            Assert.IsTrue(id > 0, $"Insert failed. Returned id = {id}");
        }

        [TestMethod]
        public void GetById_ShouldReturnEmployee_WhenExists()
        {
            var employee = new Employee
            {
                FirstName = "Test2",
                LastName = "User2",
                Phone = "6900000001",
                Specialty = "Test"
            };

            int id = _repo.Insert(employee);

            var result = _repo.GetById(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [TestMethod]
        public void Delete_ShouldReturnTrue_WhenEmployeeExists()
        {
            var employee = new Employee
            {
                FirstName = "Delete",
                LastName = "Test",
                Phone = "6900000002",
                Specialty = "Test"
            };

            int id = _repo.Insert(employee);

            var result = _repo.Delete(id);

            Assert.IsTrue(result);
        }
    }
}
