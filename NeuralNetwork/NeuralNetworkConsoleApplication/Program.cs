using System;
using NeuralNetwork;

namespace NeuralNetworkConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = new Matrix(2, 3) {[0, 0] = 1, [0,1]=2, [0,2]=3, [1,0]=4,[1,1]=5,[1,2]=6};
            var matrix2 = new Matrix(3,2){ [0,0]=7,[0,1]=8, [1,0]=9,[1,1]=10,[2,0]=11,[2,1]=12 };
            Console.WriteLine(matrix * matrix2);
        }
    }
}