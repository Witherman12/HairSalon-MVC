using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalonApp.Data;
using HairSalonApp.Models;

namespace HairSalonApp.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private UserRepository _repo = null!;

        [TestInitialize]
        public void Setup()
        {
            _repo = new UserRepository();
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
            var user = new User
            {
                Username = "test_user",
                Password = "test123",
                Role = "Admin"
            };

            int id = _repo.Insert(user);

            Assert.IsTrue(id > 0, $"Insert failed. Returned id = {id}");
        }

        [TestMethod]
        public void GetById_ShouldReturnUser_WhenExists()
        {
            var user = new User
            {
                Username = "temp_user",
                Password = "temp123",
                Role = "User"
            };

            int id = _repo.Insert(user);

            var result = _repo.GetById(id);

            Assert.IsNotNull(result);
            Assert.AreEqual("temp_user", result.Username);
        }

        [TestMethod]
        public void Delete_ShouldReturnTrue_WhenUserExists()
        {
            var user = new User
            {
                Username = "delete_user",
                Password = "123",
                Role = "User"
            };

            int id = _repo.Insert(user);

            var result = _repo.Delete(id);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetByUsername_ShouldReturnUser_WhenExists()
        {
            var user = new User
            {
                Username = "login_user",
                Password = "hashed_or_plain",
                Role = "Admin"
            };

            _repo.Insert(user);

            var result = _repo.GetByUsername("login_user");

            Assert.IsNotNull(result);
            Assert.AreEqual("login_user", result.Username);
        }
    }
}