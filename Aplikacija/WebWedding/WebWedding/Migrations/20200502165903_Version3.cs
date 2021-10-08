using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWedding.Migrations
{
    public partial class Version3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Napomena_Dekoracije_DekoracijaId",
                table: "Napomena");

            migrationBuilder.DropForeignKey(
                name: "FK_Napomena_Fotografi_FotografId",
                table: "Napomena");

            migrationBuilder.DropForeignKey(
                name: "FK_Napomena_Muzika_MuzikaId",
                table: "Napomena");

            migrationBuilder.DropForeignKey(
                name: "FK_Napomena_Prostori_ProstorId",
                table: "Napomena");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Napomena",
                table: "Napomena");

            migrationBuilder.DropIndex(
                name: "IX_Napomena_DekoracijaId",
                table: "Napomena");

            migrationBuilder.DropIndex(
                name: "IX_Napomena_FotografId",
                table: "Napomena");

            migrationBuilder.DropIndex(
                name: "IX_Napomena_MuzikaId",
                table: "Napomena");

            migrationBuilder.DropIndex(
                name: "IX_Napomena_ProstorId",
                table: "Napomena");

            migrationBuilder.DropColumn(
                name: "DekoracijaId",
                table: "Napomena");

            migrationBuilder.DropColumn(
                name: "FotografId",
                table: "Napomena");

            migrationBuilder.DropColumn(
                name: "MuzikaId",
                table: "Napomena");

            migrationBuilder.DropColumn(
                name: "ProstorId",
                table: "Napomena");

            migrationBuilder.RenameTable(
                name: "Napomena",
                newName: "Napomene");

            migrationBuilder.AddColumn<int>(
                name: "MojFotografId",
                table: "Napomene",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MojProstorId",
                table: "Napomene",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MojaDekoracijaId",
                table: "Napomene",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MojaMuzikaId",
                table: "Napomene",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Napomene",
                table: "Napomene",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Napomene_MojFotografId",
                table: "Napomene",
                column: "MojFotografId");

            migrationBuilder.CreateIndex(
                name: "IX_Napomene_MojProstorId",
                table: "Napomene",
                column: "MojProstorId");

            migrationBuilder.CreateIndex(
                name: "IX_Napomene_MojaDekoracijaId",
                table: "Napomene",
                column: "MojaDekoracijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Napomene_MojaMuzikaId",
                table: "Napomene",
                column: "MojaMuzikaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Napomene_Fotografi_MojFotografId",
                table: "Napomene",
                column: "MojFotografId",
                principalTable: "Fotografi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Napomene_Prostori_MojProstorId",
                table: "Napomene",
                column: "MojProstorId",
                principalTable: "Prostori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Napomene_Dekoracije_MojaDekoracijaId",
                table: "Napomene",
                column: "MojaDekoracijaId",
                principalTable: "Dekoracije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Napomene_Muzika_MojaMuzikaId",
                table: "Napomene",
                column: "MojaMuzikaId",
                principalTable: "Muzika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Napomene_Fotografi_MojFotografId",
                table: "Napomene");

            migrationBuilder.DropForeignKey(
                name: "FK_Napomene_Prostori_MojProstorId",
                table: "Napomene");

            migrationBuilder.DropForeignKey(
                name: "FK_Napomene_Dekoracije_MojaDekoracijaId",
                table: "Napomene");

            migrationBuilder.DropForeignKey(
                name: "FK_Napomene_Muzika_MojaMuzikaId",
                table: "Napomene");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Napomene",
                table: "Napomene");

            migrationBuilder.DropIndex(
                name: "IX_Napomene_MojFotografId",
                table: "Napomene");

            migrationBuilder.DropIndex(
                name: "IX_Napomene_MojProstorId",
                table: "Napomene");

            migrationBuilder.DropIndex(
                name: "IX_Napomene_MojaDekoracijaId",
                table: "Napomene");

            migrationBuilder.DropIndex(
                name: "IX_Napomene_MojaMuzikaId",
                table: "Napomene");

            migrationBuilder.DropColumn(
                name: "MojFotografId",
                table: "Napomene");

            migrationBuilder.DropColumn(
                name: "MojProstorId",
                table: "Napomene");

            migrationBuilder.DropColumn(
                name: "MojaDekoracijaId",
                table: "Napomene");

            migrationBuilder.DropColumn(
                name: "MojaMuzikaId",
                table: "Napomene");

            migrationBuilder.RenameTable(
                name: "Napomene",
                newName: "Napomena");

            migrationBuilder.AddColumn<int>(
                name: "DekoracijaId",
                table: "Napomena",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FotografId",
                table: "Napomena",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MuzikaId",
                table: "Napomena",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProstorId",
                table: "Napomena",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Napomena",
                table: "Napomena",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Napomena_Dekoracije_DekoracijaId",
                table: "Napomena",
                column: "DekoracijaId",
                principalTable: "Dekoracije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Napomena_Fotografi_FotografId",
                table: "Napomena",
                column: "FotografId",
                principalTable: "Fotografi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Napomena_Muzika_MuzikaId",
                table: "Napomena",
                column: "MuzikaId",
                principalTable: "Muzika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Napomena_Prostori_ProstorId",
                table: "Napomena",
                column: "ProstorId",
                principalTable: "Prostori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
