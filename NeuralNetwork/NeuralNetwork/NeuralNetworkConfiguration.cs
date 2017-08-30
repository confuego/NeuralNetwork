using System.Collections.Generic;

namespace NeuralNetwork
{
    public class NeuralNetworkConfiguration
    {
        private NetworkLayer InputLayer { get; set; }
        
        private NetworkLayer OutputLayer { get; set; }
        
        private List<NetworkLayer> HiddenLayers { get; set; }

        public NeuralNetworkConfiguration()
        {
            HiddenLayers = new List<NetworkLayer>();
        }

        public NeuralNetworkConfiguration Input(NetworkLayer layer)
        {
            InputLayer = layer;
            return this;
        }

        public NeuralNetworkConfiguration Output(NetworkLayer layer)
        {
            OutputLayer = layer;
            return this;
        }

        public NeuralNetworkConfiguration AddAll(params NetworkLayer[] layers)
        {
            HiddenLayers.AddRange(layers);
            return this;
        }

        public NeuralNetwork CreateNetwork()
        {
            HiddenLayers.Insert(0, InputLayer);
            HiddenLayers.Add(OutputLayer);
            return new NeuralNetwork(HiddenLayers);
        }
    }
}