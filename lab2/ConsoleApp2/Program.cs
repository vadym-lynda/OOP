using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter values for n and k:");
            Console.WriteLine("Enter n (n > 0):");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter k (k > 0):");
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose which sum to calculate (1, 2, or 3):");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Sum 1: " + CalculateSum1(n, k));
                    break;
                case 2:
                    Console.WriteLine("Sum 2: " + CalculateSum2(n, k));
                    break;
                case 3:
                    Console.WriteLine("Sum 3: " + CalculateSum3(n, k));
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                    break;
            }

        }

        static double CalculateSum1(int n, int k)
        {
            double sum = 0;
            for (int i = 1; i <= k; i++)
            {
                sum += Math.Pow(i, n);
            }
            return sum;
        }

        static double CalculateSum2(int n, int k)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += Math.Pow(i, k);
            }
            return sum;
        }

        static double CalculateSum3(int n, int k)
        {
            double sum = 0;
            for (int i = 1; i <= k; i++)
            {
                sum += i / Math.Pow(n, i);
            }
            return sum;
        }

    }
}
