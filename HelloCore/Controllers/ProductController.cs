using HelloCore.Models;
using HelloCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        public List<Product> producten;

        public ProductController()
        {
            producten = new List<Product>();
            producten.Add(new Product() { Naam = "fiets", ProductId = 1, Prijs = 50, Merk = "Sparta", Beschrijving = "Dit is een gewone fiets" });
            producten.Add(new Product() { Naam = "auto", ProductId = 2, Prijs = 2000, Merk = "BMW", Beschrijving = "Dit is een auto van BMW" });
            producten.Add(new Product() { Naam = "koersfiets", ProductId = 3, Prijs = 1000, Merk = "Dynafit", Beschrijving = "Dit is een koersfiets van Dynafit." });
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ProductlistViewModel viewModel = new ProductlistViewModel();
            viewModel.Producten = producten;
            return View(viewModel);
        }

        public IActionResult Search(ProductlistViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.ProductSearch))
            {
                //string search = viewModel.ProductSearch.ToLower();
                viewModel.Producten = producten.Where(b => b.Naam.Contains(viewModel.ProductSearch)).ToList();
            }
            else
            {
                viewModel.Producten = producten;
            }
            return View("Index", viewModel);
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            Product product = producten.Where(prod => prod.ProductId == id).FirstOrDefault();
            if (product != null)
            {
                ProductDetailViewModel viewModel = new ProductDetailViewModel()
                {
                    Naam = product.Naam,
                    Prijs = product.Prijs,
                    Merk = product.Merk,
                    Beschrijving = product.Beschrijving
                };
                return View(viewModel);
            }
            else
            {
                ProductlistViewModel vm = new ProductlistViewModel();
                vm.Producten = producten;
                return View("Index", vm);
                //OFWEL ==> Index();
            }
        }
    }
}