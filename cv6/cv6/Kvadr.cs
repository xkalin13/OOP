using System;
using System.Collections.Generic;
using System.Text;

namespace cv6
{
    class Kvadr : Objekt3D
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Kvadr(double sideA, double sideB, double sideC) {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }
        public override void Kresli()
        {
            Console.WriteLine("Kvadr  a: " +sideA+ " b: "+sideB + " c: " + sideC);
        }

        public override double SpoctiObjem()
        {
            return sideA * sideB * sideC;
        }

        public override double SpoctiPovrch()
        {
            return 2 * (sideA * sideB + sideB * sideC + sideC * sideA);
        }
    }
}
