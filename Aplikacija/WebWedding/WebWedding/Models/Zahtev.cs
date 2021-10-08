using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebWedding.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebWedding
{
    public class Zahtev
    {
        [Key]
        public int Id { get; set; }

        public double UkupnaCena { get; set; }

        //za meni, da li treba da pamti id menija, a da nam meni bude posebna klasa
        //mislim da je tako ok, vrv treba da se pamti i izabrani meni

        
        [ForeignKey("KorisnikId")]
        public Korisnik MojKorisnik { get; set; }

        
        public Fotograf MojFotograf { get; set; }

        public Dekoracija MojaDekoracija { get; set; }
        public Muzika MojaMuzika { get; set; }
        public Prostor MojProstor { get; set; }
        public Meni MojMeni { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumPodnosenjaZahteva { get; set; }

        [DataType(DataType.Date)]
        public DateTime IzabraniDatum { get; set; }

        public string Status { get; set; }

        public int? BrojGostiju { get; set; }
         public bool Poslato { get; set; }
        public bool? PotvrdjenoProstor { get; set; }
        public bool? PotvrdjenoMeni { get; set; }
        public bool? PotvrdjenoMuzika { get; set; }
        public bool? PotvrdjenoFotograf { get; set; }
        public bool? PotvrdjenoDekoracija { get; set; }
        public bool? Arhivirano { get; set; }
    }

}
