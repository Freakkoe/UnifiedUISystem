using Microsoft.EntityFrameworkCore.Migrations; // Provides functionality for Entity Framework Core migrations.

#nullable disable // Disables nullable reference types checking for this file.

namespace SofdCoreSystem.Migrations
{
    /// <inheritdoc />
    // Defines a migration that adds a "Relations" table to the database.
    public partial class AddRelationsTable : Migration
    {
        /// <inheritdoc />
        // Defines the changes to apply to the database when migrating up.
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Creates the "Relations" table with specified columns and constraints.
            migrationBuilder.CreateTable(
                name: "Relations", // Name of the table.
                columns: table => new // Defines the columns of the table.
                {
                    // The Id column with an auto-incrementing identity property.
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Auto-increment starts at 1, increments by 1.

                    // The Position column, which stores the position of the related account.
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    // The Unit column, which stores the department or unit the relation belongs to.
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    // The InheritsRights column, which determines if the relation inherits rights from the associated account.
                    InheritsRights = table.Column<bool>(type: "bit", nullable: false),

                    // The Status column, which stores the current status of the relation.
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    // The EmploymentType column, which stores the type of employment (e.g., full-time, part-time).
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    // The AccountId column, which serves as a foreign key linking this relation to an account.
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    // Defines the primary key for the Relations table, which is the Id column.
                    table.PrimaryKey("PK_Relations", x => x.Id);

                    // Defines a foreign key constraint that links the AccountId to the AccountCreation table.
                    table.ForeignKey(
                        name: "FK_Relations_AccountCreation_AccountId", // Name of the foreign key.
                        column: x => x.AccountId, // Column in the Relations table that acts as the foreign key.
                        principalTable: "AccountCreation", // The table that the foreign key references.
                        principalColumn: "Id", // The column in the referenced table (AccountCreation) that is the primary key.
                        onDelete: ReferentialAction.Cascade); // Defines the delete behavior (delete related relations when an account is deleted).
                });

            // Creates an index on the AccountId column in the Relations table for faster querying.
            migrationBuilder.CreateIndex(
                name: "IX_Relations_AccountId", // Name of the index.
                table: "Relations", // Table where the index is created.
                column: "AccountId"); // The column to index.
        }

        /// <inheritdoc />
        // Defines the changes to undo the migration when rolling back.
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drops the Relations table if the migration is rolled back.
            migrationBuilder.DropTable(
                name: "Relations");
        }
    }
}
