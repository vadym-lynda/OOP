using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of array elements (n): ");
        int size;
        while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
        {
            Console.WriteLine("Please enter a valid positive integer!");
        }

        Random rnd = new Random();
        double[] numbers = new double[size];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = Math.Round(rnd.NextDouble() * (110.35 + 110.34) - 110.34, 2);
        }

        Console.WriteLine("\nInitial array:");
        PrintArray(numbers);

        double negativeSum = 0;
        for (int i = 0; i < numbers.Length; i += 2)
        {
            if (numbers[i] < 0)
                negativeSum += numbers[i];
        }
        Console.WriteLine($"\nSum of negative elements with even indices: {negativeSum}");

        double[] oddIndexedElements = numbers
            .Where((_, index) => index % 2 != 0)
            .OrderByDescending(x => x)
            .ToArray();

        int oddIndexCounter = 0;
        for (int i = 1; i < numbers.Length; i += 2)
        {
            numbers[i] = oddIndexedElements[oddIndexCounter++];
        }

        Console.WriteLine("\nArray after sorting elements with odd indices in descending order:");
        PrintArray(numbers);
    }

    static void PrintArray(double[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }
}
