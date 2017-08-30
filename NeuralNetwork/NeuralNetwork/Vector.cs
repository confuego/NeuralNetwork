using System;

namespace NeuralNetwork
{
    public class Vector : Matrix
    {
        public Vector(int values) : base(values, 1) {}

        
        public double this[int row]
        {
            get => ValueOf(row, 1);
            set => InternalArray[IndexOf(row, 1)] = value;
        }

        public static Vector From(double[] data)
        {
            var vector = new Vector(data.Length);
            for (var i = 0; i < vector.InternalArray.Length; i++)
            {
                vector.InternalArray[i] = data[i];
            }

            return vector;
        }
        
        public Vector Apply(Func<double, double> activationFunction)
        {
            for (var i = 0; i < InternalArray.Length; i++)
            {
                InternalArray[i] = activationFunction(InternalArray[i]);
            }

            return this;
        }
    }
}