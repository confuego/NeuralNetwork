using System;
using NeuralNetwork;

namespace NeuralNetworkConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = new Matrix(1, 3) {[0, 0] = 3, [0,1]=4, [0,2]=2};

            var vector = Vector.From(new double[]{1, 2, 3});
            vector = vector.Apply(ActivationFunction.Sigmoid);
            Console.WriteLine(matrix * vector * 10);
        }
    }
}