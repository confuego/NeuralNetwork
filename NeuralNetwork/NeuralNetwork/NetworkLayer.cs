using System;

namespace NeuralNetwork
{
    public class NetworkLayer
    {
        public Vector Neurons { get; set; }
        
        public Action<double> ActivationFunction { get; set; }

        public NetworkLayer(Vector neurons, Action<double> activationFunction)
        {
            Neurons = neurons;
            ActivationFunction = activationFunction;
        }
    }
}