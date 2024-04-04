using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListMVVM.Migrations
{
    /// <inheritdoc />
    public partial class createdon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CreatedOn",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Notes");
        }
    }
}
