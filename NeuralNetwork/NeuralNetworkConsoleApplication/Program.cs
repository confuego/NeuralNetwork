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
			var neuralNetwork = new NeuralNetwork.NeuralNetwork(3,3,3,3)
			{
				Input = new double[] {1,1,1}
			};
			
			for (var i = 0; i < 1000000; i++)
				neuralNetwork.FeedForward();
		}
	}
}