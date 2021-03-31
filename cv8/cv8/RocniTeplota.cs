using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cv8
{
    class RocniTeplota
    {
        public int Rok;
        private double MaxTeplota
        {
            get { return GetMaxTeplota(); }
        }
        public double GetMaxTeplota()//readonly
        {
            return mesicniTeploty.Max();
        }

        private double MinTeplota
        {
            get { return GetMinTeplota(); }
        }
        public double GetMinTeplota()//readonly
        {
            return mesicniTeploty.Min();
        }
        
        public double PrumernaRocniTeplota
        {
            get { return GetPrumernaRocniTeplota(); }
        }
        public double GetPrumernaRocniTeplota()//readonly
        {
            return mesicniTeploty.Average();
        }

        private List<double> mesicniTeploty;
        public List<double> MesicniTeploty
        {
            get { return mesicniTeploty; }
            set { mesicniTeploty = value; }
        }
        
        public RocniTeplota(int rok, List<double> mesicniTeploty)
        {
            this.mesicniTeploty = new List<double>();
            this.Rok = rok;
            this.mesicniTeploty = mesicniTeploty;
        }
    }
}
