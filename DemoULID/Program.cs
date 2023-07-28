using System.Diagnostics;

class Program
{
    static void Main()
    {
        int numberOfComparisons = 1000000;

        // Method 1: Using Equals method
        long elapsedTicksEquals = MeasureComparisonWithEquals(numberOfComparisons);

        // Method 2: Using CompareTo method
        long elapsedTicksCompareTo = MeasureComparisonWithCompareTo(numberOfComparisons);

        // Method 3: Using == operator
        long elapsedTicksOperator = MeasureComparisonWithOperator(numberOfComparisons);

        // Convert elapsed times to nanoseconds (1 tick = 100 nanoseconds on most systems)
        double elapsedNsEquals = elapsedTicksEquals * 100;
        double elapsedNsCompareTo = elapsedTicksCompareTo * 100;
        double elapsedNsOperator = elapsedTicksOperator * 100;

        Console.WriteLine($"Elapsed time using Equals: {elapsedNsEquals / 1000000} ns");
        Console.WriteLine($"Elapsed time using CompareTo: {elapsedNsCompareTo / 1000000} ns");
        Console.WriteLine($"Elapsed time using == operator: {elapsedNsOperator / 1000000} ns");
    }

    static long MeasureComparisonWithEquals(int numberOfComparisons)
    {
        Ulid guid1 = Ulid.NewUlid();
        Ulid guid2 = Ulid.NewUlid();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < numberOfComparisons; i++)
        {
            guid1.Equals(guid2);
        }

        stopwatch.Stop();
        return stopwatch.ElapsedTicks;
    }

    static long MeasureComparisonWithCompareTo(int numberOfComparisons)
    {
        Guid guid1 = Guid.NewGuid();
        Guid guid2 = Guid.NewGuid();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < numberOfComparisons; i++)
        {
            guid1.CompareTo(guid2);
        }

        stopwatch.Stop();
        return stopwatch.ElapsedTicks;
    }

    static long MeasureComparisonWithOperator(int numberOfComparisons)
    {
        Guid guid1 = Guid.NewGuid();
        Guid guid2 = Guid.NewGuid();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < numberOfComparisons; i++)
        {
            bool a = guid1 == guid2;
        }

        stopwatch.Stop();
        return stopwatch.ElapsedTicks;
    }

}