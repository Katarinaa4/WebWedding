using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebWedding.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebWedding
{
    public class Muzika
    {
        [Key]
        public int Id { get; set; }

        //naknadno cemo videti treba li ogranicenja 

        public int BrojZvezdica { get; set; }

        public string Slika { get; set; }

        public string Opis { get; set; }

        public string Naziv { get; set; }

        public string Link { get; set; }

        public ICollection<MuzikaZakazani> Zakazani { get; set; }

        public ICollection<MuzikaRezervisani> Rezervisani { get; set; } 

        public double Cena { get; set; }

        public string StatusPrikaza { get; set; }

        public DateTime DatumVazenja { get; set; }

        public ICollection<Zahtev> ListaZahteva { get; set; }

        public ICollection<Napomena> ListaNapomena { get; set; }
    }
}
