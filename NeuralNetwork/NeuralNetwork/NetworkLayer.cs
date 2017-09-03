using System;

namespace NeuralNetwork
{
    public class Layer
    {
        public Vector Neurons { get; set; }
        
        public Matrix Weights { get; set; }
        
        public Action<double> ActivationFunction { get; set; }
        
        public double Bias { get; set; }

        public Layer(Vector neurons, Matrix weights, Action<double> activationFunction)
        {
            Weights = weights;
            Neurons = neurons;
            ActivationFunction = activationFunction;
        }
    }
}