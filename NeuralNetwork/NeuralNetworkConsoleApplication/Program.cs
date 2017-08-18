using System;
using NeuralNetwork;

namespace NeuralNetworkConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = new Matrix(2,2);
            matrix.Add(10, 0, 0).Add(11, 1, 1).Add(-1, 0, 1);
            Console.WriteLine(matrix.ValueOf(0,0));
            Console.WriteLine(matrix.ValueOf(1,1));
            Console.WriteLine(matrix.ValueOf(0, 1));
            Console.WriteLine(matrix.ValueOf(1,0));
        }
    }
}