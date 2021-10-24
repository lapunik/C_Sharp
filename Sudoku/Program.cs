using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        
        static int[,] grid = new int[9, 9];
        static string s;
        static void Init(ref int[,] grid)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j] = (i * 3 + i / 3 + j) % 9 + 1;

                }
            }
        }
        static void Draw(ref int[,] grid, out string _s)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    s += grid[x, y].ToString() + " ";
                }
                s += "\n";
            }
            Console.WriteLine(s);
            _s = s;
            s = "";
        }

        static void ChangeTwoCell(ref int[,] grid, int findValue1, int findValue2)
        {
            int xParm1, yParm1, xParm2, yParm2;

            xParm1 = yParm1 = xParm2 = yParm2 = 0;

            for (int i = 0; i < 9; i += 3) //výběr devítice
            {
                for (int k = 0; k < 9; k += 3) // výběr devítice
                {
                    for (int j = 0; j < 3; j++) // výběr konkrétního čísla 
                    {
                        for (int z = 0; z < 3; z++) // výběr konkrétního čísla
                        {
                            if (grid[i + j, k + z] == findValue1) // pokud narazím na hodnotu kterou chci, uložím si indexy (devítice + konkrítní čílso)
                            {
                                xParm1 = i + j;
                                yParm1 = k + z;

                            }
                            if (grid[i + j, k + z] == findValue2) // pokud narazím na hodnotu kterou chci, uložím si indexy (devítice + konkrítní čílso)
                            {
                                xParm2 = i + j;
                                yParm2 = k + z;

                            }
                        }
                    }
                    grid[xParm1, yParm1] = findValue2;
                    grid[xParm2, yParm2] = findValue1;
                    // prohození nalezených čísel, toto se provede devětkrát (pro každnou devítici čísel jednou) 
                }
            }
        }

        static void Update(ref int[,] grid, int shuffleLevel)
        {

            for (int repeat = 0; repeat < shuffleLevel; repeat++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                Random rand2 = new Random(Guid.NewGuid().GetHashCode());
                ChangeTwoCell(ref grid, rand.Next(1, 9), rand2.Next(1, 9));
                //Draw(ref grid, out string p);
                //Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {
            s = "";
            string ç1kt1;
            for (int i = 0; i < 2; i++)
            {
                Init(ref grid);
                Update(ref grid, 10);
                Draw(ref grid, out ç1kt1);
            }


            Console.ReadKey();
        }
    }
}
