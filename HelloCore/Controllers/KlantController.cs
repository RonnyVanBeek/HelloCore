using HelloCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Controllers
{
    public class KlantController : Controller
    {
        public IActionResult Index()
        {
            List<Klant> klanten = new List<Klant>();

            klanten.Add(new Klant() { KlantId = 1, Naam = "De Neve", Voornaam = "Anneleen", AangemaaktDatum = new DateTime(2019, 1, 20) });
            klanten.Add(new Klant() { KlantId = 2, Naam = "Bruynseels", Voornaam = "Nele", AangemaaktDatum = new DateTime(2020, 2, 4) });
            klanten.Add(new Klant() { KlantId = 1, Naam = "Naert", Voornaam = "Joris", AangemaaktDatum = new DateTime(2020, 1, 5) });

            return View(klanten);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}