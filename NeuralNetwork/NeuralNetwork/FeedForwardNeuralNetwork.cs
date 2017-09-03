using System.Collections.Generic;

namespace NeuralNetwork
{
    public class FeedForwardNeuralNetwork : NeuralNetwork
    {
        public FeedForwardNeuralNetwork(IReadOnlyCollection<Layer> networkLayers) : base(networkLayers) {}

        public void FeedForward()
        {
            var inputLayer = Layers[InputLayerIndex];
            
        }
    }
}