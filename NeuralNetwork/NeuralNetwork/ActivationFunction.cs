using System;

namespace NeuralNetwork
{
    public struct ActivationFunction
    {
        public static Func<double, double> Linear = n => n;
        public static Func<double, double> Sigmoid = n => 1 / (1 + Math.Exp(-n));
        public static Func<double, double> TanH = n =>
        {
            var expValue = Math.Exp(2 * n);
            return (expValue - 1) / (expValue + 1);
        };
        public static Func<double, double> RectifiedLinear = n => (n > 0) ? n : 0;
    }
}