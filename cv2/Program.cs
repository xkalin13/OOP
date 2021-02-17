using System;

namespace cv2
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] re = new double[3];
            double[] im = new double[3];
            char op;
            Console.WriteLine("Zadej 3 komplexni cisla, 1,2, ocekavany vysledek a operator");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Zadej realnou slozku" + i + "teho cisla");
                re[i] = double.Parse(Console.ReadLine());
                Console.WriteLine("Zadej imaginarni slozku" + i + "teho cisla");
                im[i] = double.Parse(Console.ReadLine());
                Console.WriteLine("Cislo je ve tvaru: "+re[i]+"    "+im[i]+"j");
            }
            Console.WriteLine("zadej operator");
            op = Console.ReadLine()[0];


                TestComplex.Test(
                    new Complex(im[0],re[0]),
                    new Complex(im[1], re[1]),
                    new Complex(im[2], re[2]),op);
            Console.ReadLine();
        }
    }
}
