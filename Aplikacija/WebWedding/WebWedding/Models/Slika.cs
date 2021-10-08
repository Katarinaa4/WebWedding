using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebWedding.Models
{
    public class Slika
    {
        [Key]
        public int Id { get; set; }

        public string slika { get; set; }
    }
}
