using System;

namespace cv3
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matrixA = {
                { 1, 9, 3 },
                { 3, 4, 5 },
                { 5, 6, 7 }

            };

            double[,] matrixB = {
                { 9, 8, 7 },
                { 6, 5, 4 },
                { 3, 2, 1 }
                
            };
            Matrix matrix1 = new Matrix(matrixA);
            Matrix matrix2 = new Matrix(matrixB);
            
            Console.WriteLine("Soucet:\n" + (matrix1 + matrix2));
            Console.WriteLine("Rozdil:\n" + (matrix1 - matrix2));
            Console.WriteLine("Nasobeni:\n" + (matrix1 * matrix2));
            Console.WriteLine("Rovnost: " + (matrix1 == matrix2));
            Console.WriteLine("Nerovnost:" + (matrix1 != matrix2));
            Console.WriteLine("Zaporna matice 1: \n" + (-matrix1));
            Console.WriteLine("Zaporna matice 2: \n" + (-matrix2));
            Console.WriteLine("Determinant matice 1: " + matrix1.Determinant());
            Console.WriteLine("Determinant matice 2: " + matrix2.Determinant());


        }

    }
}
