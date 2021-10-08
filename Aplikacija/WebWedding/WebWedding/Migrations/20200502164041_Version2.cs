using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWedding.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Napomena",
                table: "Prostori");

            migrationBuilder.DropColumn(
                name: "Napomena",
                table: "Muzika");

            migrationBuilder.DropColumn(
                name: "Napomena",
                table: "Fotografi");

            migrationBuilder.DropColumn(
                name: "Napomena",
                table: "Dekoracije");

            migrationBuilder.CreateTable(
                name: "Napomena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SadrzajNapomene = table.Column<string>(nullable: false),
                    DatumKreiranja = table.Column<DateTime>(nullable: false),
                    DekoracijaId = table.Column<int>(nullable: true),
                    FotografId = table.Column<int>(nullable: true),
                    MuzikaId = table.Column<int>(nullable: true),
                    ProstorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Napomena", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Napomena_Dekoracije_DekoracijaId",
                        column: x => x.DekoracijaId,
                        principalTable: "Dekoracije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Napomena_Fotografi_FotografId",
                        column: x => x.FotografId,
                        principalTable: "Fotografi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Napomena_Muzika_MuzikaId",
                        column: x => x.MuzikaId,
                        principalTable: "Muzika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Napomena_Prostori_ProstorId",
                        column: x => x.ProstorId,
                        principalTable: "Prostori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Napomena_DekoracijaId",
                table: "Napomena",
                column: "DekoracijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Napomena_FotografId",
                table: "Napomena",
                column: "FotografId");

            migrationBuilder.CreateIndex(
                name: "IX_Napomena_MuzikaId",
                table: "Napomena",
                column: "MuzikaId");

            migrationBuilder.CreateIndex(
                name: "IX_Napomena_ProstorId",
                table: "Napomena",
                column: "ProstorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Napomena");

            migrationBuilder.AddColumn<string>(
                name: "Napomena",
                table: "Prostori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Napomena",
                table: "Muzika",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Napomena",
                table: "Fotografi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Napomena",
                table: "Dekoracije",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
