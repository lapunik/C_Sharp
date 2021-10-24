using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCKalkulacka.Models
{
    public class Kalkulacka
    {
        [Display(Name = "1. číslo")]
        [Range(1, 100, ErrorMessage = "Zadejte prosím číslo od 1 do 100.")]

        public int Cislo1 { get; set; }
        [Display(Name = "2. číslo")]
        [Range(1, 100, ErrorMessage = "Zadejte prosím číslo od 1 do 100.")]
        public int Cislo2 { get; set; }
        public double Vysledek { get; set; }
        [Display(Name = "1. číslo")]
        public string Operace { get; set; }
        public List<SelectListItem> MozneOperace { get; set; }
        public string nazev { get; set; }

        public Kalkulacka() // v konstruktoru přidáme list z možnostmi operací
        {
            MozneOperace = new List<SelectListItem>();
            MozneOperace.Add(new SelectListItem { Text = "Sečti", Value = "+", Selected = true });
            MozneOperace.Add(new SelectListItem { Text = "Odečti", Value = "-" });
            MozneOperace.Add(new SelectListItem { Text = "Vynásob", Value = "*" });
            MozneOperace.Add(new SelectListItem { Text = "Vyděl", Value = "/" });
        }

        public void Vypocitej()
        {

            switch (Operace)
            {
                case "+":
                    Vysledek = (double)Cislo1 + (double)Cislo2;
                    break;
                case "-":
                    Vysledek = (double)Cislo1 - (double)Cislo2;
                    break;
                case "*":
                    Vysledek = (double)Cislo1 * (double)Cislo2;
                    break;
                case "/":
                    if (Cislo2 != 0)
                    {
                        Vysledek = (double)Cislo1 / (double)Cislo2;
                    }
                    break;
            }
        }

    }
}
