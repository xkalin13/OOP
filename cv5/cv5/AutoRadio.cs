using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cv5
{
    class AutoRadio
    {        
        private bool RadioZapnuto = false;
        private double NaladenyKmitocet;
        private Dictionary<int, double> Predvolby = new Dictionary<int, double> ();

        public void NastavPredvolbu(int cislo, double kmitocet) {
            if (this.RadioZapnuto)
            {
                if (!Predvolby.ContainsKey(cislo))
                {
                    Predvolby.Add(cislo, kmitocet);
                }
                else {
                    throw new Exception("Na teto frekvenci uz existuje radio");
                }
            }
            else {
                throw new Exception("Nutne zapnout radio");
            }           
        }
        public void ZapnoutRadio(bool radioZapnuto)
        {
            this.RadioZapnuto=radioZapnuto;
        }
        public void PreladNaPredvolbu(int cislo)
        {
            if (this.RadioZapnuto)
            {
                if (Predvolby.ContainsKey(cislo))
                {
                    this.NaladenyKmitocet = Predvolby[cislo];
                }
                else
                {
                    throw new Exception("Zadna frekvence");
                }
            }
            else
            {
                throw new Exception("Radio neni zapnute");
            }               
        }
        public override string ToString()
        {
            string str;

            if (RadioZapnuto) {
                str = "Radio je zapnuto na frekvenci: "+NaladenyKmitocet+" = predvolba "+ Predvolby.FirstOrDefault(x => x.Value == NaladenyKmitocet).Key; ;
            }
            else {
                str = "Radio neni zapnute";
            }
            return str;
        }
    }
}
