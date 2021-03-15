using System;
using System.Collections.Generic;
using System.Text;

namespace cv6
{
    class Koule : Objekt3D
    {
        private double radius;
        public Koule(double radius) {
            this.radius = radius;
        }
        public override void Kresli()
        {
            Console.WriteLine("Koule polomer: "+radius);
        }

        public override double SpoctiObjem()
        {
            return (4 / 3) * (Math.PI * Math.Pow(radius,3));
        }

        public override double SpoctiPovrch()
        {
            return 4 * Math.PI * Math.Pow(radius, 2);
        }
    }
}
