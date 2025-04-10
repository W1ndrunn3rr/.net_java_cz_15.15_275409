using System.Diagnostics;
using MatrixCalculation;

namespace ConsoleView;

public static class FunctionDecorators
{
    public static Action Decorate(Action action, Action<Action> decorator)
    {
        return () => decorator(action);
    }
}

class Program
{
    public static void TimeMeasureDecorator(Action action)
    {
        const int RANGE = 5;
        List<long> watches = new List<long>();
        for (int i = 0; i < RANGE; i++)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            action();
            sw.Stop();
            watches.Add(sw.ElapsedMilliseconds);
        }
        Console.Write($"Time : {watches.Aggregate((a,b) => a+b)/RANGE} [ms]\n");
    }

    public static void Run(Func<int, Matrix, Matrix, Matrix> func)
    {
        int[] threads = { 1, 4, 8 };
        int[] sizes = { 500,1000,2000 };
        foreach (int thread in threads)
        {
            foreach (int size in sizes)
            {
                bool checkIn = false;
                Action pararell = () =>
                {
                    if(!checkIn)
                        Console.Write($"Thread: {thread}, Size: {size}, ");
                    Matrix m1 = new Matrix(size);
                    Matrix m2 = new Matrix(size);
                    Matrix m3 = func(thread, m1, m2);
                    checkIn = true;
                };
                Action decorated = FunctionDecorators.Decorate(pararell, TimeMeasureDecorator);
                decorated();
            }
        }
    }

    
    static void Main(string[] args)
    {
        Console.WriteLine("========================================\nPARARELL\n========================================\n");
            Run(MatrixCalculations.PararellMultiplyMatrixes);   
            
            Console.WriteLine("\n========================================\nTHREADS\n========================================\n");
            Run(MatrixCalculations.ThreadMultiplyMatrixes);
        
        
        
            //Console.WriteLine($"Macierz m1: \n{m1.ToString()}\nMacierz m2: \n{m2.ToString()}");
            
           
        
            
            //Console.WriteLine($"Macierz wynikowa: \n{m3.ToString()}");

            //Console.WriteLine("Czas wykonania={0}", sw.Elapsed);
        // } 
    }
}