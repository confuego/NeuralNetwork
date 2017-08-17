using System;
using NeuralNetwork;

namespace NeuralNetworkConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = new Matrix(2,2,2);
            Console.WriteLine(matrix.Find(0,0,1));          
        }
    }
}