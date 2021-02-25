using System;
using System.Collections.Generic;
using System.Text;

namespace cv3
{
    public class Matrix
    {
        private double[,] matrix;
        public Matrix(double[,] matrix)
        {
            this.matrix = matrix;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix vysledek = new Matrix(new double[a.matrix.GetLength(0), a.matrix.GetLength(1)]);

            try
            {
                for (int x = 0; x < a.matrix.GetLength(0); x++)
                {
                    //radky a sloupce
                    for (int y = 0; y < a.matrix.GetLength(1); y++)
                    {
                        //pricitani matice je postupne
                        vysledek.matrix[x, y] = a.matrix[x, y] + b.matrix[x, y];
                    }
                }
            }
            catch
            { Console.WriteLine("Chyba");}

            return vysledek;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix vysledek = new Matrix(new double[a.matrix.GetLength(0), a.matrix.GetLength(1)]);

            try
            {
                for (int x = 0; x < a.matrix.GetLength(0); x++)
                {
                    //radky a sloupce
                    for (int y = 0; y < a.matrix.GetLength(1); y++)
                    {
                        //odecitani matice                       
                        vysledek.matrix[x, y] = a.matrix[x, y] - b.matrix[x, y];                        
                    }
                }
            }
            catch
            { Console.WriteLine("Chyba");}

            return vysledek;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix vysledek = new Matrix(new double[a.matrix.GetLength(0), a.matrix.GetLength(1)]);

            try
            {
                for (int x = 0; x < a.matrix.GetLength(0); x++)
                {
                    //radky a sloupce
                    for (int y = 0; y < a.matrix.GetLength(1); y++)
                    {
                    
                        //vynulovani
                        vysledek.matrix[x, y] = 0;
                        for (int n = 0; n < a.matrix.GetLength(1); n++)
                        {
                            //nasobeni matice matici je soucet nasobku 1.radku a 1.sloupce atd...
                            vysledek.matrix[x, y] += a.matrix[x, n] * b.matrix[n, y];
                        }
                    }
                }
            }
            catch
            { Console.WriteLine("Chyba");}
            return vysledek;
        }
        public static bool operator ==(Matrix a, Matrix b)
        {
            bool equals = true;
            try
            {
                for (int x = 0; x < a.matrix.GetLength(0); x++)
                {
                    //radky a sloupce
                    for (int y = 0; y < a.matrix.GetLength(1); y++)
                    {
                        if (a.matrix[x, y] != b.matrix[x, y]){
                            //pokud se nerovnaji rovnou vraci false
                            equals = false;
                        }
                    }
                }
            }
            catch
            { Console.WriteLine("Chyba"); }
            return equals;
           
        }
        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }

        //unarni -
        public static Matrix operator -(Matrix a)
        {
            Matrix vysledek = new Matrix(new double[a.matrix.GetLength(0), a.matrix.GetLength(1)]);
            try
            {           
                for (int x = 0; x < a.matrix.GetLength(0); x++)
                {
                    //radky a sloupce
                    for (int y = 0; y < a.matrix.GetLength(1); y++)
                    {
                        //prevod na zaporne cislo
                        vysledek.matrix[x, y] = a.matrix[x, y] *(-1);
                    }
                }
            }
            catch
            { Console.WriteLine("Chyba");}
            return vysledek;
        }
        public double Determinant()
        {
            double determinant=0;
            try
            {
                if (matrix.GetLength(0) == matrix.GetLength(1))
                {            
                //matice 1x1
                    if (matrix.GetLength(0) == 1)
                    {
                        determinant = matrix[0, 0];
                    }
                    //matice 2x2
                    else if (matrix.GetLength(0) == 2)
                    {
                        determinant = matrix[0, 0] * (matrix[1, 1] - matrix[0, 1] * matrix[1, 0]);                
                    }
                    //matice 3x3
                    else if (matrix.GetLength(0) == 3)
                    {
                        determinant =
                            matrix[0, 0] * matrix[1, 1] * matrix[2, 2] +
                            matrix[0, 1] * matrix[1, 2] * matrix[2, 0] +
                            matrix[0, 2] * matrix[1, 0] * matrix[2, 1] - (
                            matrix[0, 2] * matrix[1, 1] * matrix[2, 0] +
                            matrix[0, 0] * matrix[1, 2] * matrix[2, 1] +
                            matrix[0, 1] * matrix[1, 0] * matrix[2, 2] );

                    }            
                }
            }
            catch
            {
                Console.WriteLine("Chyba");
            }
            return determinant;
        }
        public override string ToString()
        {

            string vystup = "";
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                //radky a sloupce
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    //prida tebulator
                    vystup += matrix[x, y]+"\t ";
                }
                //kazdy radek prida radek vypisu
                vystup += "\n";
            }

            return vystup;
        }
    }
}
