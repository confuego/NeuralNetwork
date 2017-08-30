using System;
using NeuralNetwork;

namespace NeuralNetworkConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = new Matrix(1, 3) {[0, 0] = 3, [0,1]=4, [0,2]=2};
            var matrix2 = new Matrix(3,4){ [0,0]=13,[0,1]=9, [0,2]=7,[0,3]=15, [1,0]=8,[1,1]=7, [1,2]=4,[1,3]=6,[2,0]=6,[2,1]=4, [2,2]=0,[2,3]=3};
            Console.WriteLine(matrix * matrix2 * 5);

            var network = new NeuralNetworkConfiguration().CreateNetwork();
        }
    }
}