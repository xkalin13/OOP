using System;
using System.Collections.Generic;
using System.Text;

namespace cv7
{
    public class Elipsa : Objekt2D
    {
        private int radiusA, radiusB; //polomer
        public Elipsa(int radiusA, int radiusB)
        {
            this.radiusA = radiusA;
            this.radiusB = radiusB;
        }
        public override double Plocha()
        {
            return  Math.PI * radiusA * radiusB;
        }
        public override string ToString()
        {
            return "Elipsa " + Plocha().ToString("0.00");//limit desetinnych
        }
    }
}
