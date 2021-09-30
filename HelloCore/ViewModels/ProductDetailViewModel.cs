using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.ViewModels
{
    public class ProductDetailViewModel
    {
        public string Naam { get; set; }
        public Decimal Prijs { get; set; }
        public string Merk { get; set; }
        public string Beschrijving { get; set; }
    }
}