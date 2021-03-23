using System;
using System.Collections.Generic;
using System.Text;

namespace cv7
{
    public class Trojuhelnik : Objekt2D
    {
        private int sideA, heightA; //vyska na stranu  a strana
        public Trojuhelnik(int sideA, int heightA)
        {
            this.sideA = sideA;
            this.heightA = heightA;
        }
        public override double Plocha()
        {
            return heightA * sideA / 2;
        }
        public override string ToString()
        {
            return "Trojuhelnik " + Plocha();
        }
    }
}
