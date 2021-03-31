using System;

namespace cv8
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = "..\\..\\..\\";//nutne kvuli assembly
            string file = dir+"archive";

            ArchivTeplot temperatureArchive = new ArchivTeplot();

            temperatureArchive.Load(file+ ".txt");
            temperatureArchive.TiskTeplot();

            temperatureArchive.TiskPrumernychRocnichTeplot();
            temperatureArchive.TiskPrumernychMesicnichTeplot();

            temperatureArchive.Kalibrace(-0.1);
            temperatureArchive.TiskTeplot();

            temperatureArchive.Vyhledej(2014);

            temperatureArchive.Save(file+".output.txt");
        }
    }
}
