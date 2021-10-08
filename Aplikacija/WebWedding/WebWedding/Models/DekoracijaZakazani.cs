using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebWedding.Models
{
    public class DekoracijaZakazani
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime datum { get; set; }

        [Required]
        public Dekoracija MojaDekoracija { get; set; }
    }
}
