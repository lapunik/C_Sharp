using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VicerozmerovaPole
{
    class Program
    {
        static void Main(string[] args)
        {


            // deklarace
            char[,] pole = new char[5, 5];

            for (int j = 0; j < pole.GetLength(1); j++) //GetLength(x)...x=0 počet řádků...x=1 počet sloupců...x=2 pro více dimenzá atd.
            {
                for (int i = 0; i < pole.GetLength(0); i++)
                {
                    pole[i, j] = 'O';
                }
            }

            // naplnění daty

            pole[1, 1] = 'X'; // 

            for (int i = 0; i < 5; i++) // 4. řádek
            {
                pole[2, i] = 'X';
            }
            for (int i = 0; i < 5; i++) // Poslední řádek
            {
                pole[i, 3] = 'X';
            }

            for (int j = 0; j < pole.GetLength(1); j++)
            {
                for (int i = 0; i < pole.GetLength(0); i++)
                {
                    Console.Write(pole[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}