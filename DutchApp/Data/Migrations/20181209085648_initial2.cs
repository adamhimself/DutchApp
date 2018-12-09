using Microsoft.EntityFrameworkCore.Migrations;

namespace DutchApp.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_StudyItems_StudyItemID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Verbs_VerbID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_VerbID",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "VerbID",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "StudyItemID",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_StudyItems_StudyItemID",
                table: "Reviews",
                column: "StudyItemID",
                principalTable: "StudyItems",
                principalColumn: "StudyItemID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_StudyItems_StudyItemID",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "StudyItemID",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "VerbID",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_VerbID",
                table: "Reviews",
                column: "VerbID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_StudyItems_StudyItemID",
                table: "Reviews",
                column: "StudyItemID",
                principalTable: "StudyItems",
                principalColumn: "StudyItemID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Verbs_VerbID",
                table: "Reviews",
                column: "VerbID",
                principalTable: "Verbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
