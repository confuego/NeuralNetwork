using System.Data.Common;
using System.Linq;

namespace NeuralNetwork
{
    public class Matrix
    {
        public readonly int[] Dimensions;

        public readonly int CellCount;
        
        private int[] InternalMatrix { get; set; }
        
        
        public Matrix(params int[] dimensions)
        {
            Dimensions = dimensions;

            CellCount = Dimensions.Aggregate(1, (current, t) => current * t);

            InternalMatrix = new int[CellCount];
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