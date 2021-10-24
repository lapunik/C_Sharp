using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Truck: Car
    {
        // položky

        private readonly int loadLimit;

        // konstruktory  

        public Truck(string type, int loadLimit) : base(type,100)
        {

            this.loadLimit = loadLimit;
        }

        // metody

        public override string ToString()
        {
            return base.ToString() + " and load limit: " + loadLimit;
        }
    }
}
