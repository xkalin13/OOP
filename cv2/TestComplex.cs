using System;
using System.Collections.Generic;
using System.Text;

namespace cv2
{
	class TestComplex
	{
		const double epsilon = 1e-6;
		public static void Test(Complex a, Complex b, Complex c, char op)
		{
			string name;

			switch (op)
			{
				case '+': name = "Plus"; break;
				case '-': name = "Minus"; break;
				case '*': name = "Nasobeni"; break;
				case '/': name = "Deleni"; break;
				default: name = "nic"; break;
			}
			Complex vypocet = Complex.Calculate(Complex.Calculate(a, b, op), b, '-');
			Console.WriteLine("vypocetlo to rozdil" + vypocet);
			if (vypocet.GetNumModule() < epsilon) {
				Console.WriteLine("ocekavana hodnota testu: "+name+" je OK");

			}
            else
            {
				Console.WriteLine("ocekavana hodnota neni v ramci");
			}

		}

	}
}
