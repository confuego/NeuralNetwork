using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {
                
        protected int OutputLayerIndex { get; set; }
        
        public Layer[] Layers { get; set; }

        public void FeedForward()
        {

            var currentLayer = Layers[0];
            var nextLayer = Layers[1];
            
            for (var i = 0; i < Layers.Length; i++)
            {
                nextLayer.Neurons = currentLayer.Neurons * currentLayer.Weights 
            }
            
        }

        public void BackPropagate()
        {
            
        }
        
        
        public NeuralNetwork(params Layer[] layers)
        {
            if(layers.Length < 2) throw new InvalidDataException("A neural network must have at least two layers.");

            Layers = layers;
            OutputLayerIndex = Layers.Length - 1;

            for (var i = 1; i < Layers.Length; i++)
            {
                Layers[i - 1].Weights = Matrix.Seed(Layers[i - 1].Neurons.Length, Layers[i].Neurons.Length);
            }
            
        }
        
        
    }
}