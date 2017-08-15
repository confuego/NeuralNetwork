namespace NeuralNetwork
{
    public class Matrix
    {
        public int Rows { get; set; }
        
        public int Columns { get; set; }
        
        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }
    }
}