using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using HRONSystem.Data;
using HRONSystem.Models;

namespace UnifiedUITests.HRONTests
{
    [TestClass] // Marks this class as containing unit tests
    public class JobAdvertCRUDTests
    {
        private HRONNewDbContext _context; // Private field to hold the DbContext for interaction with the database during tests

        // Test initialization setup method, runs before each test
        [TestInitialize]
        public void TestInitialize()
        {
            // In-memory database setup: creating a new, unique database for each test run
            var options = new DbContextOptionsBuilder<HRONNewDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Generate a new GUID to create a unique database
                .Options;

            _context = new HRONNewDbContext(options); // Assigning the context to the in-memory database with unique options

            // Ensures that the database is empty and created fresh for each test
            _context.Database.EnsureDeleted(); // Deletes any existing database if present (ensures isolation between tests)
            _context.Database.EnsureCreated(); // Creates the database schema based on models (ensures a fresh setup)

            // Assert that the database starts empty (it should have no records initially)
            Assert.AreEqual(0, _context.JobAdverts.Count(), "Database is not empty after initialization");
        }

        // Test method to verify that a job advert is added to the database
        [TestMethod] // TestMethod attribute makes this a test case
        public void CreateJobAdvert_ShouldAddToDatabase()
        {
            // Arrange: Create a new JobAdvert instance with test data
            var jobAdvert = new JobAdvert
            {
                PublishingDate = DateTime.Now, // Set publishing date to the current date
                ApplicationDeadline = DateTime.Now.AddDays(7), // Set application deadline to 7 days later
                JobTitle = "Test Job", // Set job title
                Media = "Online", // Media platform for advertisement
                Status = "Active", // Job status
                Responsible = "John Doe", // Responsible person for the job
                Department = "IT", // Department of the job
                Views = 10, // Number of views for the job advert
                Applications = 5, // Number of applications for the job advert
                Comments = "This is a test comment", // A test comment
                IsArchived = false // Set to false (i.e., job is active and not archived)
            };

            // Act: Add the new job advert to the context and save changes
            _context.JobAdverts.Add(jobAdvert);
            _context.SaveChanges(); // Save the changes to the in-memory database

            // Assert: Verify that the job advert was added to the database
            var jobAdverts = _context.JobAdverts.ToList(); // Retrieve all job adverts from the database
            Assert.AreEqual(1, jobAdverts.Count, "Number of job adverts in the database is incorrect"); // Verify there's exactly one job advert
            Assert.AreEqual("Test Job", jobAdverts.First().JobTitle); // Check that the job title is correctly set
        }

        // Test method to verify that a job advert can be read (retrieved) from the database
        [TestMethod]
        public void ReadJobAdvert_ShouldRetrieveFromDatabase()
        {
            // Arrange: Set up a new job advert and save it to the database
            var jobAdvert = new JobAdvert
            {
                PublishingDate = DateTime.Now,
                ApplicationDeadline = DateTime.Now.AddDays(7),
                JobTitle = "Test Job",
                Media = "Online",
                Status = "Active",
                Responsible = "John Doe",
                Department = "IT",
                Views = 10,
                Applications = 5,
                Comments = "This is a test comment",
                IsArchived = false
            };

            _context.JobAdverts.Add(jobAdvert);
            _context.SaveChanges();

            // Act: Retrieve the job advert by its JobTitle (ensure it exists in the database)
            var retrievedJob = _context.JobAdverts.FirstOrDefault(j => j.JobTitle == "Test Job");

            // Assert: Check that the retrieved job advert is not null and has the expected values
            Assert.IsNotNull(retrievedJob, "Job advert was not retrieved.");
            Assert.AreEqual("John Doe", retrievedJob.Responsible, $"Expected Responsible: John Doe, but got {retrievedJob.Responsible}"); // Ensure the responsible person is correct
            Assert.AreEqual(10, retrievedJob.Views, $"Expected Views: 10, but got {retrievedJob.Views}"); // Ensure views count is correct
        }

        // Test method to verify that an existing job advert can be updated
        [TestMethod]
        public void UpdateJobAdvert_ShouldModifyExistingRecord()
        {
            // Arrange: Create and save a new job advert
            var jobAdvert = new JobAdvert
            {
                PublishingDate = DateTime.Now,
                ApplicationDeadline = DateTime.Now.AddDays(7),
                JobTitle = "Test Job",
                Media = "Online",
                Status = "Active",
                Responsible = "John Doe",
                Department = "IT",
                Views = 10,
                Applications = 5,
                Comments = "This is a test comment",
                IsArchived = false
            };

            _context.JobAdverts.Add(jobAdvert);
            _context.SaveChanges();

            // Act: Retrieve the job advert and modify its status
            var existingJob = _context.JobAdverts.First();
            existingJob.Status = "Inactive"; // Update the job advert's status to "Inactive"
            _context.SaveChanges(); // Save the changes

            // Assert: Verify that the status has been updated
            Assert.AreEqual("Inactive", _context.JobAdverts.First().Status); // Check if the status is now "Inactive"
        }

        // Test method to verify that a job advert can be deleted
        [TestMethod]
        public void DeleteJobAdvert_ShouldRemoveFromDatabase()
        {
            // Arrange: Create and save a new job advert
            var jobAdvert = new JobAdvert
            {
                PublishingDate = DateTime.Now,
                ApplicationDeadline = DateTime.Now.AddDays(7),
                JobTitle = "Test Job",
                Media = "Online",
                Status = "Active",
                Responsible = "John Doe",
                Department = "IT",
                Views = 10,
                Applications = 5,
                Comments = "This is a test comment",
                IsArchived = false
            };

            _context.JobAdverts.Add(jobAdvert);
            _context.SaveChanges();

            // Act: Retrieve the job advert and remove it from the database
            var existingJob = _context.JobAdverts.First();
            _context.JobAdverts.Remove(existingJob); // Remove the job advert from the context
            _context.SaveChanges(); // Save the changes to the database

            // Assert: Verify that the job advert was deleted from the database
            Assert.AreEqual(0, _context.JobAdverts.Count(), "Database should be empty after deletion"); // Ensure no job adverts are left
        }

        // Test cleanup after each test method, ensuring resources are released
        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose(); // Dispose of the context to release in-memory database resources
        }
    }
}
