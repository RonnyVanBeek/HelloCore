using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Naam { get; set; }
        public Decimal Prijs { get; set; }
        public string Merk { get; set; }
        public string Beschrijving { get; set; }
    }
}