namespace MatrixCalculation;

public class Matrix
{
    public int Size { get; set; }
    public int[,] Table { get; set; }
    
    public Matrix(int size)
    {
        Size = size;
        Random random = new Random();
        this.Table = new int[this.Size, this.Size];

        for (int i = 0; i < this.Size; i++)
        {
            for (int j = 0; j < this.Size; j++)
            {
                this.Table[i, j] = random.Next(10);
            }
        }
    }
    

    public override string ToString()
    {
        string resultString = "";
        for (int i = 0; i < this.Size; i++)
        {
            for (int j = 0; j < this.Size; j++)
            {
                resultString += $"[{this.Table[i, j]}]";
            }
            resultString += Environment.NewLine;
        }

        return resultString;
    }
}