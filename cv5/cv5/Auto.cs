using System;
using System.Collections.Generic;
using System.Text;

namespace cv5
{
    class Auto
    {
        public enum TypPaliva{
            Benzin,
            Nafta
        }
        protected double VelikostNadrze;
        protected double StavNadrze;
        protected TypPaliva Palivo;

        private AutoRadio Radio = new AutoRadio();

        public Auto(TypPaliva palivo, double velikostNadrze) {
            this.StavNadrze = 0;
            this.Palivo = palivo;
            this.VelikostNadrze = velikostNadrze;        
        }
        public void Natankuj(TypPaliva tankovanePalivo, double mnozstvi) {

            if (tankovanePalivo != this.Palivo ) {
                throw new Exception("Nelze natankovat"+ tankovanePalivo);
            }
            else {
                if (StavNadrze + mnozstvi < VelikostNadrze)
                {
                    StavNadrze += mnozstvi;
                }
                else {
                    throw new Exception("Nelze natakovat vic nez nadrz");
                }                
            }            
        }
        public void ZapnoutRadio(bool radioZapnuto)
        {
            Radio.ZapnoutRadio(radioZapnuto);
        }
        public void NastavPredvolbu(int cislo, double kmitocet)
        {
            Radio.NastavPredvolbu(cislo, kmitocet);
        }
        public void PreladNaPredvolbu(int cislo)
        {
            Radio.PreladNaPredvolbu(cislo);
        }
        public void RadioToString()
        {
            Console.WriteLine(Radio);
        }
        public override string ToString() {
            return "Auto jezdi na "+this.Palivo+", velikost nadrze je "+this.VelikostNadrze+" a jeji stav je "+this.StavNadrze;
        }
    }
}
