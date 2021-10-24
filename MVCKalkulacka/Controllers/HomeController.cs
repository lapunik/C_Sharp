using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCKalkulacka.Models;

namespace MVCKalkulacka.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Kalkulacka kalkulacka = new Kalkulacka();
            return View(kalkulacka); // celý model předáme jako parametr
        }

        [HttpPost] // metoda se spustí pouze pokud byl odelaný formuář, POST = data odeslané uvnitř HTTP požadavku (slouží hlavně pro vkládání nových dat)
        public IActionResult Index(Kalkulacka kalkulacka)
        {
            if (ModelState.IsValid) // validace modelu
            {
                kalkulacka.Vypocitej();
            }

            return View(kalkulacka);
        }

        [HttpGet] // předávání parametrů v adrese url
        public IActionResult Index(string jmeno)
        {

            Kalkulacka kalkulacka = new Kalkulacka();
            kalkulacka.nazev = jmeno;
            ViewBag.Jmeno = jmeno;
            return View(kalkulacka); // celý model předáme jako parametr

        }
    }
}