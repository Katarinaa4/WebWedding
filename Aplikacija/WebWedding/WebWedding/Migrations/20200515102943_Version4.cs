using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWedding.Migrations
{
    public partial class Version4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Arhivirano",
                table: "Zahtevi",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Arhivirano",
                table: "Organizatori",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Arhivirano",
                table: "Narudzbine",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Meniji",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Arhivirano",
                table: "Korisnici",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arhivirano",
                table: "Zahtevi");

            migrationBuilder.DropColumn(
                name: "Arhivirano",
                table: "Organizatori");

            migrationBuilder.DropColumn(
                name: "Arhivirano",
                table: "Narudzbine");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Meniji");

            migrationBuilder.DropColumn(
                name: "Arhivirano",
                table: "Korisnici");
        }
    }
}
