using System;
using System.Collections.Generic;
using System.Text;

namespace cv7
{
    public class Extremy
    {
        public static T Nejvetsi<T>(params T[] parameters) where T : IComparable
        {
            T extrem = parameters[0];
            for (int i = 1; i < parameters.Length; i++)
            {
                extrem = ((parameters[i].CompareTo(extrem) == 1) ? parameters[i] : extrem);//zustala hodnota stejna?
            }

            return extrem;
        }
        public static T Nejmensi<T>(params T[] parameters) where T : IComparable
        {
            T extrem = parameters[0];
            for (int i = 1; i < parameters.Length; i++)
            {
                extrem = ((parameters[i].CompareTo(extrem) == 0) ? parameters[i] : extrem);//zustala hodnota stejna?
            }

            return extrem;
        }
    }
}
