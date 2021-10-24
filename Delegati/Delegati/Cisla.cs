using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegati
{
    /*
     *  _____ _______         _                      _              
     * |_   _|__   __|       | |                    | |             
     *   | |    | |_ __   ___| |___      _____  _ __| | __  ___ ____
     *   | |    | | '_ \ / _ \ __\ \ /\ / / _ \| '__| |/ / / __|_  /
     *  _| |_   | | | | |  __/ |_ \ V  V / (_) | |  |   < | (__ / / 
     * |_____|  |_|_| |_|\___|\__| \_/\_/ \___/|_|  |_|\_(_)___/___|
     *                                                                                                          
     * IT ZPRAVODAJSTVÍ  <>  PROGRAMOVÁNÍ  <>  HW A SW  <>  KOMUNITA
     * 
     * Tento zdrojový kód je součástí výukových seriálů na 
     * IT sociální síti WWW.ITNETWORK.CZ	
     *	
     * Kód spadá pod licenci prémiového obsahu a vznikl díky podpoře
     * našich členů. Je určen pouze pro osobní užití a nesmí být šířen.
     *
     */

    /// <summary>
    /// Kolekce čísel, na kterých lze provádět různé operace
    /// </summary>
    class Cisla
    {
        /// <summary>
        /// Vnitřní kolekce čísel
        /// </summary>
        private List<int> cisla = new List<int>();

        /// <summary>
        /// Naplní vnitřní kolekci čísel testovacími daty
        /// </summary>
        public Cisla()
        {
            for (int i = 0; i < 10; i++)
            {
                cisla.Add(i + 1);
            }

        }

        /// <summary>
        /// Provede danou operaci nad kolekcí
        /// </summary>
        /// <param name="operace">Operace jako delegát</param>
        public void ProvedOperaci(Func<int, int> operace)
        {
            for (int i = 0; i < 10; i++)
            {
                cisla[i] = operace(cisla[i]);
            }
        }

        /// <summary>
        /// Vrátí textovou reprezentaci prvků v kolekci
        /// </summary>
        /// <returns>Textová reprezentace prvků v kolekci</returns>
        public override string ToString()
        {
            string vystup = "";
            foreach (int cislo in cisla)
            {
                vystup += cislo + ", ";
            }
            return vystup;
        }

    }
}
