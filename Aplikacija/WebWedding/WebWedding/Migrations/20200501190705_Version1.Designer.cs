﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebWedding;

namespace WebWedding.Migrations
{
    [DbContext(typeof(WebWeddingContext))]
    [Migration("20200501190705_Version1")]
    partial class Version1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebWedding.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("WebWedding.Dekoracija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojZvezdica")
                        .HasColumnType("int");

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<DateTime>("DatumVazenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusPrikaza")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dekoracije");
                });

            modelBuilder.Entity("WebWedding.Fotograf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<DateTime>("DatumVazenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusPrikaza")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fotografi");
                });

            modelBuilder.Entity("WebWedding.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("WebWedding.Models.DekoracijaRezervisani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MojaDekoracijaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MojaDekoracijaId");

                    b.ToTable("DekoracijaRezervisaniD");
                });

            modelBuilder.Entity("WebWedding.Models.DekoracijaZakazani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MojaDekoracijaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MojaDekoracijaId");

                    b.ToTable("DekoracijaZakazaniD");
                });

            modelBuilder.Entity("WebWedding.Models.FotografRezervisani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MojFotografId")
                        .HasColumnType("int");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MojFotografId");

                    b.ToTable("FotografiRezervisaniD");
                });

            modelBuilder.Entity("WebWedding.Models.FotografZakazani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MojFotografId")
                        .HasColumnType("int");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MojFotografId");

                    b.ToTable("FotografiZakazaniD");
                });

            modelBuilder.Entity("WebWedding.Models.Meni", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<int>("MojProstorId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MojProstorId");

                    b.ToTable("Meniji");
                });

            modelBuilder.Entity("WebWedding.Models.MuzikaRezervisani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MojaMuzikaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MojaMuzikaId");

                    b.ToTable("MuzikaRezervisaniD");
                });

            modelBuilder.Entity("WebWedding.Models.MuzikaZakazani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MojaMuzikaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MojaMuzikaId");

                    b.ToTable("MuzikaZakazaniD");
                });

            modelBuilder.Entity("WebWedding.Models.Narudzbina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MojKorisnikId")
                        .HasColumnType("int");

                    b.Property<int?>("MojPlanerId")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UkupnaCena")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MojKorisnikId");

                    b.HasIndex("MojPlanerId");

                    b.ToTable("Narudzbine");
                });

            modelBuilder.Entity("WebWedding.Models.Planer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojPlaneraNaRaspolaganju")
                        .HasColumnType("int");

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Planeri");
                });

            modelBuilder.Entity("WebWedding.Models.ProstorRezervisani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MojProstorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MojProstorId");

                    b.ToTable("RezervisaniDatumi");
                });

            modelBuilder.Entity("WebWedding.Models.ProstorZakazani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MojProstorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MojProstorId");

                    b.ToTable("ZakazaniDatumi");
                });

            modelBuilder.Entity("WebWedding.Models.Slika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("slika")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Slike");
                });

            modelBuilder.Entity("WebWedding.Muzika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojZvezdica")
                        .HasColumnType("int");

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<DateTime>("DatumVazenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusPrikaza")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Muzika");
                });

            modelBuilder.Entity("WebWedding.Organizator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<double>("Plata")
                        .HasColumnType("float");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Organizatori");
                });

            modelBuilder.Entity("WebWedding.Prostor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrojZvezdica")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumVazenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusPrikaza")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prostori");
                });

            modelBuilder.Entity("WebWedding.Zahtev", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrojGostiju")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumPodnosenjaZahteva")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IzabraniDatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int?>("MojFotografId")
                        .HasColumnType("int");

                    b.Property<int?>("MojMeniId")
                        .HasColumnType("int");

                    b.Property<int?>("MojProstorId")
                        .HasColumnType("int");

                    b.Property<int?>("MojaDekoracijaId")
                        .HasColumnType("int");

                    b.Property<int?>("MojaMuzikaId")
                        .HasColumnType("int");

                    b.Property<bool>("Poslato")
                        .HasColumnType("bit");

                    b.Property<bool?>("PotvrdjenoDekoracija")
                        .HasColumnType("bit");

                    b.Property<bool?>("PotvrdjenoFotograf")
                        .HasColumnType("bit");

                    b.Property<bool?>("PotvrdjenoMeni")
                        .HasColumnType("bit");

                    b.Property<bool?>("PotvrdjenoMuzika")
                        .HasColumnType("bit");

                    b.Property<bool?>("PotvrdjenoProstor")
                        .HasColumnType("bit");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UkupnaCena")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId")
                        .IsUnique()
                        .HasFilter("[KorisnikId] IS NOT NULL");

                    b.HasIndex("MojFotografId");

                    b.HasIndex("MojMeniId");

                    b.HasIndex("MojProstorId");

                    b.HasIndex("MojaDekoracijaId");

                    b.HasIndex("MojaMuzikaId");

                    b.ToTable("Zahtevi");
                });

            modelBuilder.Entity("WebWedding.Models.DekoracijaRezervisani", b =>
                {
                    b.HasOne("WebWedding.Dekoracija", "MojaDekoracija")
                        .WithMany("Rezervisani")
                        .HasForeignKey("MojaDekoracijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebWedding.Models.DekoracijaZakazani", b =>
                {
                    b.HasOne("WebWedding.Dekoracija", "MojaDekoracija")
                        .WithMany("Zakazani")
                        .HasForeignKey("MojaDekoracijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebWedding.Models.FotografRezervisani", b =>
                {
                    b.HasOne("WebWedding.Fotograf", "MojFotograf")
                        .WithMany("Rezervisani")
                        .HasForeignKey("MojFotografId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebWedding.Models.FotografZakazani", b =>
                {
                    b.HasOne("WebWedding.Fotograf", "MojFotograf")
                        .WithMany("Zakazani")
                        .HasForeignKey("MojFotografId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebWedding.Models.Meni", b =>
                {
                    b.HasOne("WebWedding.Prostor", "MojProstor")
                        .WithMany("ListaMenija")
                        .HasForeignKey("MojProstorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebWedding.Models.MuzikaRezervisani", b =>
                {
                    b.HasOne("WebWedding.Muzika", "MojaMuzika")
                        .WithMany("Rezervisani")
                        .HasForeignKey("MojaMuzikaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebWedding.Models.MuzikaZakazani", b =>
                {
                    b.HasOne("WebWedding.Muzika", "MojaMuzika")
                        .WithMany("Zakazani")
                        .HasForeignKey("MojaMuzikaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebWedding.Models.Narudzbina", b =>
                {
                    b.HasOne("WebWedding.Korisnik", "MojKorisnik")
                        .WithMany("Narudzbine")
                        .HasForeignKey("MojKorisnikId");

                    b.HasOne("WebWedding.Models.Planer", "MojPlaner")
                        .WithMany()
                        .HasForeignKey("MojPlanerId");
                });

            modelBuilder.Entity("WebWedding.Models.ProstorRezervisani", b =>
                {
                    b.HasOne("WebWedding.Prostor", "MojProstor")
                        .WithMany("Rezervisani")
                        .HasForeignKey("MojProstorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebWedding.Models.ProstorZakazani", b =>
                {
                    b.HasOne("WebWedding.Prostor", "MojProstor")
                        .WithMany("Zakazani")
                        .HasForeignKey("MojProstorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebWedding.Zahtev", b =>
                {
                    b.HasOne("WebWedding.Korisnik", "MojKorisnik")
                        .WithOne("MojZahtev")
                        .HasForeignKey("WebWedding.Zahtev", "KorisnikId");

                    b.HasOne("WebWedding.Fotograf", "MojFotograf")
                        .WithMany("ListaZahteva")
                        .HasForeignKey("MojFotografId");

                    b.HasOne("WebWedding.Models.Meni", "MojMeni")
                        .WithMany()
                        .HasForeignKey("MojMeniId");

                    b.HasOne("WebWedding.Prostor", "MojProstor")
                        .WithMany("ListaZahteva")
                        .HasForeignKey("MojProstorId");

                    b.HasOne("WebWedding.Dekoracija", "MojaDekoracija")
                        .WithMany("ListaZahteva")
                        .HasForeignKey("MojaDekoracijaId");

                    b.HasOne("WebWedding.Muzika", "MojaMuzika")
                        .WithMany("ListaZahteva")
                        .HasForeignKey("MojaMuzikaId");
                });
#pragma warning restore 612, 618
        }
    }
}
