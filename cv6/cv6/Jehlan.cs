using System;
using System.Collections.Generic;
using System.Text;

namespace cv6
{
    class Jehlan : Objekt3D
    {
        private double baseEdge;
        private double height;

        public Jehlan(double baseEdge, double height) {
            this.baseEdge = baseEdge;
            this.height = height;
        }

        public override void Kresli()
        {
            Console.WriteLine("Jehlan hrana zakladny: "+baseEdge+" vyska: "+height);
        }

        public override double SpoctiObjem()
        {   // jedna tretina podstavy*vysky
            
            return (1 / 3) * (baseEdge * baseEdge) * height;
        }

        public override double SpoctiPovrch()
        {
            //Spodstava + Splast -z internetu jednodussi vzorec
            return baseEdge*(baseEdge + Math.Sqrt(4 * Math.Pow(height,2)+ Math.Pow(baseEdge, 2)));
        }
    }
}
