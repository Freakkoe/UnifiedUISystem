using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using SofdCoreSystem.Data;
using SofdCoreSystem.Models;

namespace UnifiedUITests.SofdCoreTests
{
    [TestClass] // This attribute marks the class as containing unit tests
    public class AccountCreationCRUDTests
    {
        private SofdCoreDbContext _context; // Private field to hold the database context for interacting with the database

        // Test initialization method, runs before each individual test
        [TestInitialize]
        public void TestInitialize()
        {
            // In-memory database setup: Uses a unique database name to ensure tests do not interfere with each other
            var options = new DbContextOptionsBuilder<SofdCoreDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Uses a GUID to generate a unique database for each test run
                .Options;

            _context = new SofdCoreDbContext(options); // Assign the in-memory database context

            // Ensure that the database is fresh and empty before each test
            _context.Database.EnsureDeleted(); // Deletes any existing database if present (ensures isolation between tests)
            _context.Database.EnsureCreated(); // Creates the schema based on models (creates the database schema if not present)
        }

        // Test method to verify that an account is correctly added to the database
        [TestMethod] // TestMethod attribute makes this a unit test
        public void CreateAccount_ShouldAddToDatabase()
        {
            // Arrange: Create a new AccountCreation instance with sample data
            var account = new AccountCreation
            {
                FirstName = "Jane", // First name of the employee
                LastName = "Doe", // Last name of the employee
                Position = "Manager", // Position of the employee
                JobType = "Full-time", // Job type (full-time, part-time, etc.)
                StartDate = DateTime.Now, // Start date of the employment
                EndDate = null, // End date (null for ongoing employment)
                EmployeeNumber = Guid.NewGuid().ToString(), // Unique identifier for the employee (using GUID)
                WorkHours = 37.5m, // Work hours per week
                CreationDate = DateTime.Now, // Timestamp when the account was created
                LastUpdated = null // Last updated timestamp (null if not updated)
            };

            // Act: Add the account to the database and save changes
            _context.AccountCreation.Add(account);
            _context.SaveChanges(); // Persists changes to the in-memory database

            // Assert: Verify that the account was added successfully
            Assert.AreEqual(1, _context.AccountCreation.Count()); // Ensure exactly one record exists in the database
            Assert.AreEqual("Jane", _context.AccountCreation.First().FirstName); // Verify that the first name matches the input
        }

        // Test method to verify that an account can be retrieved from the database
        [TestMethod]
        public void ReadAccount_ShouldRetrieveFromDatabase()
        {
            // Arrange: Create and save a new account in the database
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
            _context.SaveChanges(); // Persist changes to the in-memory database

            // Act: Retrieve the account based on the first name
            var retrievedAccount = _context.AccountCreation.FirstOrDefault(a => a.FirstName == "Jane");

            // Assert: Verify the account is found and its last name is correct
            Assert.IsNotNull(retrievedAccount); // Ensure that the account was found in the database
            Assert.AreEqual("Doe", retrievedAccount.LastName); // Check that the last name matches the input
        }

        // Test method to verify that an existing account can be updated
        [TestMethod]
        public void UpdateAccount_ShouldModifyExistingRecord()
        {
            // Arrange: Create and save a new account in the database
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
            _context.SaveChanges(); // Persist the new account to the in-memory database

            // Act: Retrieve the account, modify its position, and save the changes
            var existingAccount = _context.AccountCreation.First(); // Get the first account (assuming only one exists in this case)
            existingAccount.Position = "Director"; // Change the position to "Director"
            _context.SaveChanges(); // Persist the changes to the database

            // Assert: Verify that the position has been updated
            Assert.AreEqual("Director", _context.AccountCreation.First().Position); // Ensure the position has been changed
        }

        // Test method to verify that an account can be deleted from the database
        [TestMethod]
        public void DeleteAccount_ShouldRemoveFromDatabase()
        {
            // Arrange: Create and save a new account in the database
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
            _context.SaveChanges(); // Persist the new account

            // Act: Retrieve and delete the account from the database
            var existingAccount = _context.AccountCreation.First(); // Get the first account
            _context.AccountCreation.Remove(existingAccount); // Remove the account
            _context.SaveChanges(); // Persist the deletion

            // Assert: Verify that the account was deleted from the database
            Assert.AreEqual(0, _context.AccountCreation.Count()); // Ensure the account was removed (count should be 0)
        }

        // Test cleanup method to ensure resources are disposed of after each test
        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose(); // Dispose of the in-memory context after each test to release resources
        }
    }
}
