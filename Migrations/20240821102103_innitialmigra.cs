using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Student__management__system.Migrations
{
    /// <inheritdoc />
    public partial class innitialmigra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ClassStream_StreamsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StreamsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StreamsId",
                table: "Students");

            migrationBuilder.InsertData(
                table: "ClassStream",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Science Stream", "Science" },
                    { 2, "Arts Stream", "Arts" },
                    { 3, "Commerce Stream", "Commerce" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Age", "FirstName", "Id", "LastName" },
                values: new object[,]
                {
                    { 1, 16, "John ", 1, "Doe" },
                    { 2, 17, "Jane Doe", 2, "Doe" },
                    { 3, 16, "Jim ", 3, "Doe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Id",
                table: "Students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ClassStream_Id",
                table: "Students",
                column: "Id",
                principalTable: "ClassStream",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ClassStream_Id",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Id",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClassStream",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClassStream",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClassStream",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "StreamsId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StreamsId",
                table: "Students",
                column: "StreamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ClassStream_StreamsId",
                table: "Students",
                column: "StreamsId",
                principalTable: "ClassStream",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
