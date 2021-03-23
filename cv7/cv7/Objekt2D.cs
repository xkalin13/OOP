using System;
using System.Collections.Generic;
using System.Text;

namespace cv7
{
    public abstract class Objekt2D : I2D, IComparable
    {
        public abstract double Plocha();
        public int CompareTo(object obj)
        {
            return (( ((Objekt2D)obj).Plocha() > this.Plocha())? 0 : 1);
        }
    }
}
