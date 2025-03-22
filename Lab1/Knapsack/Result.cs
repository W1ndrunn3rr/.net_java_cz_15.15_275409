namespace Lab1;

// Klasa Result - pomocnicza klasa (jej obiekt zwracany jest w klasie Problem), służąca 
// jako obiekt rozwiązania problemu plecakowego
public class Result
{
    private List<int> _backpack = new List<int>();
    private int _sumValue;
    private int _sumWeight;

    // Gettery i settery do zmiennych prywatnych sumy wag i wartosci oraz listy symbolizującej
    // plecak
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

    // Przeciazona metoda ToString w celu przedstawienia wynikow rozwiazania 
    // problemu plecakowego
    public new string ToString()
    {
        string returnString = "Przedmioty: ";

        foreach (int i in _backpack)
        {
            returnString += i + " ";
        }
        
        return returnString + $"\r\nCałkowita wartość: {_sumValue}\r\nWaga całkowita: {_sumWeight}";
    }
    
    
}