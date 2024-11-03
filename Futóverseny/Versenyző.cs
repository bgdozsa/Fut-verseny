using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futóverseny
{
    class Versenyző
    {
        private const int maxLépés = 6;
        private ConsoleColor[] színek = { ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.White };
        private Random vélszám = new Random();
        private int mez;    //a versenyző mezének sorszáma
        private ConsoleColor szín;   //a versenyző mezének színe
        private int helyzet;    //a versenyző pozíciója a pályán
        private string szóközök;    //az előző helyzet törléséhez, a mezszám karaktereinek a száma

        public void Létrehoz(int sorszám)
        {
            mez = sorszám + 1;
            szín = színek[vélszám.Next(0, színek.Length)];
            helyzet = 0;

            string s = "";
            for (int i = 0; i < mez.ToString().Length; i++)
                s += " ";
            szóközök = s; // a mezszám karaktereinek a száma
        }

        public void Fut(Verseny verseny)
        {
            Console.CursorLeft = helyzet;
            Console.Write(szóközök); //letöröljük az előző helyet
            helyzet += vélszám.Next(1, maxLépés + 1); //nem hat vissza a listaelemre, ezért kell a return, ha viszont objektum listát használok struktúra helyett, akkor nem kell return
            if (helyzet >= verseny.pálya.hossz) //a versenyző beért a célba
            {
                verseny.győztesek.Add(mez);
                //Töröljük a célvonalat a versenyző sorában:
                Console.CursorLeft = verseny.pálya.hossz;
                Console.Write(" ");
            }
            //Megjelenítjük a versenyző helyzetét:
            Kiír();
        }

        private void Kiír()
        {
            Console.CursorLeft = helyzet;
            Console.ForegroundColor = szín;
            Console.WriteLine(mez);
        }

    }
}
