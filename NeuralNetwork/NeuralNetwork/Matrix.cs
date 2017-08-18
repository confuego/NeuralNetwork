using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    public class Matrix
    {
        // ReSharper disable once InconsistentNaming
        private int[] _dimensions { get; set; }
        
        public int[] Dimensions => _dimensions;

        private int[] InternalArray { get; set; }
        
        private int[] ColumnConsts { get; set; }

        private int IndexOf(IReadOnlyList<int> indices)
        {
            if (Dimensions.Length != indices.Count)
                throw new IndexOutOfRangeException("Matrix dimensions do not match.");

            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var i = 0; i < indices.Count; i++)
            {
                if (indices[i] < 0 || indices[i] > Dimensions[i] - 1)
                {
                    throw new IndexOutOfRangeException("Index must be one less than it's dimension and greater than 0.");
                }
            }

            var internalIndex = 0;

            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var i = 0; i < indices.Count; i++)
            {
                var idx = indices[i];
                internalIndex += idx * ColumnConsts[i];

            }

            return internalIndex;

        }

        private void InstantiateArray(int[] dimensions)
        {
            _dimensions = dimensions;
            
            var cellCount = Dimensions.Aggregate(1, (current, t) => current * t);
            InternalArray = new int[cellCount];
            ColumnConsts = new int[_dimensions.Length];

            var accumulatedConstant = 1;
            ColumnConsts[_dimensions.Length - 1] = accumulatedConstant;
            for (var i = _dimensions.Length - 1; i > 0; i--)
            {
                accumulatedConstant *= _dimensions[i];
                ColumnConsts[i-1] = accumulatedConstant;
            }
        }
        
        
        public Matrix(params int[] dimensions)
        {
            InstantiateArray(dimensions);
        }

        public int ValueOf(params int[] indices)
        {
            var idx = IndexOf(indices);
            return InternalArray[idx];
        }

        public Matrix Add(int value, params int[] indices)
        {
            var idx = IndexOf(indices);
            InternalArray[idx] = value;
            return this;
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