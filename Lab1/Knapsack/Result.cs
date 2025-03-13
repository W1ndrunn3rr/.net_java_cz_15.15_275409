namespace Lab1;

public class Result
{
    private List<int> _backpack = new List<int>();
    private int _sumValue;
    private int _sumWeight;

    public int SumValue
    {
        get => _sumValue;
        set => _sumValue = value;
    }
    
    public int SumWeight
    {
        get => _sumWeight;
        set => _sumWeight = value;
    }

    public List<int> Backpack
    {
        get => _backpack;
        set => _backpack = value ?? throw new ArgumentNullException(nameof(value));
    }

    public new string ToString()
    {
        string returnString = "Items: ";

        foreach (int i in _backpack)
        {
            returnString += i + " ";
        }
        
        return returnString + $"\nTotal value: {_sumValue}\nTotal weight: {_sumWeight}";
    }
    
    
}