using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRONSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddIsArchivedToJobAdvert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "JobAdverts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "JobAdverts");
        }
    }
}
