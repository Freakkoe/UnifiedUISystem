using Microsoft.EntityFrameworkCore.Migrations; // Enables migration functionality in Entity Framework Core.

#nullable disable

namespace HRONSystem.Migrations
{
    /// <summary>
    /// Migration to add the IsArchived column to the JobAdverts table.
    /// </summary>
    public partial class AddIsArchivedToJobAdvert : Migration
    {
        /// <summary>
        /// Applies the migration by adding the IsArchived column to the JobAdverts table.
        /// </summary>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>( // Adds a new column of type boolean.
                name: "IsArchived", // Name of the new column.
                table: "JobAdverts", // The table where the column is added.
                type: "bit", // SQL Server data type for boolean.
                nullable: false, // Indicates the column cannot have null values.
                defaultValue: false); // Sets the default value to false.
        }

        /// <summary>
        /// Reverts the migration by removing the IsArchived column from the JobAdverts table.
        /// </summary>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn( // Removes the column from the table.
                name: "IsArchived", // Name of the column to remove.
                table: "JobAdverts"); // The table from which the column is removed.
        }
    }
}
