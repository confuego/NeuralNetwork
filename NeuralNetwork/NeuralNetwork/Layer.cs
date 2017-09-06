using System;

namespace NeuralNetwork
{
    public class Layer
    {
        private Func<double, double> _activationFunction;

        public double[] Neurons { get; set; }
        
        public Matrix Weights { get; set; }
        
        public Func<double,double> ActivationFunction {
            get => _activationFunction ?? global::NeuralNetwork.ActivationFunction.TanH;
            set => _activationFunction = value;
        }
        
        public double Bias { get; set; } = 0.125;

        public Layer(int neuronCount)
        {
            Neurons = new double[neuronCount];
        }
    }
}