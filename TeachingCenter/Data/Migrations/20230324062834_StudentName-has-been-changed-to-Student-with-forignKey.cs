using Microsoft.EntityFrameworkCore.Migrations;

namespace TeachingCenter.Data.Migrations
{
    public partial class StudentNamehasbeenchangedtoStudentwithforignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Attendances");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Attendances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Student_StudentId",
                table: "Attendances",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Student_StudentId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Attendances");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
