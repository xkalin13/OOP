using System;
using System.Collections.Generic;
using System.Text;

namespace cv6
{
    class Kruh : Objekt2D
    {
        private double radius;
        public Kruh(double radius) {
            this.radius = radius;
        }
        public override void Kresli()
        {
            Console.WriteLine("Kruh polomer: " + radius);
        }

        public override double SpoctiPlochu()
        {
            return Math.PI * radius;
        }
    }
}
