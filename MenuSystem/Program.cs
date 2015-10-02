using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Draw Menu Title
            drawtitle();

            //Declare keypress CKI
            ConsoleKeyInfo keypress;

            //Declare menuItem array
            string[] menuItem = new string[4];

            //Initialize menuItem array
            menuItem[0] = "Menu Item One";
            menuItem[1] = "Menu Item Two";
            menuItem[2] = "Menu Item Three";
            menuItem[3] = "Menu Item Four";

            //Set initial menu selection
            int csel = 0;

            while (true)
            {
                drawMenu(csel, menuItem);
                //Draw main menu area

                //Wait for keypress
                keypress = Console.ReadKey();

                //Reset last selection
                Console.SetCursorPosition(0, csel + 5);
                menuItem[csel] = menuItem[csel].Substring(2, menuItem[csel].Length - 2);
                ClearCurrentConsoleLine();
                
                //Respond to keypress
                if ((keypress.Key == ConsoleKey.UpArrow) && (csel != 0))
                {
                    csel--;
                }
                else if (((keypress.Key == ConsoleKey.DownArrow) && (csel != menuItem.Length - 1)))
                {
                    csel++;
                }
            }
        }

        static void drawtitle()
        {
            //Set Title
            const string title = "Menu System";
            //Set border
            const string border = "---------------------";

            //Set test offset
            int toffset = ((Console.WindowWidth / 2) + (title.Length / 2));
            //Set border offset
            int boffset = ((Console.WindowWidth / 2) + (border.Length / 2));

            //Draw
            Console.WriteLine(String.Format("{0," + boffset + "}", border));
            Console.WriteLine(String.Format("{0," + toffset + "}", title));
            Console.WriteLine(String.Format("{0," + boffset + "}", border));
        }

        static void drawMenu(int csel, string[] menuItem)
        {
            //Add selection pointer
            menuItem[csel] = "> " + menuItem[csel];

            Console.SetCursorPosition(0, 5);

            foreach (var s in menuItem)
            {
                Console.WriteLine(s);
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int clc = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, clc);
        }

    }
}
