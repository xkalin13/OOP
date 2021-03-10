using System;
using System.Collections.Generic;
using System.Text;

namespace cv5
{
    class Osobni : Auto
    {
        private int MaxOsob;
        private int PrepravovaneOsoby;
        public void SetPrepravovaneOsoby(int prepravovaneOsoby) {
            if (prepravovaneOsoby > 0 && prepravovaneOsoby < this.MaxOsob)
            {
                this.PrepravovaneOsoby = prepravovaneOsoby;
            }
            else {
                throw new Exception("Nemuzete zadat vic osob nez max, nebo mene nez 1");
            }
        }

        public Osobni(TypPaliva palivo, double velikostNadrze, int maxOsob) : base(palivo, velikostNadrze)
        {
            this.PrepravovaneOsoby = 0;
            this.MaxOsob = maxOsob;

        }

        public override string ToString()
        {
            return "MaxOsob: "+MaxOsob+" a prepravovane: "+PrepravovaneOsoby;
        }
        
        public string GetAutoInfo() {
            return base.ToString();
        }

    }
}
