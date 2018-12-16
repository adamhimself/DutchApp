using Microsoft.EntityFrameworkCore.Migrations;

namespace DutchApp.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verbs_AuxiliaryVerb_AuxiliaryVerbId",
                table: "Verbs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuxiliaryVerb",
                table: "AuxiliaryVerb");

            migrationBuilder.RenameTable(
                name: "AuxiliaryVerb",
                newName: "AuxiliaryVerbs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuxiliaryVerbs",
                table: "AuxiliaryVerbs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Verbs_AuxiliaryVerbs_AuxiliaryVerbId",
                table: "Verbs",
                column: "AuxiliaryVerbId",
                principalTable: "AuxiliaryVerbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verbs_AuxiliaryVerbs_AuxiliaryVerbId",
                table: "Verbs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuxiliaryVerbs",
                table: "AuxiliaryVerbs");

            migrationBuilder.RenameTable(
                name: "AuxiliaryVerbs",
                newName: "AuxiliaryVerb");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuxiliaryVerb",
                table: "AuxiliaryVerb",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Verbs_AuxiliaryVerb_AuxiliaryVerbId",
                table: "Verbs",
                column: "AuxiliaryVerbId",
                principalTable: "AuxiliaryVerb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
