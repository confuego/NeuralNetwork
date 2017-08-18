using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    public class Matrix
    {
        private int[] InternalDimensions { get; set; }
        
        public int[] Dimensions => InternalDimensions;

        private int[] InternalArray { get; set; }
        
        private int[] ColumnConsts { get; set; }

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

        private void InstantiateArray(int[] dimensions)
        {
            InternalDimensions = dimensions;
            var cellCount = Dimensions.Aggregate(1, (current, t) => current * t);
            InternalArray = new int[cellCount];
            
            for(var i = 0; i < InternalDimensions.Length; i++)
        }
        
        
        public Matrix(params int[] dimensions)
        {
            InstantiateArray(dimensions);
        }

        public int ValueOf(params int[] indexes)
        {
            var idx = IndexOf(indexes);
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