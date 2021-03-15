using System;
using System.Collections.Generic;
using System.Text;

namespace cv6
{
    class Elipsa : Objekt2D
    {
        private double axisA;
        private double axisB;
        public Elipsa(double axisA, double axisB) {
            this.axisA = axisA;
            this.axisB = axisB;
        }
        public override void Kresli()
        {
            Console.WriteLine("Elipsa osa a: " +axisA+ " osa b: " +axisB);
        }

        public override double SpoctiPlochu()
        {
            return Math.PI * axisA * axisB;
        }
    }
}
