using System;
using System.Collections.Generic;
using System.Text;

namespace LongestPathInMatrix
{
    class MatrixProcessor
    {
        private int[,] matrix;

        public MatrixProcessor(int[,] inputMatrix) {
            matrix = inputMatrix;
        }

        private void PrintMatrix(int[,] matrix) {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            Console.WriteLine("The contents of the matrix are ................");
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("................................");
        }

        public void GetLongestPathInMatrix() {

            Console.WriteLine("The input matrix.................");
            PrintMatrix(this.matrix);

            int longestPath = int.MinValue;
            int rows = this.matrix.GetLength(0);
            int columns = this.matrix.GetLength(1);

            int[,] table = new int[rows, columns];

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    if (table[i, j] == 0) {
                        table[i, j] = FindLongestPathFromThisCell(i, j, table);
                    }

                    if (table[i, j] > longestPath) {
                        longestPath = table[i,j];
                    }
                }
            }
            Console.WriteLine("The constructed DP table matrix will be displayed....");
            PrintMatrix(table);
            Console.WriteLine("The longest Path in the matrix is "+longestPath);
        }

        private int FindLongestPathFromThisCell(int i, int j, int[,] table) {

            int rows = this.matrix.GetLength(0);
            int columns = this.matrix.GetLength(1);

            if (i >= rows || j >= columns || i < 0 || j < 0) {
                return 0;
            }

            if (table[i, j] != 0) {
                return table[i, j];
            }

            //The actual processing - Make sure to return when required for recursions!!!

            //Right Navigation
            if (j + 1 < columns && (this.matrix[i, j] + 1) == this.matrix[i, j + 1]) {
                return table[i, j] = 1 + FindLongestPathFromThisCell(i, j+1, table);
            }

            //Left Navigation
            if (j > 0 && (this.matrix[i, j] + 1) == this.matrix[i, j - 1]){
                return table[i, j] = 1 + FindLongestPathFromThisCell(i, j - 1, table);
            }

            //Top Navigation
            if (i > 0 && (this.matrix[i, j] + 1) == this.matrix[i-1, j]){
                return table[i, j] = 1 + FindLongestPathFromThisCell(i-1, j, table);
            }

            //Bottom Navigation
            if (i+1 < rows && (this.matrix[i, j] + 1) == this.matrix[i + 1, j])
            {
                return table[i, j] = 1 + FindLongestPathFromThisCell(i + 1, j, table);
            }

            return table[i, j] = 1;
        }

    }
}
