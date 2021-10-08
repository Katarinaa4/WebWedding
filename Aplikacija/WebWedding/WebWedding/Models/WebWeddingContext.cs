using Microsoft.EntityFrameworkCore;

using WebWedding.Models;

namespace WebWedding
{
    public class WebWeddingContext : DbContext
    {
        public WebWeddingContext(DbContextOptions<WebWeddingContext> options) : base(options)
        {

        }

        public DbSet<Administrator> Administrator { get; set; }

        public DbSet<Organizator> Organizatori { get; set; }

        public DbSet<Korisnik> Korisnici { get; set; }

        public DbSet<Zahtev> Zahtevi { get; set; }

        public DbSet<Prostor> Prostori { get; set; }

        public DbSet<Muzika> Muzika { get; set; }

        public DbSet<Dekoracija> Dekoracije { get; set; }

        public DbSet<Fotograf> Fotografi { get; set; }

        public DbSet<Meni> Meniji { get; set; }

        public DbSet<ProstorZakazani> ZakazaniDatumi { get; set; }

        public DbSet<ProstorRezervisani> RezervisaniDatumi { get; set; }

        public DbSet<FotografRezervisani> FotografiRezervisaniD { get; set; }

        public DbSet<FotografZakazani> FotografiZakazaniD { get; set; }

        public DbSet<DekoracijaRezervisani> DekoracijaRezervisaniD { get; set; }

        public DbSet<DekoracijaZakazani> DekoracijaZakazaniD { get; set; }

        public DbSet<MuzikaRezervisani> MuzikaRezervisaniD { get; set; }

        public DbSet<MuzikaZakazani> MuzikaZakazaniD { get; set; }

        public DbSet<Slika> Slike { get; set; }

        public DbSet<Planer> Planeri { get; set; }

        public DbSet<Narudzbina> Narudzbine { get; set; }

        public DbSet<Napomena> Napomene { get; set; }
    }
}
