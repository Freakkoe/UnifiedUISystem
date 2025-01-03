using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using HRONSystem.Data;
using HRONSystem.Models;

namespace UnifiedUITests.HRONTests
{
    [TestClass]
    public class JobAdvertCRUDTests
    {
        private HRONNewDbContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            // In-memory database setup
            var options = new DbContextOptionsBuilder<HRONNewDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // New Database with each test 
                .Options;

            _context = new HRONNewDbContext(options);

            // Clears Database
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            Assert.AreEqual(0, _context.JobAdverts.Count(), "Database is not empty after initialization");
        }



        [TestMethod]
        public void CreateJobAdvert_ShouldAddToDatabase()
        {
            // Arrange
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

            // Act
            _context.JobAdverts.Add(jobAdvert);
            _context.SaveChanges();

            // Assert
            var jobAdverts = _context.JobAdverts.ToList();
            Assert.AreEqual(1, jobAdverts.Count, "Number of job adverts in the database is incorrect");
            Assert.AreEqual("Test Job", jobAdverts.First().JobTitle);
        }



        [TestMethod]
        public void ReadJobAdvert_ShouldRetrieveFromDatabase()
        {
            // Arrange
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

            // Act
            var retrievedJob = _context.JobAdverts.FirstOrDefault(j => j.JobTitle == "Test Job");

            // Assert
            Assert.IsNotNull(retrievedJob, "Job advert was not retrieved.");
            Assert.AreEqual("John Doe", retrievedJob.Responsible, $"Expected Responsible: John Doe, but got {retrievedJob.Responsible}");
            Assert.AreEqual(10, retrievedJob.Views, $"Expected Views: 10, but got {retrievedJob.Views}");
        }


        [TestMethod]
        public void UpdateJobAdvert_ShouldModifyExistingRecord()
        {
            // Arrange
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

            // Act
            var existingJob = _context.JobAdverts.First();
            existingJob.Status = "Inactive";
            _context.SaveChanges();

            // Assert
            Assert.AreEqual("Inactive", _context.JobAdverts.First().Status);
        }

        [TestMethod]
        public void DeleteJobAdvert_ShouldRemoveFromDatabase()
        {
            // Arrange
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

            // Act
            var existingJob = _context.JobAdverts.First();
            _context.JobAdverts.Remove(existingJob);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(0, _context.JobAdverts.Count(), "Database should be empty after deletion");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose();
        }
    }
}

