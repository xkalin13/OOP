using System;

namespace cv5
{
    class Program
    {
        static void Main(string[] args)
        {
                                         
            Nakladni nakladniAuto = new Nakladni(Auto.TypPaliva.Benzin,200,100); //TYP, vel.Nadrz, vel.Naklad
                nakladniAuto.Natankuj(Auto.TypPaliva.Benzin, 48.8);
                nakladniAuto.SetPrepravovanyNaklad(50);
                Console.WriteLine(nakladniAuto);

                nakladniAuto.ZapnoutRadio(true);
                nakladniAuto.NastavPredvolbu(1, 88.2);
                nakladniAuto.NastavPredvolbu(3, 85.5);
                nakladniAuto.PreladNaPredvolbu(1);

                nakladniAuto.RadioToString();
                nakladniAuto.PreladNaPredvolbu(3);
                nakladniAuto.RadioToString();

                nakladniAuto.Natankuj(Auto.TypPaliva.Benzin, 48.8);
                Console.WriteLine(nakladniAuto.GetAutoInfo());
            

        }
    }
}
