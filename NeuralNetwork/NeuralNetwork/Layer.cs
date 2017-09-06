using System;

namespace NeuralNetwork
{
    public class Layer
    {
        public Vector Neurons { get; set; }
        
        public Matrix Weights { get; set; }
        
        public Func<double,double> ActivationFunction { get; set; }
        
        public double Bias { get; set; }

        public Layer(Vector neurons, Matrix weights, Func<double,double> activationFunction, double bias)
        {
            Weights = weights;
            Neurons = neurons;
            ActivationFunction = activationFunction;
            Bias = bias;
        }
    }
}