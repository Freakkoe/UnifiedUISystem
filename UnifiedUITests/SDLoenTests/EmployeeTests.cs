using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDLoenSystem.Data;
using SDLoenSystem.Models;
using System;
using System.Linq;

namespace UnifiedUITests.SDLoenTests
{
    [TestClass] // Marks this class as containing unit tests
    public class EmployeeInfoCRUDTests
    {
        private SDLOENDbContext _context; // Private field to hold the DbContext for interaction with the database during tests

        // Test initialization setup method, runs before each test
        [TestInitialize]
        public void TestInitialize()
        {
            // In-memory database setup: creating a new, unique database for each test run
            var options = new DbContextOptionsBuilder<SDLOENDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Generate a new GUID to create a unique database
                .Options;

            _context = new SDLOENDbContext(options); // Assigning the context to the in-memory database with unique options

            // Ensures that the database is empty and created fresh for each test
            _context.Database.EnsureDeleted(); // Deletes any existing database if present (ensures isolation between tests)
            _context.Database.EnsureCreated(); // Creates the database schema based on models (ensures a fresh setup)
        }

        // Test method to verify that an employee is added to the database
        [TestMethod] // TestMethod attribute makes this a test case
        public void CreateEmployee_ShouldAddToDatabase()
        {
            // Arrange: Create a new EmployeeInfo instance with test data
            var employee = new EmployeeInfo
            {
                EmploymentDate = "2024-01-01", // Date of employment
                CPRNumber = "1234567890", // CPR number (unique identifier for the employee)
                FirstName = "John", // First name of the employee
                LastName = "Doe", // Last name of the employee
                Address = "123 Street", // Home address of the employee
                Position = "Developer", // Job position
                WorkHours = 37, // Work hours per week
                Institution = "Tech Department", // Institution or company department
                JobType = "Full-time", // Job type (full-time, part-time)
                Department = "IT", // Department where the employee works
                AuthorizationRequirement = "None", // Authorization requirement (could be security level or clearance)
                PhoneWork = "12345678", // Work phone number
                PhonePrivate = "87654321", // Private phone number
                EmailWork = "john.doe@work.com", // Work email address
                EmailPrivate = "john.doe@gmail.com", // Private email address
                StartDate = DateTime.Now, // Start date of employment
                EndDate = DateTime.Now.AddYears(1), // End date of employment (1 year contract)
                LastUpdated = DateTime.Now, // Last updated timestamp for the record
                CreationDate = DateTime.Now // Record creation timestamp
            };

            // Act: Add the new employee to the context and save changes
            _context.EmployeeInfos.Add(employee);
            _context.SaveChanges(); // Save the changes to the in-memory database

            // Assert: Verify that the employee was added to the database
            Assert.AreEqual(1, _context.EmployeeInfos.Count(), "Number of employees in the database is incorrect."); // Ensure that one employee was added
            Assert.AreEqual("John", _context.EmployeeInfos.First().FirstName); // Check that the first name matches the expected value
        }

        // Test method to verify that an employee can be read (retrieved) from the database
        [TestMethod]
        public void ReadEmployee_ShouldRetrieveFromDatabase()
        {
            // Arrange: Set up a new employee and save it to the database
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

            // Act: Retrieve the employee by their first name
            var retrievedEmployee = _context.EmployeeInfos.FirstOrDefault(e => e.FirstName == "John");

            // Assert: Ensure the retrieved employee is not null and matches expected values
            Assert.IsNotNull(retrievedEmployee, "Employee was not found in the database."); // Ensure the employee exists
            Assert.AreEqual("123 Street", retrievedEmployee.Address); // Ensure the address is correct
        }

        // Test method to verify that an existing employee's data can be updated
        [TestMethod]
        public void UpdateEmployee_ShouldModifyExistingRecord()
        {
            // Arrange: Create and save a new employee
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

            // Act: Retrieve the employee and update their position
            var existingEmployee = _context.EmployeeInfos.First();
            existingEmployee.Position = "Senior Developer"; // Change the position
            _context.SaveChanges(); // Save the changes to the database

            // Assert: Ensure the position was updated correctly
            Assert.AreEqual("Senior Developer", _context.EmployeeInfos.First().Position); // Check if the position was updated
        }

        // Test method to verify that an employee can be deleted
        [TestMethod]
        public void DeleteEmployee_ShouldRemoveFromDatabase()
        {
            // Arrange: Create and save a new employee
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

            // Act: Retrieve and delete the employee from the database
            var existingEmployee = _context.EmployeeInfos.First();
            _context.EmployeeInfos.Remove(existingEmployee); // Remove the employee from the context
            _context.SaveChanges(); // Save the changes to the database

            // Assert: Verify that the employee was deleted
            Assert.AreEqual(0, _context.EmployeeInfos.Count(), "Database should be empty after deletion."); // Ensure the employee was deleted
        }

        // Test cleanup after each test method, ensuring resources are released
        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose(); // Dispose of the context to release in-memory database resources
        }
    }
}
