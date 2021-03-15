using System;
using System.Collections.Generic;
using System.Text;

namespace cv6
{
    class Valec : Objekt3D
    {
        private double radius;
        private double height;

        public Valec(double radius, double height) {
            this.radius = radius;
            this.height = height;
        }
        public override void Kresli()
        {
            Console.WriteLine("Valec polomer: "+radius+ " vyska: " +height);
        }

        public override double SpoctiObjem()
        {
            return Math.PI * Math.Pow(radius, 2) * height;
        }

        public override double SpoctiPovrch()
        {
            return 2 * Math.PI * radius * (radius + height);
        }
    }
}
