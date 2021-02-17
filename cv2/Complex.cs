using System;
using System.Collections.Generic;
using System.Text;

namespace cv2
{
    class Complex
    {
		public double Realna;
		public double Imaginarni;
		public Complex(double im, double re)
		{
			this.Realna = re;
			this.Imaginarni = im;
		}

		public override String ToString()
		{
			return "Realna slozka: " + Realna + " Imaginarni slozka: " + Imaginarni;
		}
		public String GetComplexNum()
		{
			return "Sdruzene: " + Realna + (-Imaginarni) + "j";
		}
		public String GetModule()
		{
			return "Modul: " +Math.Sqrt(Math.Pow(Realna,2)+ Math.Pow(Realna, 2));
		}
		public double GetNumModule() {
			return Math.Sqrt(Math.Pow(Realna, 2) + Math.Pow(Realna, 2));
		}

		public String GetArg() {
			return "Argument: "+Math.Atan(Imaginarni/Realna);
		}
		public static Complex Calculate(Complex a, Complex b, char op) {
			
			switch (op)
			{
				case '+': b.Realna += a.Realna; b.Imaginarni +=a.Imaginarni; break;
				case '-': b.Realna -= a.Realna; b.Imaginarni -= a.Imaginarni; break;
				case '*': b.Realna *= a.Realna; b.Imaginarni *= a.Imaginarni; break;
				case '/': b.Realna /= a.Realna; b.Imaginarni /= a.Imaginarni; break;
				default: break;
			}

			return b;
		}
		public static Complex Diff(Complex a, Complex b) {
			b.Imaginarni -= a.Imaginarni;
			b.Realna -= a.Realna;
			return b;
		}


	}
}
