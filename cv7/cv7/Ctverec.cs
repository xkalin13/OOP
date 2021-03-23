using System;
using System.Collections.Generic;
using System.Text;

namespace cv7
{
    public class Ctverec : Objekt2D
    {
        private int sideA; //strany jsou stejne
        public Ctverec(int sideA)
        {
            this.sideA = sideA;
        }
        public override double Plocha()
        {
            return Math.Pow(sideA,2);
        }
        public override string ToString()
        {
            return "Ctverec " + Plocha();
        }
    }
}
