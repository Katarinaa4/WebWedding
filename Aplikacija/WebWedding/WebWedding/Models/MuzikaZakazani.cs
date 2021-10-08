using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebWedding.Models
{
    public class MuzikaZakazani
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime datum { get; set; }

        [Required]
        public Muzika MojaMuzika { get; set; }
    }
}
