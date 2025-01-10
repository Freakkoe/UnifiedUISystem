using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;

namespace UnifiedUITests.SofdCoreTests
{
    [TestClass]
    public class AccountCreationCRUDTests
    {
        private SofdCoreDbContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            // In-memory database setup
            var options = new DbContextOptionsBuilder<SofdCoreDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new SofdCoreDbContext(options);

            // Ensure a clean slate before each test
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void CreateAccount_ShouldAddToDatabase()
        {
            // Arrange
            var account = new AccountCreation
            {
                FirstName = "Jane",
                LastName = "Doe",
                Position = "Manager",
                JobType = "Full-time",
                StartDate = DateTime.Now,
                EndDate = null,
                EmployeeNumber = Guid.NewGuid().ToString(),
                WorkHours = 37.5m,
                CreationDate = DateTime.Now,
                LastUpdated = null
            };

            // Act
            _context.AccountCreation.Add(account);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(1, _context.AccountCreation.Count());
            Assert.AreEqual("Jane", _context.AccountCreation.First().FirstName);
        }

        [TestMethod]
        public void ReadAccount_ShouldRetrieveFromDatabase()
        {
            // Arrange
            var account = new AccountCreation
            {
                FirstName = "Jane",
                LastName = "Doe",
                Position = "Manager",
                JobType = "Full-time",
                StartDate = DateTime.Now,
                EmployeeNumber = Guid.NewGuid().ToString(),
                WorkHours = 37.5m,
                CreationDate = DateTime.Now
            };

            _context.AccountCreation.Add(account);
            _context.SaveChanges();

            // Act
            var retrievedAccount = _context.AccountCreation.FirstOrDefault(a => a.FirstName == "Jane");

            // Assert
            Assert.IsNotNull(retrievedAccount);
            Assert.AreEqual("Doe", retrievedAccount.LastName);
        }

        [TestMethod]
        public void UpdateAccount_ShouldModifyExistingRecord()
        {
            // Arrange
            var account = new AccountCreation
            {
                FirstName = "Jane",
                LastName = "Doe",
                Position = "Manager",
                JobType = "Full-time",
                StartDate = DateTime.Now,
                EmployeeNumber = Guid.NewGuid().ToString(),
                WorkHours = 37.5m,
                CreationDate = DateTime.Now
            };

            _context.AccountCreation.Add(account);
            _context.SaveChanges();

            // Act
            var existingAccount = _context.AccountCreation.First();
            existingAccount.Position = "Director";
            _context.SaveChanges();

            // Assert
            Assert.AreEqual("Director", _context.AccountCreation.First().Position);
        }

        [TestMethod]
        public void DeleteAccount_ShouldRemoveFromDatabase()
        {
            // Arrange
            var account = new AccountCreation
            {
                FirstName = "Jane",
                LastName = "Doe",
                Position = "Manager",
                JobType = "Full-time",
                StartDate = DateTime.Now,
                EmployeeNumber = Guid.NewGuid().ToString(),
                WorkHours = 37.5m,
                CreationDate = DateTime.Now
            };

            _context.AccountCreation.Add(account);
            _context.SaveChanges();

            // Act
            var existingAccount = _context.AccountCreation.First();
            _context.AccountCreation.Remove(existingAccount);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(0, _context.AccountCreation.Count());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose();
        }
    }
}

