using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futóverseny
{
    class Pálya
    {
        public int hossz;

        public void Létrehoz(int versenyzőkSzáma)
        {
            //Az ablak méretének módosítása:
            hossz = Console.WindowWidth - 10;
            Console.WindowHeight = versenyzőkSzáma + 5;
            //A célvonal kirajzolása:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < versenyzőkSzáma; i++)
            {
                Console.SetCursorPosition(hossz, i);
                Console.Write("|");
            }
        }

    }
}
