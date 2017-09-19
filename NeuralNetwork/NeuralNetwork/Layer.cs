using System;

namespace NeuralNetwork
{
    public class Layer
    {
        public double[] Neurons;

        public ActivationFunction ActivationFunction { get; set; } = Activation.TanH;
        
        public double Bias { get; set; } = 0.125;

        public Layer(int neuronCount)
        {
            Neurons = new double[neuronCount];
        }
    }
}