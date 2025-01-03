using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDLoenSystem.Data;
using SDLoenSystem.Models;
using System;
using System.Linq;

namespace UnifiedUITests.SDLoenTests
{
    [TestClass]
    public class EmployeeInfoCRUDTests
    {
        private SDLOENDbContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            // In-memory database setup
            var options = new DbContextOptionsBuilder<SDLOENDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new SDLOENDbContext(options);

            // Clear database
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void CreateEmployee_ShouldAddToDatabase()
        {
            // Arrange
            var employee = new EmployeeInfo
            {
                EmploymentDate = "2024-01-01",
                CPRNumber = "1234567890",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                Position = "Developer",
                WorkHours = 37,
                Institution = "Tech Department",
                JobType = "Full-time",
                Department = "IT",
                AuthorizationRequirement = "None",
                PhoneWork = "12345678",
                PhonePrivate = "87654321",
                EmailWork = "john.doe@work.com",
                EmailPrivate = "john.doe@gmail.com",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
                LastUpdated = DateTime.Now,
                CreationDate = DateTime.Now
            };

            // Act
            _context.EmployeeInfos.Add(employee);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(1, _context.EmployeeInfos.Count(), "Number of employees in the database is incorrect.");
            Assert.AreEqual("John", _context.EmployeeInfos.First().FirstName);
        }

        [TestMethod]
        public void ReadEmployee_ShouldRetrieveFromDatabase()
        {
            // Arrange
            var employee = new EmployeeInfo
            {
                EmploymentDate = "2024-01-01",
                CPRNumber = "1234567890",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                Position = "Developer",
                WorkHours = 37,
                Institution = "Tech Department",
                JobType = "Full-time",
                Department = "IT",
                AuthorizationRequirement = "None",
                PhoneWork = "12345678",
                PhonePrivate = "87654321",
                EmailWork = "john.doe@work.com",
                EmailPrivate = "john.doe@gmail.com",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
                LastUpdated = DateTime.Now,
                CreationDate = DateTime.Now
            };

            _context.EmployeeInfos.Add(employee);
            _context.SaveChanges();

            // Act
            var retrievedEmployee = _context.EmployeeInfos.FirstOrDefault(e => e.FirstName == "John");

            // Assert
            Assert.IsNotNull(retrievedEmployee, "Employee was not found in the database.");
            Assert.AreEqual("123 Street", retrievedEmployee.Address);
        }

        [TestMethod]
        public void UpdateEmployee_ShouldModifyExistingRecord()
        {
            // Arrange
            var employee = new EmployeeInfo
            {
                EmploymentDate = "2024-01-01",
                CPRNumber = "1234567890",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                Position = "Developer",
                WorkHours = 37,
                Institution = "Tech Department",
                JobType = "Full-time",
                Department = "IT",
                AuthorizationRequirement = "None",
                PhoneWork = "12345678",
                PhonePrivate = "87654321",
                EmailWork = "john.doe@work.com",
                EmailPrivate = "john.doe@gmail.com",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
                LastUpdated = DateTime.Now,
                CreationDate = DateTime.Now
            };

            _context.EmployeeInfos.Add(employee);
            _context.SaveChanges();

            // Act
            var existingEmployee = _context.EmployeeInfos.First();
            existingEmployee.Position = "Senior Developer";
            _context.SaveChanges();

            // Assert
            Assert.AreEqual("Senior Developer", _context.EmployeeInfos.First().Position);
        }

        [TestMethod]
        public void DeleteEmployee_ShouldRemoveFromDatabase()
        {
            // Arrange
            var employee = new EmployeeInfo
            {
                EmploymentDate = "2024-01-01",
                CPRNumber = "1234567890",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                Position = "Developer",
                WorkHours = 37,
                Institution = "Tech Department",
                JobType = "Full-time",
                Department = "IT",
                AuthorizationRequirement = "None",
                PhoneWork = "12345678",
                PhonePrivate = "87654321",
                EmailWork = "john.doe@work.com",
                EmailPrivate = "john.doe@gmail.com",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
                LastUpdated = DateTime.Now,
                CreationDate = DateTime.Now
            };

            _context.EmployeeInfos.Add(employee);
            _context.SaveChanges();

            // Act
            var existingEmployee = _context.EmployeeInfos.First();
            _context.EmployeeInfos.Remove(existingEmployee);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(0, _context.EmployeeInfos.Count(), "Database should be empty after deletion.");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose();
        }
    }
}
