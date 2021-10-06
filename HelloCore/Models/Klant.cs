using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Models
{
    public class Klant
    {
        public int KlantId { get; set; }

        [Required(ErrorMessage = "Het veld naam moet altijd ingevuld zijn.")]
        [MaxLength(10)]
        public string Naam { get; set; }

        [MaxLength(10), MinLength(3)]
        public string Voornaam { get; set; }

        [Display(Name = "Datum aangemaakt")]
        [DataType(DataType.Date)]
        public DateTime AangemaaktDatum { get; set; }

        public ICollection<Bestelling> Bestellingen { get; set; }
    }
}