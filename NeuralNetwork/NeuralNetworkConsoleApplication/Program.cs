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
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var neuralNetwork = new NeuralNetwork.NeuralNetwork(3,3,3,3) {Input = new double[] {1,1,1}};


            for (var i = 0; i < 10000; i++)
            {
                neuralNetwork.FeedForward();
            }
            
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}