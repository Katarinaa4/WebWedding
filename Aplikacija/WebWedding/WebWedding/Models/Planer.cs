using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebWedding.Models
{
    public class Planer
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public double Cena { get; set; }

        [Required]
        public string Slika { get; set; }

        [Required]
        public int BrojPlaneraNaRaspolaganju { get; set; }

        public string Status { get; set; }

    }
}
