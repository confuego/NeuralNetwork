using System;

namespace NeuralNetwork
{
	internal static class NeuralNetworkHelper
	{
		public static void Multiply(double[] firstMatrix, int row, int col, double[] secondMatrix, int row2,
			int col2, double[] result)
		{
			double sum = 0.0;
			int totalCalculations = result.Length * col,
				rowIncrement = 0,
				rows = 0,
				columnIncrement = 0,
				rowResetCount = col * col2;

			//if (col != row2) throw new InvalidOperationException("Columns of matrix a must match the Rows of matrix b.");

			for (int i = 0; i < totalCalculations; i++)
			{
				if (i != 0)
				{
					if (i % col == 0)
					{
						result[i / col - 1] = sum;
						sum = 0;
						rowIncrement = 0;
						columnIncrement++;
					}
					if (i % rowResetCount == 0)
					{
						rows++;
						columnIncrement = 0;
					}
				}
				
				sum += firstMatrix[rows * col + rowIncrement] * secondMatrix[rowIncrement * col2 + columnIncrement];
				rowIncrement++;
			}

			result[result.Length - 1] = sum;
		}
	}
}