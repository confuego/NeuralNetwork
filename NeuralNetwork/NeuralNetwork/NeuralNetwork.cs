using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {        
        public Layer[] Layers { get; set; }

        public void FeedForward()
        {            
            var currentLayer = Layers[0];

            for (var i = 0; i < Layers.Length - 1; i++)
            {
                var nextLayer = Layers[i + 1];
                nextLayer.Neurons = Matrix.Multiply(currentLayer.Neurons, currentLayer.Weights, nextLayer.Neurons,
                    cell => currentLayer.ActivationFunction(cell) + currentLayer.Bias);
                
                currentLayer = nextLayer;
            }
            
        }

        public void BackPropagate()
        {
            
        }

        public NeuralNetwork(params int[] neuronCounts)
        {
            if(neuronCounts.Length < 2) throw new InvalidDataException("A neural network must have at least two layers.");

            Layers = new Layer[neuronCounts.Length];
            
            for (var i = 1; i < neuronCounts.Length; i++)
            {
                var weights = Matrix.Seed(neuronCounts[i - 1], neuronCounts[i]);
                Layers[i - 1] =
                    new Layer(neuronCounts[i - 1])
                    {
                        Weights = weights
                    };
            }
            
            Layers[Layers.Length - 1] = new Layer(neuronCounts[neuronCounts.Length - 1]);
        }
        
        
    }
}