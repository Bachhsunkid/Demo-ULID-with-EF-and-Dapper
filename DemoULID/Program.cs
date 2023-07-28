using System.Diagnostics;

class Program
{
    static void Main()
    {
        //int numberOfComparisons = 1000000;

        //// Method 1: Using Equals method
        //long elapsedTicksEquals = MeasureComparisonWithEquals(numberOfComparisons);

        //// Method 2: Using CompareTo method
        //long elapsedTicksCompareTo = MeasureComparisonWithCompareTo(numberOfComparisons);

        //// Method 3: Using == operator
        //long elapsedTicksOperator = MeasureComparisonWithOperator(numberOfComparisons);

        //// Convert elapsed times to nanoseconds (1 tick = 100 nanoseconds on most systems)
        //double elapsedNsEquals = elapsedTicksEquals * 100;
        //double elapsedNsCompareTo = elapsedTicksCompareTo * 100;
        //double elapsedNsOperator = elapsedTicksOperator * 100;

        //Console.WriteLine($"Elapsed time using Equals: {elapsedNsEquals / 1000000} ns");
        //Console.WriteLine($"Elapsed time using CompareTo: {elapsedNsCompareTo / 1000000} ns");
        //Console.WriteLine($"Elapsed time using == operator: {elapsedNsOperator / 1000000} ns");

        var ulid1 = Ulid.NewUlid();
        var guid1 = ulid1.ToGuid();

        Console.WriteLine(ulid1);
        Console.WriteLine(guid1);

        var ulid2 = new Ulid(guid1);
        Console.WriteLine(ulid2);

    }

    public static Ulid GUIDToULID(Guid guid)
    {
        // Step 1: Convert GUID to byte array
        byte[] bytes = guid.ToByteArray();

        // Step 2: Reverse the byte array
        Array.Reverse(bytes);

        // Step 3: Convert byte array to base32 representation
        var ulid = Ulid.Parse(Base32Encode(bytes));

        return ulid;
    }

    private static string Base32Encode(byte[] input)
    {
        const string base32Chars = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";
        const int byteSize = 8;
        const int bitSize = 5;

        int bitCount = input.Length * byteSize;
        int resSize = (bitCount + bitSize - 1) / bitSize;
        char[] output = new char[resSize];

        int outputPos = 0;
        int buffer = 0;
        int bufferBits = 0;

        for (int i = 0; i < input.Length; i++)
        {
            buffer = (buffer << byteSize) | input[i];
            bufferBits += byteSize;

            while (bufferBits >= bitSize)
            {
                output[outputPos++] = base32Chars[(buffer >> (bufferBits - bitSize)) & 31];
                bufferBits -= bitSize;
                buffer &= (1 << bufferBits) - 1;
            }
        }

        if (bufferBits > 0)
        {
            output[outputPos++] = base32Chars[(buffer << (bitSize - bufferBits)) & 31];
        }

        return new string(output, 0, outputPos);
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