using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{

    /*
     *	       __          __                __            
     *	  ____/ /__ _   __/ /_  ____  ____  / /__ _________
     *	 / __  / _ \ | / / __ \/ __ \/ __ \/ //_// ___/_  /
     *	/ /_/ /  __/ |/ / /_/ / /_/ / /_/ / ,< _/ /__  / /_
     *	\__,_/\___/|___/_.___/\____/\____/_/|_(_)___/ /___/
     *                                                   
     *                                                           
     *      TUTORIÁLY  <>  DISKUZE  <>  KOMUNITA  <>  SOFTWARE
     * 
     *	Tento zdrojový kód je součástí tutoriálů na programátorské 
     *	sociální síti WWW.DEVBOOK.CZ	
     *	
     *	Kód můžete upravovat jak chcete, jen zmiňte odkaz 
     *	na www.devbook.cz :-) 
     */

    class Kinosal
    {
        private bool[,] sedadla = new bool[30, 15];
        private const int velikost = 16;
        private const int mezera = 2;

        public void Vykresli(Graphics g)
        {
            Brush brush;
            for (int j = 0; j < sedadla.GetLength(1); j++)
            {
                for (int i = 0; i < sedadla.GetLength(0); i++)
                {
                    if (sedadla[i, j])
                        brush = Brushes.Green;
                    else
                        brush = Brushes.Red;
                    g.FillRectangle(brush, i * (velikost + mezera), j * (velikost + mezera), velikost, velikost);
                }
            }

        }

    }
}
