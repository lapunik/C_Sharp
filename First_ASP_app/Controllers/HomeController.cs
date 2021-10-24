using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_ASP_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVCNahodneCislo.Controllers
{
    public class HomeController : Controller
    {

        // v kontroleru kolekci naplníme daty z modelu a v pohledu je vypíšeme do HTML šablony

        public IActionResult Index() // Právě v této metodě vytvoříme instanci modelu, získáme si od něj data a tato data předáme pohledu
        {
            Generator generator = new Generator(); // přístup k našemu modelu (tam budou ty články atd..)
            ViewBag.Cislo = generator.VratCislo(); // do bagu (tašky) uloč číslo které pak budeme vypisovat v view
            return View(); // objekt, který po dokončení požadavku zasíláme zpět prohlížeči 
            // takže jsme vlastně zareagovali na požadavek na indexovou stránku a propojili model s pohledem
        }
    }
}