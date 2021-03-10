using System;
using System.Collections.Generic;
using System.Text;

namespace cv5
{
    class Nakladni : Auto
    {
        private double MaxNaklad;
        private double PrepravovanyNaklad;

        public void SetPrepravovanyNaklad(int prepravovanyNaklad) {

            if (prepravovanyNaklad > 0 && prepravovanyNaklad < this.MaxNaklad)
            {
                this.PrepravovanyNaklad = prepravovanyNaklad;
            }
            else {
                throw new Exception("Nemuzete zadat vic nakladu nez max, nebo mene nez 0");                
            }
        }
        public Nakladni(TypPaliva palivo, double velikostNadrze, double maxNaklad) : base(palivo, velikostNadrze)
        {
            this.PrepravovanyNaklad = 0;

            if (maxNaklad > 0)
            {
                this.MaxNaklad = maxNaklad;
            }
            else {
                this.MaxNaklad = 0;
            }           

        }
        public override string ToString()
        {
            return "Nakladni auto-max naklad:" + MaxNaklad + " a prepravovany naklad: " + PrepravovanyNaklad;
        }
        public string GetAutoInfo() {
            return base.ToString();
        }
    }
}
