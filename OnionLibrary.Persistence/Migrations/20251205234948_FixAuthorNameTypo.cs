using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixAuthorNameTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstaneName",
                table: "Author",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Author",
                newName: "FirstaneName");
        }
    }
}
