using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWedding.Migrations
{
    public partial class ResetMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 30, nullable: false),
                    Prezime = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Sifra = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dekoracije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojZvezdica = table.Column<int>(nullable: false),
                    Slika = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Cena = table.Column<double>(nullable: false),
                    StatusPrikaza = table.Column<string>(nullable: true),
                    DatumVazenja = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dekoracije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fotografi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slika = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Cena = table.Column<double>(nullable: false),
                    StatusPrikaza = table.Column<string>(nullable: true),
                    DatumVazenja = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 30, nullable: false),
                    Prezime = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Sifra = table.Column<string>(maxLength: 30, nullable: false),
                    BrojTelefona = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Muzika",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojZvezdica = table.Column<int>(nullable: false),
                    Slika = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Cena = table.Column<double>(nullable: false),
                    StatusPrikaza = table.Column<string>(nullable: true),
                    DatumVazenja = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muzika", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizatori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 30, nullable: false),
                    Prezime = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Sifra = table.Column<string>(maxLength: 30, nullable: false),
                    Plata = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizatori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planeri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Cena = table.Column<double>(nullable: false),
                    Slika = table.Column<string>(nullable: false),
                    BrojPlaneraNaRaspolaganju = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planeri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prostori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojZvezdica = table.Column<int>(nullable: false),
                    Slika = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Kapacitet = table.Column<int>(nullable: false),
                    StatusPrikaza = table.Column<string>(nullable: true),
                    DatumVazenja = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prostori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slike",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    slika = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slike", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DekoracijaRezervisaniD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateTime>(nullable: false),
                    MojaDekoracijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekoracijaRezervisaniD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekoracijaRezervisaniD_Dekoracije_MojaDekoracijaId",
                        column: x => x.MojaDekoracijaId,
                        principalTable: "Dekoracije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DekoracijaZakazaniD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateTime>(nullable: false),
                    MojaDekoracijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekoracijaZakazaniD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekoracijaZakazaniD_Dekoracije_MojaDekoracijaId",
                        column: x => x.MojaDekoracijaId,
                        principalTable: "Dekoracije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotografiRezervisaniD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateTime>(nullable: false),
                    MojFotografId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotografiRezervisaniD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotografiRezervisaniD_Fotografi_MojFotografId",
                        column: x => x.MojFotografId,
                        principalTable: "Fotografi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotografiZakazaniD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateTime>(nullable: false),
                    MojFotografId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotografiZakazaniD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotografiZakazaniD_Fotografi_MojFotografId",
                        column: x => x.MojFotografId,
                        principalTable: "Fotografi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuzikaRezervisaniD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateTime>(nullable: false),
                    MojaMuzikaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuzikaRezervisaniD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MuzikaRezervisaniD_Muzika_MojaMuzikaId",
                        column: x => x.MojaMuzikaId,
                        principalTable: "Muzika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuzikaZakazaniD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateTime>(nullable: false),
                    MojaMuzikaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuzikaZakazaniD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MuzikaZakazaniD_Muzika_MojaMuzikaId",
                        column: x => x.MojaMuzikaId,
                        principalTable: "Muzika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzbine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    Adresa = table.Column<string>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    UkupnaCena = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    MojKorisnikId = table.Column<int>(nullable: true),
                    MojPlanerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzbine_Korisnici_MojKorisnikId",
                        column: x => x.MojKorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbine_Planeri_MojPlanerId",
                        column: x => x.MojPlanerId,
                        principalTable: "Planeri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meniji",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Cena = table.Column<double>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Slika = table.Column<string>(nullable: true),
                    MojProstorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meniji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meniji_Prostori_MojProstorId",
                        column: x => x.MojProstorId,
                        principalTable: "Prostori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RezervisaniDatumi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateTime>(nullable: false),
                    MojProstorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervisaniDatumi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezervisaniDatumi_Prostori_MojProstorId",
                        column: x => x.MojProstorId,
                        principalTable: "Prostori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZakazaniDatumi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateTime>(nullable: false),
                    MojProstorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZakazaniDatumi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZakazaniDatumi_Prostori_MojProstorId",
                        column: x => x.MojProstorId,
                        principalTable: "Prostori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zahtevi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UkupnaCena = table.Column<double>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: true),
                    MojFotografId = table.Column<int>(nullable: true),
                    MojaDekoracijaId = table.Column<int>(nullable: true),
                    MojaMuzikaId = table.Column<int>(nullable: true),
                    MojProstorId = table.Column<int>(nullable: true),
                    MojMeniId = table.Column<int>(nullable: true),
                    DatumPodnosenjaZahteva = table.Column<DateTime>(nullable: false),
                    IzabraniDatum = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    BrojGostiju = table.Column<int>(nullable: true),
                    Poslato = table.Column<bool>(nullable: false),
                    PotvrdjenoProstor = table.Column<bool>(nullable: true),
                    PotvrdjenoMeni = table.Column<bool>(nullable: true),
                    PotvrdjenoMuzika = table.Column<bool>(nullable: true),
                    PotvrdjenoFotograf = table.Column<bool>(nullable: true),
                    PotvrdjenoDekoracija = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtevi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zahtevi_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtevi_Fotografi_MojFotografId",
                        column: x => x.MojFotografId,
                        principalTable: "Fotografi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtevi_Meniji_MojMeniId",
                        column: x => x.MojMeniId,
                        principalTable: "Meniji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtevi_Prostori_MojProstorId",
                        column: x => x.MojProstorId,
                        principalTable: "Prostori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtevi_Dekoracije_MojaDekoracijaId",
                        column: x => x.MojaDekoracijaId,
                        principalTable: "Dekoracije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtevi_Muzika_MojaMuzikaId",
                        column: x => x.MojaMuzikaId,
                        principalTable: "Muzika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DekoracijaRezervisaniD_MojaDekoracijaId",
                table: "DekoracijaRezervisaniD",
                column: "MojaDekoracijaId");

            migrationBuilder.CreateIndex(
                name: "IX_DekoracijaZakazaniD_MojaDekoracijaId",
                table: "DekoracijaZakazaniD",
                column: "MojaDekoracijaId");

            migrationBuilder.CreateIndex(
                name: "IX_FotografiRezervisaniD_MojFotografId",
                table: "FotografiRezervisaniD",
                column: "MojFotografId");

            migrationBuilder.CreateIndex(
                name: "IX_FotografiZakazaniD_MojFotografId",
                table: "FotografiZakazaniD",
                column: "MojFotografId");

            migrationBuilder.CreateIndex(
                name: "IX_Meniji_MojProstorId",
                table: "Meniji",
                column: "MojProstorId");

            migrationBuilder.CreateIndex(
                name: "IX_MuzikaRezervisaniD_MojaMuzikaId",
                table: "MuzikaRezervisaniD",
                column: "MojaMuzikaId");

            migrationBuilder.CreateIndex(
                name: "IX_MuzikaZakazaniD_MojaMuzikaId",
                table: "MuzikaZakazaniD",
                column: "MojaMuzikaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbine_MojKorisnikId",
                table: "Narudzbine",
                column: "MojKorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbine_MojPlanerId",
                table: "Narudzbine",
                column: "MojPlanerId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervisaniDatumi_MojProstorId",
                table: "RezervisaniDatumi",
                column: "MojProstorId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtevi_KorisnikId",
                table: "Zahtevi",
                column: "KorisnikId",
                unique: true,
                filter: "[KorisnikId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtevi_MojFotografId",
                table: "Zahtevi",
                column: "MojFotografId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtevi_MojMeniId",
                table: "Zahtevi",
                column: "MojMeniId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtevi_MojProstorId",
                table: "Zahtevi",
                column: "MojProstorId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtevi_MojaDekoracijaId",
                table: "Zahtevi",
                column: "MojaDekoracijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtevi_MojaMuzikaId",
                table: "Zahtevi",
                column: "MojaMuzikaId");

            migrationBuilder.CreateIndex(
                name: "IX_ZakazaniDatumi_MojProstorId",
                table: "ZakazaniDatumi",
                column: "MojProstorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "DekoracijaRezervisaniD");

            migrationBuilder.DropTable(
                name: "DekoracijaZakazaniD");

            migrationBuilder.DropTable(
                name: "FotografiRezervisaniD");

            migrationBuilder.DropTable(
                name: "FotografiZakazaniD");

            migrationBuilder.DropTable(
                name: "MuzikaRezervisaniD");

            migrationBuilder.DropTable(
                name: "MuzikaZakazaniD");

            migrationBuilder.DropTable(
                name: "Narudzbine");

            migrationBuilder.DropTable(
                name: "Organizatori");

            migrationBuilder.DropTable(
                name: "RezervisaniDatumi");

            migrationBuilder.DropTable(
                name: "Slike");

            migrationBuilder.DropTable(
                name: "Zahtevi");

            migrationBuilder.DropTable(
                name: "ZakazaniDatumi");

            migrationBuilder.DropTable(
                name: "Planeri");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Fotografi");

            migrationBuilder.DropTable(
                name: "Meniji");

            migrationBuilder.DropTable(
                name: "Dekoracije");

            migrationBuilder.DropTable(
                name: "Muzika");

            migrationBuilder.DropTable(
                name: "Prostori");
        }
    }
}
