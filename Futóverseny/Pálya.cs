using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futóverseny
{
    class Pálya
    {
        public int pályaHossz;

        public void Létrehoz(int versenyzőkSzáma)
        {
            //Az ablak méretének módosítása:
            pályaHossz = Console.WindowWidth - 10;
            Console.WindowHeight = versenyzőkSzáma + 5;
            //A célvonal kirajzolása:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < versenyzőkSzáma; i++)
            {
                Console.SetCursorPosition(pályaHossz, i);
                Console.Write("|");
            }
        }

    }
}
