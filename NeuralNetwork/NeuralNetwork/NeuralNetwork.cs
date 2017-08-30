using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {
        
        public int InputLayerIndex { get; set; }
        
        public int OutputLayerIndex { get; set; }
        
        public IEnumerable<NetworkLayer> Layers { get; set; }
        
        public NeuralNetwork(IReadOnlyCollection<NetworkLayer> networkLayers)
        {
            if (networkLayers == null || networkLayers.Count < 2)
                throw new FormatException("A Neural Network requires an input layer and an output layer.");

            InputLayerIndex = 0;
            OutputLayerIndex = networkLayers.Count - 1;
            Layers = networkLayers;
        }
        
        
    }
}