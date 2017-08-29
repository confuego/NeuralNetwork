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
            if(a.Columns != b.Rows) throw new InvalidOperationException("Columns of matrix a must match the Rows of matrix b.");

            var sum = 0.0;
            var newMatrix = new Matrix(a.Rows, b.Columns);
            var totalCalculations = newMatrix.InternalArray.Length * a.Columns;
            var cols = 0;
            var rows = 0;
            var columnCount = 0;
            
            for (var i = 0; i < totalCalculations; i++)
            {
                if (i !=0 && i % a.Columns  == 0)
                {
                    //Console.WriteLine("Sum: " + sum);
                    newMatrix.InternalArray[i / a.Columns - 1] = sum;
                    sum = 0;
                    cols = 0;
                    columnCount++;
                }
                
                if (i != 0 && i % (a.Columns * b.Columns) == 0)
                {
                    //Console.WriteLine("Row Change: " + i);
                    rows++;
                    columnCount = 0;
                }
                  
                //Console.WriteLine(a.InternalArray[rows * a.Columns + cols] + " X " + b.InternalArray[cols * b.Columns + columnCount]);
                
                sum += a.InternalArray[rows * a.Columns + cols] * b.InternalArray[cols * b.Columns + columnCount];
                cols++;


            }

            newMatrix.InternalArray[newMatrix.InternalArray.Length - 1] = sum;
            
            return newMatrix;
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