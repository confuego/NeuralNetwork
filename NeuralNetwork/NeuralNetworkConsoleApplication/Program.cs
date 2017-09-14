using System;
using System.Diagnostics;
using System.Timers;
using NeuralNetwork;
using System.Threading;

namespace NeuralNetworkConsoleApplication
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			//var neuralNetwork = new NeuralNetwork.NeuralNetwork(3,3,3,3) {Input = new double[] {1,1,1}};
			//for (var i = 0; i < 1000000; i++)
			//	neuralNetwork.FeedForward();

			Matrix L0 = new Matrix(3, 1);
			Matrix L1 = new Matrix(3, 1);
			Matrix L2 = new Matrix(3, 1);
			Matrix L3 = new Matrix(3, 1);
			Matrix W0 = new Matrix(3, 3);
			Matrix W1 = new Matrix(3, 3);
			Matrix W2 = new Matrix(3, 3);

			for (int i = 0; i < 1000000; i++) {
				Matrix.Multiply(W0, L0, L1);
				Matrix.Multiply(W1, L1, L2);
				Matrix.Multiply(W2, L2, L3);
			}
			
			stopwatch.Stop();
			Console.WriteLine(stopwatch.ElapsedMilliseconds);
			Thread.Sleep(5000);
		}
	}
}