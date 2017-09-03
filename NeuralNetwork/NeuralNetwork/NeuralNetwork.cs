using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    public abstract class NeuralNetwork
    {
        
        protected int InputLayerIndex { get; set; }
        
        protected int OutputLayerIndex { get; set; }
        
        public Layer[] Layers { get; set; }
        
        
        protected NeuralNetwork(IReadOnlyCollection<Layer> networkLayers)
        {
            if (networkLayers == null || networkLayers.Count < 2)
                throw new FormatException("A Neural Network requires an input layer and an output layer.");

            InputLayerIndex = 0;
            OutputLayerIndex = networkLayers.Count - 1;
            Layers = networkLayers.ToArray();
        }
        
        
    }

    public static class NeuralNetworkFactory
    {
        public static T Create<T>(params object[] constructor) where T : NeuralNetwork
        {
            return (T) Activator.CreateInstance(typeof(T), constructor);
        }
    }
}