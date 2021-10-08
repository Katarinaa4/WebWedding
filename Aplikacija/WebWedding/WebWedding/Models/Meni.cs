using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebWedding.Models;

namespace WebWedding.Models
{
    public class Meni
    {
        //da li da kljuc bude kombinacija IdProstora + Naziv, ili da uvedemo Id? mislim bolje surogat kljuc

        [Key]
        public int Id { get; set; }

        //[Required]
        //public int IdProstora { get; set; } //ovo nam sluzi da znamo svaki meni kom restoranu pripada

        [Required]
        public string Naziv { get; set; }

        //da li da stavimo ovde required, jer generalno moramo da imamo cenu, da bi mogli da racunamo posle
        public double Cena { get; set; }

        public string Opis { get; set; }

        public string Slika { get; set; }

        [Required]
        public Prostor MojProstor { get; set; }

        public string Status { get; set; }

    }
}
