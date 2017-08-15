using System;
using NeuralNetwork;

namespace NeuralNetworkConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = new Matrix(1, 1);
            Console.WriteLine(matrix.Columns);
        }
    }
}