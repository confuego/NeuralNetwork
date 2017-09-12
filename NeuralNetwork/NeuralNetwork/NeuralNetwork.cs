using System.IO;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {        
        public Layer[] Layers { get; set; }
        
        public Matrix[] Weights { get; set; }

        public double[] Input
        {
            get => Layers[0].Neurons;
            set => Layers[0].Neurons = value;
        }
        
        public double[] Output => Layers[Layers.Length - 1].Neurons;

        public void FeedForward()
        {
            for (var i = 0; i < Layers.Length - 1; i++)
            {
                var currentLayer = Layers[i];
                var currentNeurons = currentLayer.Neurons;
                var nextLayer = Layers[i + 1];
                var nextNeurons = nextLayer.Neurons;
                var func = currentLayer.ActivationFunction;
                
                Matrix.Multiply(currentNeurons, Weights[i], ref nextNeurons);
                for (var j = 0; j < currentNeurons.Length; j++)
                {
                    nextNeurons[j] = func(nextNeurons[j]) + nextLayer.Bias;
                }
            }
            
        }

        public void BackPropagate()
        {
            
        }

        public NeuralNetwork(params int[] neuronCounts)
        {
            if(neuronCounts.Length < 2) throw new InvalidDataException("A neural network must have at least two layers.");

            Layers = new Layer[neuronCounts.Length];
            Weights = new Matrix[neuronCounts.Length - 1];

            for (var i = 1; i < neuronCounts.Length; i++)
            {
                Layers[i - 1] = new Layer(neuronCounts[i - 1]);
                Weights[i - 1] = Matrix.Seed(neuronCounts[i - 1], neuronCounts[i]);
            }
            
            Layers[neuronCounts.Length - 1] = new Layer(neuronCounts[neuronCounts.Length - 1]);

        }
        
        
    }
}