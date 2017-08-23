using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class Matrix
    {
        public int Rows { get; set; }
        
        public int Columns { get; set; }

        public double[] InternalArray { get; set; }

        private int IndexOf(int row, int col)
        {
            var idx = row * Columns + col;
            if(idx < 0 || idx > InternalArray.Length) throw new IndexOutOfRangeException();
            return idx;
        }

        private void InstantiateArray(int rows, int cols)
        {
            Rows = rows;
            Columns = cols;
            InternalArray = new double[rows * cols];
        }

        public Matrix(IReadOnlyList<int[]> matrix)
        {
            InstantiateArray(matrix.Count, matrix[0].Length);
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

        public Matrix Add(int row, int col, int value)
        {
            var idx = IndexOf(row, col);
            InternalArray[idx] = value;
            return this;
        }
        
        public double this[int row, int col]
        {
            get => ValueOf(row, col);
            set => InternalArray[IndexOf(row, col)] = value;
        }
        
        public static Matrix operator +(Matrix c1, Matrix c2)
        {
            if (c1.Rows != c2.Columns || c1.Columns != c2.Columns)
                throw new InvalidOperationException("Cannot add different size matrices");

            var cellCount = c1.Rows * c2.Columns;
            
            for (var i = 0; i < cellCount; i++)
            {
                c1.InternalArray[i] = c1.InternalArray[i] + c2.InternalArray[i];
            }
            
            return c1;
        }

        public static Matrix operator -(Matrix c1, Matrix c2)
        {
            if (c1.Rows != c2.Columns || c1.Columns != c2.Columns)
                throw new InvalidOperationException("Cannot add different size matrices");

            var cellCount = c1.Rows * c2.Columns;
            
            for (var i = 0; i < cellCount; i++)
            {
                c1.InternalArray[i] = c1.InternalArray[i] - c2.InternalArray[i];
            }
            
            return c1;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            return new Matrix(1, 1);
        }

        public static Matrix operator /(Matrix a, Matrix b)
        {
            return new Matrix(1, 1);
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