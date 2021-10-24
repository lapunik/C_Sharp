using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Car
    {
        //Položky

        private int maxSpeed;

        private readonly string type;

        //Konstruktory

        public Car(string type)
        {
            this.type = type;
        }

        public Car(string type, int maxSpeed)
        {
            this.type = type;
            this.maxSpeed = maxSpeed;
        }

        // Vlastnoti

        public int MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                maxSpeed = value;
            }
        }

        // Metody

        public override string ToString()
        {
            if (MaxSpeed != 0)
            {
                return type + " with maximal speed: " + MaxSpeed + "km/h";
            }
            else {
                return type + " with maximal unknow speed";
            }
        }

        public string Porovnej(Car autoDva)
        {
            if (autoDva.MaxSpeed < MaxSpeed)
            {
                return type;
            }
            else if (autoDva.MaxSpeed < MaxSpeed)
            {
                return autoDva.type;
            }
            else
            {
                return "Auta jsou stejně rychlá";
            }
        }
        

    }
            

}
