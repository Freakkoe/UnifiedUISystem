using System; // Provides basic types and functions for handling dates and times.
using Microsoft.EntityFrameworkCore.Migrations; // Provides functionality for Entity Framework Core migrations.

#nullable disable // Disables nullable reference types checking for this file.

namespace SofdCoreSystem.Migrations
{
    /// <inheritdoc />
    // Defines the migration that creates the initial database structure for AccountCreation table.
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        // Defines the changes to apply to the database when migrating up.
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Creates the "AccountCreation" table with specified columns and constraints.
            migrationBuilder.CreateTable(
                name: "AccountCreation", // Name of the table.
                columns: table => new // Defines the columns of the table.
                {
                    // The Id column with an auto-incrementing identity property.
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Auto-increment starts at 1, increments by 1.

                    // The FirstName column, limited to 50 characters, cannot be null.
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),

                    // The LastName column, limited to 50 characters, cannot be null.
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),

                    // The Position column, which stores the job position of the account.
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    // The JobType column, which stores the type of job (e.g., full-time, part-time).
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    // The StartDate column, stores the date the account started.
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),

                    // The EndDate column, stores the date the account ended, nullable.
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),

                    // The EmployeeNumber column, stores the unique identifier for the employee.
                    EmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    // The WorkHours column, stores the number of hours worked, defined as a decimal type.
                    WorkHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),

                    // The CreationDate column, stores the date when the record was created.
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),

                    // The LastUpdated column, stores the date when the record was last updated, nullable.
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    // Defines the primary key for the AccountCreation table, which is the Id column.
                    table.PrimaryKey("PK_AccountCreation", x => x.Id);
                });
        }

        /// <inheritdoc />
        // Defines the changes to undo the migration when rolling back.
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drops the AccountCreation table if the migration is rolled back.
            migrationBuilder.DropTable(
                name: "AccountCreation");
        }
    }
}
