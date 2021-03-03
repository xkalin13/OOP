using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace cv4
{
    public class StringStatistics
    {
        private string txt;
        private List<string> words = new List<string>();
        private List<string> helpList = new List<string>();
        public StringStatistics(string txt)
        {
            this.txt = txt;
        }
        public void replaceInter() {
            //smazani vsech interpunkci
            string[] replacer = { ".", "(", ")", "?", "!" };
            //specialne pro dalsi radek
            txt = txt.Replace("\n", " ");

            foreach (var exp in replacer)
            {
                txt = txt.Replace(exp, string.Empty);
            }
        }
        public int wordCount()
        {
            //kazde slovo je oddeleno mezernikem, timto zpusobem spocitam slova
            //vezmu si mezery a prictu pocet radku, protoze kazdy novy radek by nepricetl prvni slovo
            //na rozdeleni pouziji split, ten vsak bohuzel docela vytezuje a generuje nove string objekty
            return txt.Split(' ').Length + this.lineCount()-1;
        }
        public int lineCount()
        {
            //kazdy radek je oddelen newLine znakem \n
            return txt.Split('\n').Length;
        }
        public int sentenceCount()
        {
            int count = 0;
            //kazda veta konci na "." "!" nebo "?"
            //u vykricniku a otazniku je to jasne, tecka je ale zaludna
            //pouziju regex abych zjistil paterny
            // "{tecka}+{mezera}+{VelkePismeno}" NEBO "{tecka}+{dalsiRadek}+{VelkePismeno}"
            count += Regex.Split(txt, "\\. [A-Z]|\\.\n[A-Z]|\\.\\z").Length - 1;
            //veta koncici vykricnikem
            count += (txt.Split('!').Length - 1);
            //veta koncici otaznikem
            count += (txt.Split('?').Length - 1);
            return count;          
        }
        public List<string> longWords()
        {
            listIterate();
            //vycisteni pomocneho listu
            helpList.Clear();

            //iterace kazdeho slova
            foreach (var word in words)
            {
                if (word.Length > 6){//nastavitelna delka
                    helpList.Add(word);
                }
            }

            return helpList;
        }
        public List<string> shortWords()
        {
            listIterate();
            helpList.Clear();

            foreach (var word in words)
            {
                if (word.Length < 2){//nastavitelna delka
                    helpList.Add(word);
                }
            }

            return helpList;
        }
        public List<string> repetetiveWords()
        {
            listIterate();
            //nalezeni duplikatu pomoci knihovny linq
            var duplicates = words.GroupBy(x => x)
              .Where(g => g.Count() > 1)//pocet duplikace
              .Select(y => y.Key)
              .ToList();

            return duplicates;
        }
        public List<string> sortByAlphabet()
        {
            //obycejne pouziti sort metody listu
            words.Sort();
            return words;
        }
        public void listIterate() {
            //vycisteni hlavniho listu
            words.Clear();
            //co mezera to slovo
            foreach (var word in txt.Split(' '))
            {
                //vlozi kazde slovo do listu            
                words.Add(word);
            }
        }
        public bool isInfected() {

            foreach (var word in words)
            {
                if (word.ToLower().Contains("sars-cov-2") || word.ToLower().Contains("covid-19") || word.ToLower().Contains("covid"))
                {
                    return true;
                }              
            }
            return false;
        }

    }
}
