using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebWedding.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebWedding
{
    public class Fotograf
    {
        [Key]
        public int Id { get; set; }

        //naknadno cemo videti treba li ogranicenja 

        public string Slika { get; set; }

        public string Opis { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Link { get; set; }


        public ICollection<FotografZakazani> Zakazani { get; set; }

        public ICollection<FotografRezervisani> Rezervisani { get; set; } 

        public double Cena { get; set; }

        public string StatusPrikaza { get; set; }

        public DateTime DatumVazenja { get; set; }

        public ICollection<Zahtev> ListaZahteva { get; set; }

        public ICollection<Napomena> ListaNapomena { get; set; }
    }
}
