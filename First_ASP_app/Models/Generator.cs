using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_ASP_app.Models
{
    public class Generator
    {

        // tímto způsobem bychom vraceli například článek z databáze

        private Random random = new Random();

        public int VratCislo()
        {
            return random.Next(100);
        }

    }
}
