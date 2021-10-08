using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebWedding.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebWedding
{
    public class Prostor
    {
        public Prostor()
        {
            ListaMenija = new List<Meni>();
        }

        [Key]
        public int Id { get; set; }

        [Range(0, 5)]
        public int BrojZvezdica { get; set; }

        //naknadno cemo videti treba li ogranicenja 

        public string Slika { get; set; }

        public string Opis { get; set; }

        public string Naziv { get; set; }

        public string Adresa { get; set; }

        public string Link { get; set; }

        public int Kapacitet { get; set; }

        // Meni je slozeni atribut, treba li nam nova klasa za njega?
        // Slozeni atribut se preslikava u novu tabelu, tako da bi trebalo i klasa za njega

        //Imam pitanje, kako ce ove liste DateTime da se preslikaju u bazu? To bi trebalo da bude nova tabela
        //koja ce imati referencu na prostor i onda nova stavka u tabeli za svaki rezervisani/zakazani datum
   
        public ICollection<ProstorZakazani> Zakazani { get; set; }

        public ICollection<ProstorRezervisani> Rezervisani { get; set; }

        public ICollection<Meni> ListaMenija { get; set; }

        public string StatusPrikaza { get; set; }

        public DateTime DatumVazenja { get; set; }

        public ICollection<Zahtev> ListaZahteva { get; set; }

        public ICollection<Napomena> ListaNapomena { get; set; }
    }
}
