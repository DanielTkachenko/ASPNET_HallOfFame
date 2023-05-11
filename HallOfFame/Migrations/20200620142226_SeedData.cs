using Microsoft.EntityFrameworkCore.Migrations;

namespace HallOfFame.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1L, "T1", "Test1" },
                    { 2L, "T2", "Test2" },
                    { 3L, "T3", "Test3" },
                    { 4L, "T4", "Test4" },
                    { 5L, "T5", "Test5" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "PersonId", "Name", "Level" },
                values: new object[,]
                {
                    { 1L, "Skill1", (byte)1 },
                    { 2L, "Skill2", (byte)2 },
                    { 3L, "Skill3", (byte)3 },
                    { 4L, "Skill4", (byte)4 },
                    { 5L, "Skill5", (byte)5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "PersonId", "Name" },
                keyValues: new object[] { 1L, "Skill1" });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "PersonId", "Name" },
                keyValues: new object[] { 2L, "Skill2" });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "PersonId", "Name" },
                keyValues: new object[] { 3L, "Skill3" });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "PersonId", "Name" },
                keyValues: new object[] { 4L, "Skill4" });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "PersonId", "Name" },
                keyValues: new object[] { 5L, "Skill5" });

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
