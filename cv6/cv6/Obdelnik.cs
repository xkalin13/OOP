using System;
using System.Collections.Generic;
using System.Text;

namespace cv6
{
    class Obdelnik : Objekt2D
    {
        private double sideA;
        private double sideB;

        public Obdelnik(double sideA, double sideB) {
            this.sideA = sideA;
            this.sideB = sideB;
        }
        public override void Kresli()
        {
            Console.WriteLine("Obdelnik strana a: " +sideA+ " strana b: " +sideB);
        }

        public override double SpoctiPlochu()
        {
            return sideA * sideB;
        }
    }
}
