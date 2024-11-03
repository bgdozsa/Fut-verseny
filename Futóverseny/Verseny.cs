using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futóverseny
{
    class Verseny
    {
        public Pálya pálya;
        public SortedSet<int> győztesek;
        private List<Versenyző> versenyzők;
        private int versenyzőkSzáma;
        private const int SZÜNET = 100; //várakozás ezredmásodpercben a lépések között

        public void Start()
        {
            Console.Title = "Futóverseny";
            //Beolvassuk a versenyzők számát:
            Console.Write($"A versenyzők száma (< {Console.LargestWindowHeight - 9}): ");
            versenyzőkSzáma = Convert.ToInt32(Console.ReadLine());
            //létrehozzuk a versenyzőobjektumokat (tömbelemek):
            versenyzők = new List<Versenyző>();
            for (int i = 0; i < versenyzőkSzáma; i++)
            {
                versenyzők.Add(new Versenyző());
                versenyzők[i].Létrehoz(i);
                Vár(10);    //A várakozásra azért van szükség, mert ha a versenyzők nagyon gyorsan egymás után hozzák létre a Random objektumokat, akkor azonos lesz a sorozatok kezdőértéke. (A kezdőértéket a rendszeridőből határozza meg.)

            }
            //Létrehozzuk a pályaobjektumot, Kirajzoljuk a pályát:
            pálya = new Pálya();
            pálya.Létrehoz(versenyzőkSzáma);
            //Elindítjuk a versenyt:
            győztesek = new SortedSet<int>();
            Futás();
            //Kiírjuk a győzteseket:
            Eredmény();
            Console.Write("(Enter: kilép)");
            Console.ReadLine();
        }

        private void Futás()
        {
            do
            {
                Console.CursorTop = 0;
                for (int i = 0; i < versenyzőkSzáma; i++)
                    versenyzők[i].Fut(this);
                Vár(SZÜNET);
            } while (győztesek.Count == 0);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Vége a versenynek.");
        }

        private void Eredmény()
        {
            Console.Write("Győzött: ");
            foreach (var győztes in győztesek)
            {
                Console.Write($"{győztes} ");
            }
            Console.WriteLine();
        }

        private void Vár(int időtartam)
        {
            System.Threading.Thread.Sleep(időtartam);
        }




    }
}
