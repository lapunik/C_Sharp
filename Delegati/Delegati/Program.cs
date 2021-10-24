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

    // Ukázková aplikace pro používání delegátů a anonymních funkcí

    class Program
    {

        static void Main(string[] args)
        {
            // inicializace kolekce
            Cisla cisla = new Cisla();
            Console.WriteLine(cisla);

            // operace a výpis
            cisla.ProvedOperaci((a) => a * a);
            Console.WriteLine(cisla);

            cisla.ProvedOperaci((a) => a * 2);
            Console.WriteLine(cisla);     
             
            Console.ReadKey();
        }
    }
}
