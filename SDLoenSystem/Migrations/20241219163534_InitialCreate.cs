using System; // Provides base classes for common system functionalities.
using Microsoft.EntityFrameworkCore.Migrations; // Provides classes for creating, altering, and deleting database tables.

#nullable disable // Disables nullable reference types warnings for this file.

namespace SDLoenSystem.Migrations
{
    /// <summary>
    /// Initial migration to create the EmployeeInfos table in the database.
    /// </summary>
    public partial class InitialCreate : Migration
    {
        /// <summary>
        /// Defines the schema changes to apply when the migration is executed (e.g., creating a table).
        /// </summary>
        /// <param name="migrationBuilder">The builder that defines how to build the schema changes.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Creates the EmployeeInfos table with the specified columns and data types.
            migrationBuilder.CreateTable(
                name: "EmployeeInfos", // The name of the table to create.
                columns: table => new
                {
                    // Define the columns of the table
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Identity column that auto-increments.
                    EmploymentDate = table.Column<string>(type: "nvarchar(max)", nullable: false), // Employment date as string.
                    CPRNumber = table.Column<string>(type: "nvarchar(max)", nullable: false), // CPR number (personal identification).
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false), // Employee's first name.
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false), // Employee's last name.
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false), // Employee's address.
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false), // Job position.
                    WorkHours = table.Column<int>(type: "int", nullable: false), // Work hours per week.
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: false), // Employer institution.
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: false), // Type of job (full-time, part-time, etc.).
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false), // Department the employee belongs to.
                    AuthorizationRequirement = table.Column<string>(type: "nvarchar(max)", nullable: false), // Authorization requirement for the job.
                    PhoneWork = table.Column<string>(type: "nvarchar(max)", nullable: false), // Work phone number.
                    PhonePrivate = table.Column<string>(type: "nvarchar(max)", nullable: false), // Private phone number.
                    EmailWork = table.Column<string>(type: "nvarchar(max)", nullable: false), // Work email address.
                    EmailPrivate = table.Column<string>(type: "nvarchar(max)", nullable: false), // Private email address.
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true), // Start date of employment (nullable).
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true), // End date of employment (nullable).
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true), // The last date the employee record was updated (nullable).
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false) // Creation date of the employee record (non-nullable).
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInfos", x => x.Id); // Define the primary key constraint.
                });
        }

        /// <summary>
        /// Defines the schema changes to revert the migration (e.g., dropping a table).
        /// </summary>
        /// <param name="migrationBuilder">The builder used to revert the schema changes.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the EmployeeInfos table if the migration is rolled back.
            migrationBuilder.DropTable(
                name: "EmployeeInfos");
        }
    }
}
