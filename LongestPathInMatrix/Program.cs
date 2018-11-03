using System;

namespace LongestPathInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Maximum path in a matrix!");
            Console.WriteLine("--------------------------");

            Console.WriteLine("Four directions can be used, left, right, top, bottom");
            Console.WriteLine("Adjacent cell can be navigated given that its number is one greater than the current number");

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            try
            {
                int[,] matrix = GetInput();
                if (matrix != null)
                {
                    MatrixProcessor matrixProcessor = new MatrixProcessor(matrix);
                    matrixProcessor.GetLongestPathInMatrix();

                    Console.ReadKey();
                }
                else {
                    Console.WriteLine("Matrix is null! Please check your inputs and try again!");
                    Console.WriteLine("Terminating.......");
                }
            }
            catch (Exception exception) {
                Console.WriteLine("Exception thrown is "+exception.Message);
            }
        }

        private static int[,] GetInput() {
            int[,] inputMatrix = null;
            Console.WriteLine("Enter the number of rows in the matrix");
            try
            {
                int noRows = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of columns in the matrix");
                int noColumns = int.Parse(Console.ReadLine());
                inputMatrix = new int[noRows,noColumns];

                for (int i = 0; i < noRows; i++) {
                    Console.WriteLine("Enter the elements of row:"+i);
                    for (int j = 0; j < noColumns; j++) {
                        Console.WriteLine("Enter the element:");
                        inputMatrix[i, j] = int.Parse(Console.ReadLine());
                    }
                }
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is"+exception.Message);
            }
            return inputMatrix;
        }
    }
}
