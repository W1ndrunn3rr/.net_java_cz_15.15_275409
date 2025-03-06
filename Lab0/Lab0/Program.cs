namespace Lab0;

class FizzBuzz
{
    private readonly int _userNumber;
    private string _output = "";
    public FizzBuzz(int userNumber ) => _userNumber = userNumber;

    public void Display()
    {
        for (int i = 1; i < _userNumber; i++)
        {
            _output = i % 3 == 0 && i % 5 == 0 ? "FizzBuzz" :
                i % 3 == 0 ? "Fizz" :
                i % 5 == 0 ? "Buzz" :
                i % 3 == 0 ? "FizzBuzz" : i.ToString();
            Console.WriteLine(_output);
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Podaj liczbę do FizzBuzz: ");
        FizzBuzz fb = new FizzBuzz(int.Parse(Console.ReadLine()!));
        fb.Display();
    }
}