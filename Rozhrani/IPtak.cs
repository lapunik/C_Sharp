using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozhrani
{
    interface IPtak
    {

        void Pipni();
        void Dychej();

        //void Klovni();  // Pokud zde nastavím pouze nějaké metody, tak zbytek nebudu moci volat v program.cs ptak.blabla

    }
}
