using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cv9
{
    class Calculator
    {
        private enum Stav
        {
            PrvniCislo = 0, DruheCislo, Operace,Vysledek
        };

        public string Display;
        public string Pamet="";
        public string lastNumber;

        Stav _stav = Stav.PrvniCislo;

        long[] actualNumber = new long[2] {0, 0};
        byte[] decimalPlaces = new byte[2] { 0, 0 };

        long answerNumber;
        char operation;
        bool compFail = false; //osetreni deleni nulou
        bool answered = false; //nutne kvuli opakovanemu mackani =

        public void Tlacitko(string pressedButton)
        {

            if (pressedButton.All(char.IsDigit))
            {               
                actualNumber[(int)_stav] = actualNumber[(int)_stav] * 10;
                actualNumber[(int)_stav] += (actualNumber[(int)_stav]<0)?-Byte.Parse(pressedButton):Byte.Parse(pressedButton);
                displayChange(actualNumber[(int)_stav]);
            }
            else if (pressedButton[0] == 'M')
            {
                memoryAction(pressedButton);
            }
            else if (pressedButton[0] == 'C')
            {
                clearAction(pressedButton);
                displayChange(actualNumber[(int)_stav]);                
            }
            else if (pressedButton.IndexOfAny(("+-*/").ToCharArray()) != -1)
            {
                if (Display[Display.Length - 1] == operation)
                {
                    Display = Display.Remove(Display.Length - 1, 1);//zamenuje znamenka, aby se nehromadily
                }

                getRidOfPoint();

                //kdyz napisu napr 3+3 = {6} a dalsi = {9} v pameti mam druhou zadanou hodnotu (+3)
                //kdybych zadal -9 tak se mi neresetuje posledni hodnota => +3-9 = -39
                if (answered)
                {
                    actualNumber[1] = 0;
                    lastNumber = answerNumber.ToString();
                }

                _stav = Stav.DruheCislo;
                operation = pressedButton[0];                
                Display += operation.ToString();
                lastNumber = Display;

            }
            else if (pressedButton[0] == ',')
            {
                decimalPlaces[(int)_stav] = (byte)Math.Floor(Math.Log10(actualNumber[(int)_stav]) + 1);
                displayChange(actualNumber[(int)_stav]);
            }
            else if (pressedButton[0] == '±') {
                actualNumber[(int)_stav] *= -1;
                displayChange(actualNumber[(int)_stav]);
            }
            else{ //vysledek 
                
                if (_stav == Stav.Vysledek )//opakovane mackani ==
                {
                    _stav = Stav.DruheCislo;
                }

                lastNumber = actualNumber[0].ToString() + operation + actualNumber[1].ToString();
                
                getRidOfPoint();//zbavi se , pokud za ni nenasleduje cislo

                for (int i = 0; i < 2; i++)
                {
                    actualNumber[i] *= (long)Math.Pow(10, 0 - decimalPlaces[i]);//udela z cisla desetinu
                }

                switch (operation)
                {
                    case '+': answerNumber = actualNumber[0] + actualNumber[1]; break;
                    case '-': answerNumber = actualNumber[0] - actualNumber[1]; break;
                    case '/':
                        if (actualNumber[1] != 0)
                        {
                            answerNumber = actualNumber[0] / actualNumber[1];
                        }
                        else
                        {
                            compFail = true;
                        }
                        break;
                    case '*': answerNumber = actualNumber[0] * actualNumber[1]; break;
                    default: answerNumber = actualNumber[0]; break;
                }
                if (compFail)
                {
                    Display = "INF";
                    memoryAction("MC");
                }
                else
                { 
                    actualNumber[0] = answerNumber;// ulozi hodnotu pro opakovane ==
                    answered=true;
                    displayChange(answerNumber);
                }             
            }        
        }
        public void clearAction(String action) {
            switch (action) {
                case "CE": actualNumber[(int)_stav] = 0; break;
                case "CC": actualNumber[(int)_stav] = actualNumber[(int)_stav] / 10; break;
                case "C":  actualNumber[0] = 0; actualNumber[1] = 0; _stav = Stav.PrvniCislo; lastNumber = "0"; break;
                default:break;
            }
            getRidOfPoint();
        }
        public void displayChange(long number) {
            Display = string.Empty;

            if (decimalPlaces[(int)_stav] > 0) {//pokud existuje desetina
                string num = number.ToString();
                for (int i = 0; i < decimalPlaces[(int)_stav]; i++)
                {
                    Display += num[i];
                   
                }
                Display += ",";
                for (int i = decimalPlaces[(int)_stav]; i < num.Length; i++)
                {
                    Display += num[i];
                }                
               
            }
            else {
                Display = number.ToString();
            }            
        }
        public void getRidOfPoint() {
            if (Display[Display.Length - 1]==',')
            {
                decimalPlaces[(int)_stav] = 0;
                displayChange(actualNumber[(int)_stav]);
            }
        }
        public void memoryAction(String action) {
            long memory = (Pamet =="" )? 0 : Int64.Parse(Pamet);

            switch (action) {                
                case "M+": memory += actualNumber[(int)_stav]; clearAction("CE"); break;
                case "M-": memory -= actualNumber[(int)_stav]; clearAction("CE"); break;
                case "MC": memory = 0; clearAction("CE"); break;
                case "MS": memory = Int64.Parse(Display); clearAction("CE"); break;
                case "MR": actualNumber[(int)_stav] = memory; break;
                default:break;
            }            
            Pamet = memory.ToString();            
        }
    }
}
