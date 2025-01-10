using System; // Provides base class definitions and fundamental types.
using Microsoft.EntityFrameworkCore.Migrations; // Enables migration functionality in Entity Framework Core.

#nullable disable

namespace HRONSystem.Migrations
{
    /// <summary>
    /// Represents the initial migration for creating the database schema.
    /// </summary>
    public partial class InitialCreate : Migration
    {
        /// <summary>
        /// Defines the operations to apply the migration (e.g., creating tables).
        /// </summary>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobAdverts", // Specifies the table name in the database.
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false) // Primary key column.
                        .Annotation("SqlServer:Identity", "1, 1"), // Auto-increment configuration.
                    PublishingDate = table.Column<DateTime>(type: "datetime2", nullable: false), // Column for publishing date.
                    ApplicationDeadline = table.Column<DateTime>(type: "datetime2", nullable: false), // Column for application deadline.
                    JobTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false), // Column for job title with max length.
                    Media = table.Column<string>(type: "nvarchar(max)", nullable: false), // Column for media details.
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false), // Column for job status.
                    Responsible = table.Column<string>(type: "nvarchar(max)", nullable: false), // Column for responsible person/department.
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false), // Column for department name.
                    Views = table.Column<int>(type: "int", nullable: false), // Column for tracking the number of views.
                    Applications = table.Column<int>(type: "int", nullable: false), // Column for tracking the number of applications.
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false) // Column for additional comments.
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAdverts", x => x.Id); // Defines the primary key constraint.
                });
        }

        /// <summary>
        /// Reverts the operations defined in the Up method (e.g., dropping tables).
        /// </summary>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobAdverts"); // Removes the JobAdverts table.
        }
    }
}
