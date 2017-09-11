using System;

namespace NeuralNetwork
{
    internal static class NeuralNetworkHelper
    {
        public static void Multiply(double[] firstMatrix, int row, int col, double[] secondMatrix, int row2,
            int col2, ref double[] result)
        {
            
            if(col != row2) throw new InvalidOperationException("Columns of matrix a must match the Rows of matrix b.");

            var sum = 0.0;
            result =  result ?? new double[row * col2];
            
            var totalCalculations = result.Length * col;
            var rowIncrement = 0;
            var rows = 0;
            var columnIncrement = 0;
            var rowResetCount = col * col2;
            
            for (var i = 0; i < totalCalculations; i++)
            {
                if (i !=0 && i % col  == 0)
                {
                    result[i / col - 1] = sum;
                    sum = 0;
                    rowIncrement = 0;
                    columnIncrement++;
                }
                
                if (i != 0 && i % rowResetCount == 0)
                {
                    rows++;
                    columnIncrement = 0;
                }
                
                sum += firstMatrix[rows * col + rowIncrement] * secondMatrix[rowIncrement * col2 + columnIncrement];
                rowIncrement++;


            }

            result[result.Length - 1] = sum;
        }
    }
}