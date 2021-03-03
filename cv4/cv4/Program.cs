using System;

namespace cv4
{
    class Program
    {
        static void Main(string[] args)
        {
            string testovaciText = "Toto je retezec predstavovany nekolika radky,\n"
             + "ktere jsou od sebe oddeleny znakem LF (Line Feed).\n"
             + "Je tu i nejaky ten vykricnik! Pro ucely testovani i otaznik?\n"
             + "Toto je jen zkratka zkr. ale ne konec vety. A toto je\n"
             + "posledni veta!";

            StringStatistics stringStat = new StringStatistics(testovaciText);

            Console.WriteLine("Slov: " + stringStat.wordCount());
            Console.WriteLine("Radku: " + stringStat.lineCount());
            Console.WriteLine("Vet: " + stringStat.sentenceCount());
            //vycisteni od tecek a prevedeni \n
            stringStat.replaceInter();
            Console.WriteLine("Nejdelsi slova []: ");
            stringStat.longWords().ForEach(Console.WriteLine);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Nejkratsi slova []: ");
            stringStat.shortWords().ForEach(Console.WriteLine);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Opakujici se slova []: ");
            stringStat.repetetiveWords().ForEach(Console.WriteLine);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Abecedne slova []: ");            
            stringStat.sortByAlphabet().ForEach(Console.WriteLine);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Je text nakazen covidem?: "+stringStat.isInfected());


        }
    }
}

