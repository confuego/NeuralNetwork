using System;
using System.Diagnostics;
using System.Timers;
using NeuralNetwork;

namespace NeuralNetworkConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            // TODO: new NN(1,1,1,1)
            // randomize weights, start neurons at 0, getinput(), getoutput()
            
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            var matrix = new Matrix(1, 3) {[0, 0] = 3, [0,1]=4, [0,2]=2};
            var inputLayer = new Layer(Vector.From(new double[] {1, 2, 3}), matrix, ActivationFunction.Sigmoid, 0);
            var secondLayer = new Layer(Vector.From(new double[] {1, 2, 3}), matrix, ActivationFunction.Sigmoid, 0);
            var thirdLayer = new Layer(Vector.From(new double[] {1, 2, 3}), matrix, ActivationFunction.Sigmoid, 0);
            var outputLayer = new Layer(Vector.From(new double[] {1, 2, 3}), matrix, ActivationFunction.Sigmoid, 0);
            var neuralNetwork = new NeuralNetwork.NeuralNetwork(inputLayer, secondLayer, thirdLayer, outputLayer);

            for (var i = 0; i < 10000; i++)
            {
                neuralNetwork.FeedForward();
            }
            
            foreach (var t in neuralNetwork.Layers)
            {
                Console.WriteLine(t.Neurons);
            }
            
            stopwatch.Stop();
            
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            
        }
    }
}