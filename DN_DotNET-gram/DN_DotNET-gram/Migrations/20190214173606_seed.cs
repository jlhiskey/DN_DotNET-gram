using Microsoft.EntityFrameworkCore.Migrations;

namespace DN_DotNET_gram.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Details", "URL" },
                values: new object[,]
                {
                    { 1, "Squirrel's With Lightsabers", "https://via.placeholder.com/150" },
                    { 2, "Deathstar Sunrise", "https://via.placeholder.com/150" },
                    { 3, "Deathstar Sunrise", "https://via.placeholder.com/150" },
                    { 4, "Volcano", "https://via.placeholder.com/150" },
                    { 5, "Glacier", "https://via.placeholder.com/150" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
