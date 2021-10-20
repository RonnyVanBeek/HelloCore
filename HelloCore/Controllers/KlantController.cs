using HelloCore.Data;
using HelloCore.Models;
using HelloCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Controllers
{
    [Authorize]
    public class KlantController : Controller
    {
        private readonly HelloCoreContext _context;

        public KlantController(HelloCoreContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            KlantListViewModel viewModel = new KlantListViewModel();
            viewModel.Klanten = await _context.Klanten.ToListAsync();
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlantID,Naam,Voornaam,AangemaaktDatum")] Klant klant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klant);
                await _context.SaveChangesAsync(); //wacht met opslaan tot alle verschillende stappen succesvol zijn.
                return RedirectToAction(nameof(Index));//Vooraf gedefinieerde actie "Index" bovenaan opnieuw uitvoeren.
            }
            CreateKlantViewModel vm = new CreateKlantViewModel()
            {
                AangemaaktDatum = klant.AangemaaktDatum,
                Naam = klant.Naam,
                Voornaam = klant.Voornaam
            };
            return View(vm);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Klant klant = await _context.Klanten.FindAsync(id);

            if (klant == null)
            {
                return NotFound();
            }

            DetailsKlantViewModel vm = new DetailsKlantViewModel()
            {
                Naam = klant.Naam,
                Voornaam = klant.Voornaam,
                AangemaaktDatum = klant.AangemaaktDatum
            };

            return View(vm);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Klant klant = await _context.Klanten.FindAsync(id);

            if (klant == null)
            {
                return NotFound();
            }

            EditKlantViewModel vm = new EditKlantViewModel()
            {
                Naam = klant.Naam,
                Voornaam = klant.Voornaam,
                AangemaaktDatum = klant.AangemaaktDatum
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Naam,Voornaam,AangemaaktDatum")] Klant klant)
        {
            klant.KlantId = id;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) //als dezelfde klant al werd aangepast
                {
                    if (!KlantExists(klant.KlantId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            EditKlantViewModel vm = new EditKlantViewModel()
            {
                AangemaaktDatum = klant.AangemaaktDatum,
                Naam = klant.Naam,
                Voornaam = klant.Voornaam,
                KlantId = klant.KlantId
            };
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var klant = await _context.Klanten.FirstOrDefaultAsync(m => m.KlantId == id);
            //var klan = await _context.Klanten.FirstAsync(id); ==> ZELFDE RESULTAAT ALS BOVENSTAANDE

            if (klant == null)
            {
                return NotFound();
            }

            DeleteKlantViewModel vm = new DeleteKlantViewModel()
            {
                AangemaaktDatum = klant.AangemaaktDatum,
                Naam = klant.Naam,
                Voornaam = klant.Voornaam
            };
            return View(vm);
        }

        //POST: (Localhost)/Klant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klant = await _context.Klanten.FindAsync(id);
            _context.Klanten.Remove(klant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlantExists(int id)
        {
            Klant klant = _context.Klanten.Find(id);
            if (klant != null)
            {
                return true;
            }
            return false;
        }
    }
}