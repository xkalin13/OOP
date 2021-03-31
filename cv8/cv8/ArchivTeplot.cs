using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace cv8
{
    class ArchivTeplot
    {
        private SortedDictionary<int, RocniTeplota> _archiv;

        public ArchivTeplot() {
            _archiv = new SortedDictionary<int, RocniTeplota>();
        }

        public void Load(string filePath)
        {
            Console.WriteLine("--------LOAD-------");
            StreamReader file = new StreamReader(filePath);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                List<double> temperatures = new List<double>();

                line = line.Replace(" ", string.Empty); //odstraneni mezer

                List<string> temperatureValues = line.Split(';',':').ToList(); //oddeleni podle delimiteru ; a po textu rok 2010:

                int year = Convert.ToInt32(temperatureValues[0]); //prvni hodnota rok
                temperatureValues.RemoveAt(0); //nutne smazat prvni value ktera je rok

                foreach (var value in temperatureValues)
                {                    
                    temperatures.Add(Convert.ToDouble(value));
                }             

                _archiv.Add(year, new RocniTeplota(year, temperatures));

            }
            file.Close();
        }

        public void Save(string filePath)
        {
            Console.WriteLine("--------SAVE-------");
            StreamWriter file = new StreamWriter(filePath,false);//false nebude appendovat ale vytvori novyu soubor
            
            foreach (var archiveData in _archiv.Values)
            {
                string format = "{0:0.##}; ";//mezera
                file.Write(archiveData.Rok+": ");//prvni opet rok

                for (int i = 0; i < archiveData.MesicniTeploty.Count; i++)
                {
                    if (i == archiveData.MesicniTeploty.Count-1)//posledni musi byt bez ;
                    {
                        format = "{0:0.##}";
                    }
                    file.Write(format, archiveData.MesicniTeploty[i]);

                }
                file.WriteLine();
            }
            file.Close();
        }
        public void Kalibrace(double constantValue)
        {
            Console.WriteLine("--------KALIBRACE-------");

            foreach (var archiveData in _archiv.Values)
            {                
                for (int i = 0; i < archiveData.MesicniTeploty.Count; i++)
                {
                    archiveData.MesicniTeploty[i] += constantValue;
                }
            }
        }
        public void Vyhledej(int year)
        {
            Console.WriteLine("--------VYHLEDAVANI-------");
            if (_archiv.ContainsKey(year))
            {
                Console.Write(_archiv[year].Rok + ": ");//vypis roku 

                for (int i = 0; i < _archiv[year].MesicniTeploty.Count; i++)
                {
                    Console.Write("{0:0.#}; ", _archiv[year].MesicniTeploty[i]);// formatovany vypis mesicnich teplot v tomto roce
                }
            }
            else {
                Console.WriteLine("N/A");
            }
            Console.WriteLine();
                
        }
        public void TiskTeplot()
        {
            Console.WriteLine("--------TISK TEPLOT-------");
            foreach (var archiveData in _archiv.Values)
            {
                Console.Write(archiveData.Rok + ": ");//prvni opet rok

                for (int i = 0; i < archiveData.MesicniTeploty.Count; i++)
                {
                    Console.Write(" {0:0.#} ", archiveData.MesicniTeploty[i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void TiskPrumernychRocnichTeplot()
        {
            Console.WriteLine("--------TISK PRUMER ROCNICH-------");

            foreach (var archiveData in _archiv.Values)
            {
                Console.Write(archiveData.Rok+": ");//prvni rok
                Console.WriteLine("{0:0.#}; ", archiveData.PrumernaRocniTeplota);//formatovane
            }
            Console.WriteLine();
        }
        public void TiskPrumernychMesicnichTeplot()
        {
            Console.WriteLine("--------TISK PRUMER MESICNICH-------");
            List<double> monthAverages = new List<double>();
            monthAverages.AddRange(Enumerable.Repeat((double)0, 12));//nulovani

            foreach (var archiveData in _archiv.Values)
            {
                for (int i = 0; i < archiveData.MesicniTeploty.Count; i++)
                {
                    monthAverages[i] += archiveData.MesicniTeploty[i];// pricte je ke zprumerovani 
                }
            }
            foreach (double month in monthAverages) { 
                
                Console.Write(" {0:0.#};", month/_archiv.Keys.Count);//format
            }
            Console.WriteLine();
        }

    }
}
