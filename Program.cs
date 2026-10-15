using System.Diagnostics;
class Program
{
    static long FibonacciMemo(
        int n, Dictionary<int, long> memo)
    {
        if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));
        if (n <= 1) return n;
        if (memo.TryGetValue(n, out long value)) return value;
        long result = FibonacciMemo(n - 1, memo) + FibonacciMemo(n - 2, memo);
        memo[n] = result;
        return result;
    }
    static long FibonacciIterative(int n)
    {
        if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));
        if (n <= 1) return n;
        long previous = 0;
        long current = 1;
        for (int i = 2; i <= n; i++)
        {
            long next = previous + current;
            previous = current;
            current = next;
        }
        return current;
    }
    static void Main()
    {
        int n = 40;
        Stopwatch sw = Stopwatch.StartNew();
        long memoResult = FibonacciMemo(n, new Dictionary<int, long>());
        sw.Stop();
        TimeSpan memoTime = sw.Elapsed;
        sw.Restart();
        long iterativeResult = FibonacciIterative(n);
        sw.Stop();
        Console.WriteLine($"Fibonacci({n}) = {memoResult}");
        Console.WriteLine($"Memoization: {memoTime.TotalMilliseconds:F4} ms");
        Console.WriteLine($"Iterative: {sw.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine($"Results equal: {memoResult == iterativeResult}");
    }
}