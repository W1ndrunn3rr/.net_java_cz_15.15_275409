namespace MatrixCalculation;

public class MatrixCalculations
{
    public MatrixCalculations()
    {
    }


    public static Matrix PararellMultiplyMatrixes(int threadsNum, Matrix m1, Matrix m2)
    {
        Matrix result = new Matrix(m1.Size);
        ParallelOptions opt = new ParallelOptions() { MaxDegreeOfParallelism = threadsNum };
        int[] threadsUsed = new int[Environment.ProcessorCount];

        Parallel.For(0, m1.Size, opt, i =>
        {
            for (int j = 0; j < m1.Size; j++)
            {
                int sum = 0;
                for (int k = 0; k < m1.Size; k++)
                {
                    sum += m1.Table[i, k] * m2.Table[k, j];
                }

                result.Table[i, j] = sum;
            }
        });
        return result;
    }

    public static Matrix ThreadMultiplyMatrixes(int threadsNum, Matrix m1, Matrix m2)
    {
        Matrix result = new Matrix(m1.Size);
        Mutex mutex = new Mutex();
        Thread[] threads = new Thread[threadsNum];

        for (int i = 0; i < threadsNum; i++)
        {
            int threadId = i;
            threads[i] = new Thread(() =>
            {
                for (int row = threadId; row < m1.Size; row += threadsNum)
                {
                    for (int col = 0; col < m2.Size; col++)
                    {
                        int sum = 0;
                        for (int k = 0; k < m1.Size; k++)
                        {
                            sum += m1.Table[row, k] * m2.Table[k, col];
                        }
                        mutex.WaitOne();
                        result.Table[row, col] = sum;
                        mutex.ReleaseMutex();
                    }
                }
            });
        }

        foreach ( Thread x in threads ) x.Start ();
        foreach ( Thread x in threads ) x.Join ();

        return result;
    }
}