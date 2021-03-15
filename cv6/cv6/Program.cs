using System;

namespace cv6
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            double parameter = rnd.Next(0,20);

            double completeVolume = 0;
            double completeArea = 0;
            double completeSurface = 0;

            GrObjekt[] objectArray = new GrObjekt[] {
                new Elipsa(parameter,parameter),
                new Jehlan(parameter, parameter),
                new Koule(parameter),
                new Kruh(parameter),
                new Kvadr(parameter, parameter, parameter),
                new Obdelnik(parameter, parameter),
                new Trojuhelnik(parameter, parameter),
                new Valec(parameter, parameter)
            };            

            foreach (GrObjekt singleObject in objectArray)
            {
                singleObject.Kresli();

                //pokud je 3d- pocita jak povrch tak objem / musi se castovat do tridy ktera ma metody, GrObjekt nema metody podtrid
                if (singleObject is Objekt3D) {

                    completeSurface += ((Objekt3D) singleObject).SpoctiPovrch();
                    completeVolume += ((Objekt3D) singleObject).SpoctiObjem();
                }
                else { // pocita jen plochu
                    completeArea += ((Objekt2D) singleObject).SpoctiPlochu();
                }

            }

            Console.WriteLine("PLOCHA: "+completeArea+" POVRCH: "+completeSurface+" OBJEM: "+completeVolume);

        }
    }
}
