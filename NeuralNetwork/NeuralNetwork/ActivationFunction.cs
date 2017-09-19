using System;

namespace NeuralNetwork
{
    public struct Activation
    {
        public static readonly ActivationFunction Linear = new ActivationFunction
        {
            Base = n => n,
            Derivative = n => 1
        };
        public static readonly ActivationFunction Sigmoid = new ActivationFunction
        {
            Base = n => 1 / (1 + Math.Exp(-n)),
            Derivative = n => 1
        };

        public static readonly ActivationFunction TanH = new ActivationFunction
        {
            Base = n =>
            {
                var expValue = Math.Exp(2 * n);
                return (expValue - 1) / (expValue + 1);
            },
            Derivative = n => 1

        };
        public static readonly ActivationFunction RectifiedLinear = new ActivationFunction
        {
            Base =  n => (n > 0) ? n : 0,
            Derivative = n => 1
        };
    }

    public class ActivationFunction
    {
        public Func<double,double> Base { get; set; }
        
        public Func<double, double> Derivative { get; set; }
    }
}