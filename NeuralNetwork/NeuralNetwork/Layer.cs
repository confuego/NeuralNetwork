namespace NeuralNetwork
{
    public class Layer
    {
        public double[] Neurons
        {
            get => _neuronBuffer;
            set 
            { 
                _neuronBuffer = value;
                for (var i = 0; i < _neuronBuffer.Length; i++)
                {
                    _activatedNeuronsBuffer[i] = ActivationFunction.Base(_neuronBuffer[i]);
                }
            }
        }

        public ActivationFunction ActivationFunction { get; set; } = Activation.TanH;
        
        public double Bias { get; set; } = 0.125;

        public void CalculateChange(Layer layerAfter)
        {
            
        }

        public Layer(int neuronCount)
        {
            _neuronBuffer = new double[neuronCount];
            _neuronChangeBuffer = new double[neuronCount];
            _acitvatedNeuronsChangeBuffer = new double[neuronCount];
            _activatedNeuronsBuffer = new double[neuronCount];
        }

        private double[] _neuronBuffer;
        
        private double[] _neuronChangeBuffer;

        private readonly double[] _activatedNeuronsBuffer;

        private double[] _acitvatedNeuronsChangeBuffer;
    }
}