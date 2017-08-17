using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    public class Matrix
    {
        public readonly int[] Dimensions;

        public readonly int CellCount;
        
        private int[] InternalArray { get; set; }

        private int IndexOf(IReadOnlyList<int> indexes)
        {
            if (Dimensions.Length != indexes.Count)
                throw new IndexOutOfRangeException("Matrix dimensions do not match.");

            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var i = 0; i < indexes.Count; i++)
            {
                if (indexes[i] < 0 || indexes[i] > Dimensions[i] - 1)
                {
                    throw new IndexOutOfRangeException("Index must be one less than it's dimension and greater than 0.");
                }
            }

            var internalIndex = 0;

            for (var i = 0; i < indexes.Count; i++)
            {
                var idx = indexes[i];

                for (var dimIdx = i + 1; dimIdx < Dimensions.Length; dimIdx++)
                {
                    var columnCount = Dimensions[dimIdx];
                    idx *= columnCount;
                }

                internalIndex += idx;

            }

            return internalIndex;

        }
        
        
        public Matrix(params int[] dimensions)
        {
            Dimensions = dimensions;
            CellCount = Dimensions.Aggregate(1, (current, t) => current * t);
            InternalArray = new int[CellCount];
        }

        public int Find(params int[] indexes)
        {
            var idx = IndexOf(indexes);
            Console.WriteLine(idx);
            return InternalArray[idx];
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