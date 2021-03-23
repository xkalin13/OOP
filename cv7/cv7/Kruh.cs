using System;
using System.Collections.Generic;
using System.Text;

namespace cv7
{
    public class Kruh : Objekt2D
    {
        private int radius;//polomer
        public Kruh(int radius)
        {
            this.radius = radius;
            Plocha();
        }
        public override double Plocha()
        {
            return Math.PI * Math.Pow(radius,2);
        }
        public override string ToString()
        {
            return "Kruh " + Plocha().ToString("0.00");//limit desetinnych
        }
    }
}
