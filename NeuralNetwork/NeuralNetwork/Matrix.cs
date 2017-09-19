using System;
using System.IO;

namespace NeuralNetwork
{
	public class Matrix
	{
		public int Rows;

		public int Columns;

		public double[] InternalArray;

		private void InstantiateArray(int rows, int cols)
		{
			Rows = rows;
			Columns = cols;
			InternalArray = new double[rows * cols];
		}

		public int IndexOf(int row, int col)
		{
			var idx = row * Columns + col;
			if (idx < 0 || idx > InternalArray.Length) throw new IndexOutOfRangeException();
			return idx;
		}
        
		public Matrix(int rows, int columns)
		{
			InstantiateArray(rows, columns);
		}

		public double ValueOf(int row, int col)
		{
			var idx = IndexOf(row, col);
			return InternalArray[idx];
		}

		public static Matrix Seed(int row, int col, double multiplier = 100)
		{
			var random = new Random();
			var matrix = new Matrix(row, col);

			for (var i = 0; i < matrix.InternalArray.Length; i++)
				matrix.InternalArray[i] = random.NextDouble() * multiplier;
			return matrix;
		}

		public static void Multiply(Matrix left, Matrix right, Matrix result)
		{
			int dstW = result.Columns,
				dstH = result.Rows,
				dotLen = left.Columns,
				i, j, k;
			
			double[] a0 = left.InternalArray;
			double[] b0 = right.InternalArray;
			double[] c0 = result.InternalArray;

			int a = 0,
				b = 0,
				c = -1;

			double dp;

			if (dstH != left.Rows || dstW != right.Columns)
				throw new Exception("Destination matrix is not properly allocated.");

			if (dotLen != right.Rows)
				throw new Exception("Operand matrix is not properly allocated.");

			for (i = 0; i < dstH; ++i) {
				for (j = 0; j < dstW; ++j) {
					dp = 0;
					for (k = 0; k < dotLen; ++k)
						dp += a0[a + k] * b0[b + k * dstW];
					c0[++c] = dp;
					++b;
				}
				a += dotLen;
				b -= dstW;
			}
		}

		public static void Multiply(Matrix a, double constant, ref Matrix b)
		{
			for (var i = 0; i < a.InternalArray.Length; i++)
			{
				b.InternalArray[i] *= constant;
			}
		}

		public static void Multiply(double[] vector, Matrix a, double[] storage)
		{   
			if (storage.Length != a.Columns) throw new InvalidDataException("Resultant vector must be the same size as the columns in the matrix.");

			NeuralNetworkHelper.Multiply(vector, 1, vector.Length, a.InternalArray, a.Rows, a.Columns, storage);
		}

		public static void Add(Matrix c1, Matrix c2, ref Matrix c3)
		{
			if (c1.Rows != c2.Columns || c1.Columns != c2.Columns)
				throw new InvalidOperationException("Cannot add different size matrices");
            
			if (c3.Rows != c2.Columns || c3.Columns != c2.Columns)
				throw new InvalidOperationException("Provided matrix to store addition must be the same size as the operands.");
            
			var cellCount = c1.Rows * c2.Columns;
            
			for (var i = 0; i < cellCount; i++)
			{
				c3.InternalArray[i] = c1.InternalArray[i] + c2.InternalArray[i];
			}
		}

		public static void Subtract(Matrix c1, Matrix c2, ref Matrix c3)
		{
			if (c1.Rows != c2.Columns || c1.Columns != c2.Columns)
				throw new InvalidOperationException("Cannot add different size matrices");
            
			if (c3.Rows != c2.Columns || c3.Columns != c2.Columns)
				throw new InvalidOperationException("Provided matrix to store addition must be the same size as the operands.");
            
			var cellCount = c1.Rows * c2.Columns;
            
			for (var i = 0; i < cellCount; i++)
			{
				c3.InternalArray[i] = c1.InternalArray[i] - c2.InternalArray[i];
			}
		}
        
		public double this[int row, int col]
		{
			get => ValueOf(row, col);
			set => InternalArray[IndexOf(row, col)] = value;
		}
        
		public static Matrix operator +(Matrix c1, Matrix c2)
		{
			var matrix = new Matrix(c1.Rows, c1.Columns);
			Add(c1, c2, ref matrix);
			return matrix;
		}

		public static Matrix operator -(Matrix c1, Matrix c2)
		{
			var matrix = new Matrix(c1.Rows, c1.Columns);
			Subtract(c1, c2, ref matrix);
			return matrix;
		}

		public static Matrix operator *(Matrix a, double constant)
		{
			var matrix = new Matrix(a.Rows, a.Columns);
			Multiply(a, constant, ref matrix);
			return matrix;
		}
        
		public static Matrix operator *(double constant, Matrix a)
		{
			var matrix = new Matrix(a.Rows, a.Columns);
			Multiply(a, constant, ref matrix);
			return matrix;
		}
            
		public static Matrix operator *(Matrix a, Matrix b)
		{
			var matrix = new Matrix(a.Rows, b.Columns);
			Multiply(a, b, matrix);
			return matrix;
		}
        
		public static double[] operator *(double[] vector, Matrix a)
		{
			var resultantVector = new double[a.Columns];
			Multiply(vector, a, resultantVector);
			return resultantVector;
		}

		public override string ToString()
		{
			var result = string.Empty;
			var cellCount = Rows * Columns;
			for (var i = 0; i < cellCount; i++)
			{
				if (i % Columns == 0) result += Environment.NewLine;
				result +=  " " + InternalArray[i];
			}

			return result;
		}
	}
}