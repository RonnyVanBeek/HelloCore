using HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.ViewModels
{
    public class ProductlistViewModel
    {
        public string ProductSearch { get; set; }
        public List<Product> Producten { get; set; }
    }
}