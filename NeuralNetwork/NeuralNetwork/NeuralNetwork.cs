﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                Matrix.Multiply(Layers[i].Neurons, Weights[i], ref Layers[i + 1].Neurons);
                var currentLayer = Layers[i + 1];
                for (var j = 0; j < Layers[i + 1].Neurons.Length; j++)
                {
                    currentLayer.Neurons[j] = Layers[i + 1].ActivationFunction(currentLayer.Neurons[i]) + currentLayer.Bias;
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