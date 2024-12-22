using System;

namespace ConsoleApp1
{
    struct Triangle
    {
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }
        public double AngleAB { get; private set; }

        public Triangle(double sideA, double sideB, double angleAB)
        {
            try
            {
                if (sideA <= 0 || sideB <= 0 || angleAB <= 0 || angleAB >= 180)
                    throw new ArgumentException("Sides and angle must be positive and satisfy triangle conditions.");

                SideA = sideA;
                SideB = sideB;
                AngleAB = angleAB;

                double angleRadians = Math.PI * angleAB / 180.0;
                SideC = Math.Sqrt(SideA * SideA + SideB * SideB - 2 * SideA * SideB * Math.Cos(angleRadians));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while initializing triangle: {ex.Message}");
                throw;
            }
        }

        public double CalculateArea()
        {
            try
            {
                double angleRadians = Math.PI * AngleAB / 180.0;
                return 0.5 * SideA * SideB * Math.Sin(angleRadians);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating area: {ex.Message}");
                return 0;
            }
        }

        public double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }

        public string DetermineType()
        {
            if (SideA == SideB && SideB == SideC)
                return "Equilateral";
            if (SideA == SideB || SideB == SideC || SideA == SideC)
                return "Isosceles";
            if (Math.Abs(SideA * SideA + SideB * SideB - SideC * SideC) < 1e-5 ||
                Math.Abs(SideB * SideB + SideC * SideC - SideA * SideA) < 1e-5 ||
                Math.Abs(SideA * SideA + SideC * SideC - SideB * SideB) < 1e-5)
                return "Right-angled";
            return "Scalene";
        }

        public override string ToString()
        {
            return $"Sides: A={SideA}, B={SideB}, C={SideC}, Angle between A and B={AngleAB}°";
        }
    }

    internal class Program
    {
        public static Triangle[] ReadTriangles(int count)
        {
            Triangle[] triangles = new Triangle[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Enter data for triangle {i + 1}:");
                Console.Write("Side A: ");
                double sideA = double.Parse(Console.ReadLine());
                Console.Write("Side B: ");
                double sideB = double.Parse(Console.ReadLine());
                Console.Write("Angle between A and B: ");
                double angleAB = double.Parse(Console.ReadLine());
                triangles[i] = new Triangle(sideA, sideB, angleAB);
            }
            return triangles;
        }

        public static void PrintTriangle(Triangle triangle)
        {
            Console.WriteLine(triangle.ToString());
        }

        public static void SortTriangles(Triangle[] triangles)
        {
            Array.Sort(triangles, (t1, t2) => t1.CalculateArea().CompareTo(t2.CalculateArea()));
        }

        public static void ModifyTriangle(ref Triangle triangle, double newSideA, double newSideB, double newAngleAB)
        {
            triangle = new Triangle(newSideA, newSideB, newAngleAB);
        }

        public static void FindMinMaxArea(Triangle[] triangles, out double minArea, out double maxArea)
        {
            minArea = double.MaxValue;
            maxArea = double.MinValue;
            foreach (var triangle in triangles)
            {
                double area = triangle.CalculateArea();
                if (area < minArea)
                    minArea = area;
                if (area > maxArea)
                    maxArea = area;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the number of triangles: ");
            int count = int.Parse(Console.ReadLine());
            Triangle[] triangles = ReadTriangles(count);

            Console.WriteLine("\nEntered triangles:");
            foreach (var triangle in triangles)
            {
                PrintTriangle(triangle);
            }

            SortTriangles(triangles);
            Console.WriteLine("\nTriangles after sorting by area:");
            foreach (var triangle in triangles)
            {
                PrintTriangle(triangle);
            }

            FindMinMaxArea(triangles, out double minArea, out double maxArea);
            Console.WriteLine($"\nMinimum area: {minArea}, Maximum area: {maxArea}");
        }
    }
}
