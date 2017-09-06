using System;

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

        public static Matrix Multiply(Matrix a, Matrix b)
        {
            if(a.Columns != b.Rows) throw new InvalidOperationException("Columns of matrix a must match the Rows of matrix b.");

            var sum = 0.0;
            var newMatrix = new Matrix(a.Rows, b.Columns);
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

        public static Matrix Multiply(Matrix a, double constant)
        {
            for (var i = 0; i < a.InternalArray.Length; i++)
            {
                a.InternalArray[i] *= constant;
            }
            return a;
        }

        public static Matrix Add(Matrix c1, Matrix c2)
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

        public static Matrix Add(Matrix c1, double constant)
        {
            for (var i = 0; i < c1.InternalArray.Length; i++)
            {
                c1.InternalArray[i] += constant;
            }
            return c1;
        }

        public static Matrix Subtract(Matrix c1, Matrix c2)
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

        public static Vector ToVector(Matrix a)
        {
            return Vector.From(a.InternalArray);
        }

        public Vector ToVector()
        {
            return ToVector(this);
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

        public static Matrix operator +(Matrix c1, double constant)
        {
            return Add(c1, constant);
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