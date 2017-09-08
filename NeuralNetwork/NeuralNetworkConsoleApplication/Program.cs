using System;
using System.Diagnostics;
using System.Timers;
using NeuralNetwork;

namespace NeuralNetworkConsoleApplication
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            
            // TODO: new NN(1,1,1,1)
            // randomize weights, start neurons at 0, getinput(), getoutput()
            
            
            var vector = new double[]{1,2,3};
            var matrix = new Matrix(3,2){ [0,0]=7, [0,1]=8,[1,0]=9,[1,1]=10,[2,0]=11,[2,1]=12 };
            
            var result = vector * matrix;

            foreach (var d in result)
            {
                Console.Write(d + " ");
            }

            var neuralNetwork = new NeuralNetwork.NeuralNetwork(1, 2, 3, 4, 5);

            for (var i = 0; i < 10000; i++)
            {
                neuralNetwork.FeedForward();
            }
        }
    }
}