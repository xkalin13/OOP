using System;
using System.Collections.Generic;
using System.Linq;

namespace cv7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[] { 1, 5, 3, 7, 9 };
            string[] stringArray = new string[] { "first", "second", "third","fourth", "fifth" };
            //obj
            Kruh[] kruhArray = new Kruh[] { new Kruh(1), new Kruh(2) };
            Obdelnik[] obdelnikArray = new Obdelnik[] { new Obdelnik(1, 2), new Obdelnik(3, 4), new Obdelnik(5, 6), new Obdelnik(7, 8)};
            Elipsa[] elipsaArray = new Elipsa[] { new Elipsa(1, 2), new Elipsa(3, 4)};
            Trojuhelnik[] trojuhelnikArray = new Trojuhelnik[] { new Trojuhelnik(1, 2), new Trojuhelnik(3, 4)};
            Ctverec[] ctverecArray = new Ctverec[] { new Ctverec(1), new Ctverec(2), new Ctverec(3), new Ctverec(4)};            

            //2D obj - obsahne vsechny
            Objekt2D[] objArray = new Objekt2D[] { new Kruh(3), new Obdelnik(6,9), new Elipsa(12, 15), new Trojuhelnik(18, 21), new Ctverec(24), new Ctverec(27)};

            //extremy
            Console.WriteLine("Nejvetsi " + Extremy.Nejvetsi(kruhArray));
            Console.WriteLine("Nejmensi " + Extremy.Nejmensi(kruhArray));
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("Nejvetsi " + Extremy.Nejvetsi(obdelnikArray));
            Console.WriteLine("Nejmensi " + Extremy.Nejmensi(obdelnikArray));
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("Nejvetsi " + Extremy.Nejvetsi(elipsaArray));
            Console.WriteLine("Nejmensi " + Extremy.Nejmensi(elipsaArray));
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("Nejvetsi " + Extremy.Nejvetsi(trojuhelnikArray));
            Console.WriteLine("Nejmensi " + Extremy.Nejmensi(trojuhelnikArray));
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("Nejvetsi " + Extremy.Nejvetsi(ctverecArray));
            Console.WriteLine("Nejmensi " + Extremy.Nejmensi(ctverecArray));
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("Nejvetsi " + Extremy.Nejvetsi(objArray));
            Console.WriteLine("Nejmensi " + Extremy.Nejmensi(objArray));
            Console.WriteLine("---------------------------------------------");

            IEnumerable<int> linqFilter = intArray.Where(x => x >= 4 && x <= 8);
            Console.WriteLine("Vypis linq v rozmezi 4-8");

            foreach (var item in linqFilter)
            {
                Console.WriteLine(item);
            }

        }
    }
}
