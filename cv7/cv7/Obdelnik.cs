using System;
using System.Collections.Generic;
using System.Text;

namespace cv7
{
    public class Obdelnik : Objekt2D
    {
        private int sideA, sideB;//strany
        public Obdelnik(int sideA,int sideB)
        {
            this.sideA=sideA;
            this.sideB=sideB;
            Plocha();
        }
        public override double Plocha()
        {
            return  sideA * sideB;
        }
        public override string ToString()
        {
            return "Obdelnik " + Plocha();
        }
    }
}
