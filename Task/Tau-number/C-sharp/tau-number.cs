internal class Program
{
    private static void Main(string[] args)
    {
        long limit = 100;
        Console.WriteLine($"The first {limit} tau numbers are:");
        long count = 0;

        for (long n = 1; count < limit; ++n)
        {
            if (IsTauNumber(n))
            {
                Console.Write($"{n, 6} ");
                ++count;

                if (count % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }

    private static bool IsTauNumber(long n)
    {
        return n % DivisorCount(n) == 0;
    }

    private static long DivisorCount(long n)
    {
        long total = 1;
        // Deal with powers of 2 first
        for (; (n & 1) == 0; n >>= 1)
        {
            ++total;
        }

        // Odd prime factors up to the square root
        for (long p = 3; p * p <= n; p += 2)
        {
            long count = 1;

            for (; n % p == 0; n /= p)
            {
                ++count;
            }

            total *= count;
        }

        // If n > 1 then it's prime
        if (n > 1)
        {
            total *= 2;
        }

        return total;
    }
}
