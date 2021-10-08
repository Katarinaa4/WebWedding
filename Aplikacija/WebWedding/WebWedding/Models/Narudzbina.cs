using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebWedding.Models
{
    public class Narudzbina
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public string Adresa { get; set; }

        [Required]
        public string BrojTelefona { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public double UkupnaCena { get; set; }

        public string Status { get; set; }

        public Korisnik MojKorisnik { get; set; }
        public Planer MojPlaner { get; set; }
        public bool? Arhivirano { get; set; }
    }
}
