using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DutchApp.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Verbs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InfinitiveEN = table.Column<string>(nullable: true),
                    InfinitiveNL = table.Column<string>(nullable: true),
                    FirstPersonSingular = table.Column<string>(nullable: true),
                    SecondPersonSingular = table.Column<string>(nullable: true),
                    ThirdPersonSingular = table.Column<string>(nullable: true),
                    FirstPersonPlural = table.Column<string>(nullable: true),
                    SimplePastSingular = table.Column<string>(nullable: true),
                    SimplePastPlural = table.Column<string>(nullable: true),
                    AuxiliaryVerbId = table.Column<int>(nullable: true),
                    PastParticiple = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verbs_Verbs_AuxiliaryVerbId",
                        column: x => x.AuxiliaryVerbId,
                        principalTable: "Verbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verbs_AuxiliaryVerbId",
                table: "Verbs",
                column: "AuxiliaryVerbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verbs");
        }
    }
}
