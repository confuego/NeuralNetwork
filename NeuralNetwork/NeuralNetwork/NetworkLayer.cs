using System;

namespace NeuralNetwork
{
    public class NetworkLayer
    {
        public Matrix Vector { get; set; }
        
        public Action<double> ActivationFunction { get; set; }

        public NetworkLayer(Matrix vector, Action<double> activationFunction)
        {
            Vector = vector;
            ActivationFunction = activationFunction;
        }
    }
}