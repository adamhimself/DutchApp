using Microsoft.EntityFrameworkCore.Migrations;

namespace DutchApp.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verbs_Verbs_AuxiliaryVerbId",
                table: "Verbs");

            migrationBuilder.DropIndex(
                name: "IX_Verbs_AuxiliaryVerbId",
                table: "Verbs");

            migrationBuilder.RenameColumn(
                name: "AuxiliaryVerbId",
                table: "Verbs",
                newName: "AuxiliaryVerbID");

            migrationBuilder.AlterColumn<int>(
                name: "AuxiliaryVerbID",
                table: "Verbs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuxiliaryVerbID",
                table: "Verbs",
                newName: "AuxiliaryVerbId");

            migrationBuilder.AlterColumn<int>(
                name: "AuxiliaryVerbId",
                table: "Verbs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Verbs_AuxiliaryVerbId",
                table: "Verbs",
                column: "AuxiliaryVerbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Verbs_Verbs_AuxiliaryVerbId",
                table: "Verbs",
                column: "AuxiliaryVerbId",
                principalTable: "Verbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
