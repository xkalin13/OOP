using System;
using System.Collections.Generic;
using System.Text;

namespace cv6
{
    class Trojuhelnik : Objekt2D
    {
        private double sideA;
        private double heightA;

        public Trojuhelnik(double sideA, double height) {
            this.sideA = sideA;
            this.heightA = height;
        }
        public override void Kresli()
        {
            Console.WriteLine("Trojuhelnik strana a: " + sideA + "vyska na stranu a: " + heightA);
        }

        public override double SpoctiPlochu()
        {
            return (sideA*heightA) / 2;
        }
    }
}
