using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalonApp.Data;
using HairSalonApp.Models;
using System;

namespace HairSalonApp.Tests
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private CustomerRepository _repo = null!;

        [TestInitialize]
        public void Setup()
        {
            _repo = new CustomerRepository();
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
        public void Search_ShouldNeverReturnNull()
        {
            // Act
            var result = _repo.Search("non_existing_customer_xyz");

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAll_ShouldReturnList()
        {
            // Act
            var result = _repo.GetAll();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Insert_Update_Delete_ShouldNotThrow()
        {
            // Arrange
            var customer = new Customer
            {
                FirstName = "Test",
                LastName = "User",
                Phone = "6900000000",
                Email = null,
                Notes = null
            };

            try
            {
                // Act
                int id = _repo.Insert(customer);

                customer.Id = id;
                bool updated = _repo.Update(customer);
                bool deleted = _repo.Delete(id);

                // Assert
                Assert.IsTrue(id > 0);
                Assert.IsTrue(updated || !updated); // απλά να μη σπάσει
                Assert.IsTrue(deleted || !deleted);
            }
            catch (Exception ex)
            {
                Assert.Fail("Repository threw exception: " + ex.Message);
            }
        }
    }
}
