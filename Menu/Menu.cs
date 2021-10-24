using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class Menu
    {
        private List<string> menuItems;

        private void CoDal(string moznost)
        {

            if (moznost == "Hrát")
            {



            }
            else if (moznost == "Hrát ve dvou hráčích")
            {



            }
            else if (moznost == "Exit")
            {
                Environment.Exit(0);
            }
        }

        public void RozbalMoznosti(string text)
        {
            
            menuItems = text.Split(',').ToList<string>();

            Console.CursorVisible = false;

            int index = 0;

            while (true)
            {

                for (int i = 0; i < menuItems.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine(menuItems[i]);
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo ckey = Console.ReadKey();

                if (ckey.Key == ConsoleKey.DownArrow)
                {
                    if (index == menuItems.Count - 1)
                    {
                        index = 0;
                    }
                    else { index++; }
                }
                else if (ckey.Key == ConsoleKey.UpArrow)
                {
                    if (index <= 0)
                    {
                        index = menuItems.Count - 1;
                    }
                    else { index--; }
                }
                else if (ckey.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    CoDal(menuItems[index]);

                }


                Console.Clear();
            }

        }
    }
}