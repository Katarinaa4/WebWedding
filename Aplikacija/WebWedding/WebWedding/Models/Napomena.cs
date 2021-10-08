using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebWedding.Models
{
    public class Napomena
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SadrzajNapomene { get; set; }

        [Required]
        public DateTime DatumKreiranja { get; set; }

        public Prostor MojProstor { get; set; }

        public Muzika MojaMuzika { get; set; }

        public Dekoracija MojaDekoracija { get; set; }

        public Fotograf MojFotograf { get; set; }
    }
}
