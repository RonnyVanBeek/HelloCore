using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloCore/

        public string Index()
        {
            return "Dit is de 'index' action method";
        }

        // GET: /HelloCore/Welkom/

        public string Welkom()
        {
            return "Dit is de welkom Action Method";
        }

        public string Bestelling(int id)
        {
            return "Dit zijn de details van bestelling met id " + id;
        }

        public string Boodschap(string voornaam, string boodschap)
        {
            return "Boodschap van " + voornaam + ": " + boodschap;
        }
    }
}