namespace Lab1;

class Program
{
    static void Main()
    {
        string userInput;
        int seed, maxN, capacity;
        
        Random rng = new Random();

        try
        {
            Console.WriteLine("Pass RNG seed: ");
            userInput = Console.ReadLine()!;
            seed = userInput.Length == 0 ? rng.Next(0, Int32.MaxValue) : int.Parse(userInput);

            Console.WriteLine("Pass items in backpack: ");
            maxN = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Pass backpack capacity: ");
            userInput = Console.ReadLine()!;
            capacity = userInput.Length == 0 ? rng.Next(0, Int32.MaxValue) : int.Parse(userInput);
      
        Console.WriteLine($"-------------------------\nINFO\nCapacity : {capacity}\nSeed: {seed}\nMax N : {maxN}\n-------------------------\n");
        
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

