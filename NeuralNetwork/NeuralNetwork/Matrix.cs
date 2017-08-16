using System.Data.Common;

namespace NeuralNetwork
{
    public class Matrix
    {
        public readonly int[] Dimensions;
        
        private int[,] InternalMatrix { get; set; }

        private static int[,] CreateArray(int[] dimensions)
        {
            
        }
        
        public Matrix(params int[] dimensions)
        {
            Dimensions = dimensions;
            InternalMatrix = CreateArray(dimensions);
        }
        
        public static Matrix operator +(Matrix c1, Matrix c2)
        {
            return new Matrix(1,1);
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            return new Matrix(1, 1);
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            return new Matrix(1, 1);
        }

        public static Matrix operator /(Matrix a, Matrix b)
        {
            return new Matrix(1, 1);
        }
    }
}