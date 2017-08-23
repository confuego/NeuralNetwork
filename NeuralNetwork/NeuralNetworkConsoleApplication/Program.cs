using System;
using NeuralNetwork;

namespace NeuralNetworkConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = new Matrix(2, 2) {[0, 0] = 10};
            Console.WriteLine(matrix);
            Console.WriteLine(matrix - matrix);
        }
    }
}