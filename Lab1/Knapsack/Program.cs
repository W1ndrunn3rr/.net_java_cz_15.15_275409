namespace Lab1;

// Główna klasa programu
class Program
{
    // Glowna metoda programu
    static void Main()
    {
        string userInput;
        int seed, maxN, capacity;
        
        Random rng = new Random();

        // Try/catch do obslugi testow 
        try
        {
            // Pobranie od uzytkownika ziarna, liczby przedmitów i pojemnosci - jesli ich nie poda
            // losowana jest liczba od 0 do Int32.MaxValue (dla ziarna i pojemnosci)
            Console.WriteLine("Pass RNG seed: ");
            userInput = Console.ReadLine()!;
            seed = userInput.Length == 0 ? rng.Next(0, Int32.MaxValue) : int.Parse(userInput);

            Console.WriteLine("Pass items in backpack: ");
            maxN = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Pass backpack capacity: ");
            userInput = Console.ReadLine()!;
            capacity = userInput.Length == 0 ? rng.Next(0, Int32.MaxValue) : int.Parse(userInput);
      
        Console.WriteLine($"-------------------------\nINFO\nCapacity : {capacity}\nSeed: {seed}\nMax N : {maxN}\n-------------------------\n");
        
        // Stworzenie problemu i rozwiazanie + pomocnicze wypisanie na terminal
        seed = seed > 0 ? seed : 0;
        maxN = maxN > 0 ? maxN : Int32.MaxValue;
        Problem problem = new Problem(maxN, seed);
        Console.WriteLine(problem.ToString());
        Console.WriteLine(problem.Solve(capacity).ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}

