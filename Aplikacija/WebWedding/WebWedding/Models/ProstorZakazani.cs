using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebWedding.Models
{
    public class ProstorZakazani
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Prostor")]
        //public int IdProstora { get; set; }

        [DataType(DataType.Date)]
        public DateTime datum { get; set; }

        [Required]
        public Prostor MojProstor { get; set; }
    }
}
