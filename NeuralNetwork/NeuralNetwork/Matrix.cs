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
            InstantiateArray(rows, columns);
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
            return matrix;
        }

        public static Matrix Multiply(Matrix a, Matrix b, Matrix c = null)
        {

            if(a.Columns != b.Rows) throw new InvalidOperationException("Columns of matrix a must match the Rows of matrix b.");
            
            c = c ?? new Matrix(a.Rows, b.Columns);
            
            c.InternalArray = NeuralNetworkHelper.Multiply(a.InternalArray, a.Rows, a.Columns, b.InternalArray, b.Rows, b.Columns,
                c.InternalArray);

            return c;
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

        public static double[] Multiply(double[] vector, Matrix a, double[] storage = null, Func<double, double> onCellCreation = null)
        {
            storage = storage ?? new double[a.Columns];
            
            if(storage.Length != a.Columns) throw new InvalidDataException("Resultant vector must be the same size as the columns in the matrix.");

            return NeuralNetworkHelper.Multiply(vector, 1, vector.Length, a.InternalArray, a.Rows, a.Columns, storage, onCellCreation);
        }

        public static Matrix Add(Matrix c1, Matrix c2, Matrix c3 = null)
        {
            if (c1.Rows != c2.Columns || c1.Columns != c2.Columns)
                throw new InvalidOperationException("Cannot add different size matrices");


            c3 = c3 ?? new Matrix(c1.Rows, c1.Columns);
            
            if (c3.Rows != c2.Columns || c3.Columns != c2.Columns)
                throw new InvalidOperationException("Provided matrix to store addition must be the same size as the operands.");
            
            var cellCount = c1.Rows * c2.Columns;
            
            for (var i = 0; i < cellCount; i++)
            {
                c3.InternalArray[i] = c1.InternalArray[i] + c2.InternalArray[i];
            }
            
            return c3;
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
        
        public static Matrix operator *(double constant, Matrix a)
        {
            return Multiply(a, constant);
        }
            
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Multiply(a, b);
        }
        
        public static double[] operator *(double[] vector, Matrix a)
        {
            return Multiply(vector, a);
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