using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {
        
        protected int InputLayerIndex { get; set; }
        
        protected int OutputLayerIndex { get; set; }
        
        public Layer[] Layers { get; set; }

        public void FeedForward()
        {
            var currentLayer = Layers[InputLayerIndex];
            for (var i = 0; i < Layers.Length - 1; i++)
            {
                var nextLayer = Layers[i + 1];
                nextLayer.Neurons =
                    (currentLayer.Neurons * nextLayer.Weights + currentLayer.Bias).ToVector()
                    .Apply(currentLayer.ActivationFunction);
                currentLayer = nextLayer;

            }
        }

        public void BackPropagate()
        {
            
        }
        
        
        public NeuralNetwork(params Layer[] layers)
        {
            if (layers == null || layers.Length < 2)
                throw new FormatException("A Neural Network requires an input layer and an output layer.");

            InputLayerIndex = 0;
            OutputLayerIndex = layers.Length - 1;
            Layers = layers.ToArray();
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