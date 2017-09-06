using System;
using System.IO;

namespace NeuralNetwork
{
    public class Matrix
    {   
        public int Rows { get; set; }
        
        public int Columns { get; set; }
        
        protected double[] InternalArray { get; set; }

        private void InstantiateArray(int rows, int cols)
        {
            Rows = rows;
            Columns = cols;
            InternalArray = new double[rows * cols];
        }

        public int IndexOf(int row, int col)
        {
            var idx = row * Columns + col;
            if(idx < 0 || idx > InternalArray.Length) throw new IndexOutOfRangeException();
            return idx;
        }
        
        public Matrix(int rows, int columns)
        {
            InstantiateArray(rows, columns, data);
        }

        public double ValueOf(int row, int col)
        {
            var idx = IndexOf(row, col);
            return InternalArray[idx];
        }

        public static Matrix Seed(int row, int col)
        {
            var random = new Random();
            var matrix = new Matrix(row, col);

            for (var i = 0; i < matrix.InternalArray.Length; i++)
            {
                matrix.InternalArray[i] = random.NextDouble();
            }
        }

        public static Matrix Multiply(Matrix a, Matrix b, Matrix c = null)
        {
            if(a.Columns != b.Rows) throw new InvalidOperationException("Columns of matrix a must match the Rows of matrix b.");

            var sum = 0.0;
            var newMatrix = c ?? new Matrix(a.Rows, b.Columns);

            if (newMatrix.Rows != a.Rows || newMatrix.Columns != b.Columns)
                throw new InvalidOperationException("Destination matrix must be sized properly.");
            
            var totalCalculations = newMatrix.InternalArray.Length * a.Columns;
            var rowIncrement = 0;
            var rows = 0;
            var columnIncrement = 0;
            
            for (var i = 0; i < totalCalculations; i++)
            {
                if (i !=0 && i % a.Columns  == 0)
                {
                    newMatrix.InternalArray[i / a.Columns - 1] = sum;
                    sum = 0;
                    rowIncrement = 0;
                    columnIncrement++;
                }
                
                if (i != 0 && i % (a.Columns * b.Columns) == 0)
                {
                    rows++;
                    columnIncrement = 0;
                }
                
                sum += a.InternalArray[rows * a.Columns + rowIncrement] * b.InternalArray[rowIncrement * b.Columns + columnIncrement];
                rowIncrement++;


            }

            newMatrix.InternalArray[newMatrix.InternalArray.Length - 1] = sum;
            
            return newMatrix;
        }

        public static Matrix Multiply(Matrix a, double constant, Matrix b = null)
        {
            var newMatrix = b ?? new Matrix(a.Rows, a.Columns); 
            for (var i = 0; i < a.InternalArray.Length; i++)
            {
                newMatrix.InternalArray[i] *= constant;
            }
            return newMatrix;
        }

        public static double[] Multiply(Matrix a, double[] vector, double[] storage = null)
        {
            var resultVector = storage ?? new double[a.Columns];
            
            if(resultVector.Length != a.Columns) throw new InvalidDataException("Resultant vector must be the same size as the columns in the matrix.");

            for (var i = 0; i < resultVector.Length; i++)
            {
                resultVector[i] = 
            }
        }

        public static Matrix Add(Matrix c1, Matrix c2, Matrix c3 = null)
        {
            if (c1.Rows != c2.Columns || c1.Columns != c2.Columns)
                throw new InvalidOperationException("Cannot add different size matrices");


            var newMatrix = c3 ?? new Matrix(c1.Rows, c1.Columns);
            
            if (newMatrix.Rows != c2.Columns || newMatrix.Columns != c2.Columns)
                throw new InvalidOperationException("Provided matrix to store addition must be the same size as the operands.");
            
            var cellCount = c1.Rows * c2.Columns;
            
            for (var i = 0; i < cellCount; i++)
            {
                newMatrix.InternalArray[i] = c1.InternalArray[i] + c2.InternalArray[i];
            }
            
            return newMatrix;
        }

        public static Matrix Subtract(Matrix c1, Matrix c2, Matrix c3 = null)
        {
            if (c1.Rows != c2.Columns || c1.Columns != c2.Columns)
                throw new InvalidOperationException("Cannot add different size matrices");

            
            var newMatrix = c3 ?? new Matrix(c1.Rows, c1.Columns);
            
            if (newMatrix.Rows != c2.Columns || newMatrix.Columns != c2.Columns)
                throw new InvalidOperationException("Provided matrix to store addition must be the same size as the operands.");
            
            var cellCount = c1.Rows * c2.Columns;
            
            for (var i = 0; i < cellCount; i++)
            {
                newMatrix.InternalArray[i] = c1.InternalArray[i] - c2.InternalArray[i];
            }
            
            return newMatrix;
        }
        
        public double this[int row, int col]
        {
            get => ValueOf(row, col);
            set => InternalArray[IndexOf(row, col)] = value;
        }
        
        public static Matrix operator +(Matrix c1, Matrix c2)
        {
            return Add(c1, c2);
        }

        public static Matrix operator -(Matrix c1, Matrix c2)
        {
            return Subtract(c1, c2);
        }

        public static Matrix operator *(Matrix a, double constant)
        {
            return Multiply(a, constant);
        }
            
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Multiply(a, b);
        }

        public static Matrix From(double[][] data)
        {
            var matrix = new Matrix(data.Length, data[0].Length);

            for (var i = 0; i < data.Length; i++)
            {
                for (var j = 0; j < data[i].Length; j++)
                {
                    matrix[i, j] = data[i][j];
                }
            }

            return matrix;
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