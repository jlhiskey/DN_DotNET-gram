using Microsoft.EntityFrameworkCore.Migrations;

namespace DN_DotNET_gram.Migrations
{
    public partial class updatedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Posts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "Jason");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Details", "Name" },
                values: new object[] { "Bob Ross", "Jason" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "Jason");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 4,
                column: "Name",
                value: "Jason");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 5,
                column: "Name",
                value: "Jason");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Details",
                value: "Deathstar Sunrise");
        }
    }
}
