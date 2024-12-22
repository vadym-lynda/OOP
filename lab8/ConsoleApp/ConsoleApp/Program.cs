using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Work with Man, Student, Worker");
            Console.WriteLine("2. Work with Fraction");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                var man = new Man("John", 30, 75, "Male");
                var student = new Student("Alice", 20, 50, "Female", 2);
                var worker = new Worker("Bob", 40, 80, "Male", "Engineer");

                man.ShowInfo();
                student.ShowInfo();
                worker.ShowInfo();

                student.ChangeCourse(3);
                worker.ChangePosition("Manager");

                Console.WriteLine("\nAfter changes:");
                student.ShowInfo();
                worker.ShowInfo();
            }
            else if (choice == 2)
            {
                var fraction1 = new Fraction(2, 3);
                var fraction2 = new Fraction(3, 4);

                Console.WriteLine($"Fraction1: {fraction1}");
                Console.WriteLine($"Fraction2: {fraction2}");
                Console.WriteLine($"Addition: {fraction1 + fraction2}");
                Console.WriteLine($"Subtraction: {fraction1 - fraction2}");
                Console.WriteLine($"Multiplication: {fraction1 * fraction2}");
                Console.WriteLine($"Division: {fraction1 / fraction2}");
                Console.WriteLine($"Fraction1 > Fraction2: {fraction1 > fraction2}");
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }
    }

    public class Man
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }

        public Man() { }

        public Man(string name, int age, double weight, string gender)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Gender = gender;
        }

        public Man(Man other)
        {
            Name = other.Name;
            Age = other.Age;
            Weight = other.Weight;
            Gender = other.Gender;
        }

        public void ChangeAge(int newAge) => Age = newAge;
        public void ChangeWeight(double newWeight) => Weight = newWeight;

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Weight: {Weight}, Gender: {Gender}");
        }
    }

    public class Student : Man
    {
        public int Course { get; set; }

        public Student() { }

        public Student(string name, int age, double weight, string gender, int course)
            : base(name, age, weight, gender)
        {
            Course = course;
        }

        public Student(Student other) : base(other)
        {
            Course = other.Course;
        }

        public void ChangeCourse(int newCourse) => Course = newCourse;

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Course: {Course}");
        }
    }

    public class Worker : Man
    {
        public string Position { get; set; }

        public Worker() { }

        public Worker(string name, int age, double weight, string gender, string position)
            : base(name, age, weight, gender)
        {
            Position = position;
        }

        public Worker(Worker other) : base(other)
        {
            Position = other.Position;
        }

        public void ChangePosition(string newPosition) => Position = newPosition;

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Position: {Position}");
        }
    }

    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0) throw new ArgumentException("Denominator cannot be zero.");
            Numerator = numerator;
            Denominator = denominator;
            Reduce();
        }

        public Fraction(Fraction other)
        {
            Numerator = other.Numerator;
            Denominator = other.Denominator;
        }

        public static Fraction operator +(Fraction a, Fraction b) => new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        public static Fraction operator -(Fraction a, Fraction b) => new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        public static Fraction operator /(Fraction a, Fraction b) => new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);

        public static bool operator >(Fraction a, Fraction b) => a.ToDouble() > b.ToDouble();
        public static bool operator <(Fraction a, Fraction b) => a.ToDouble() < b.ToDouble();
        public static bool operator >=(Fraction a, Fraction b) => a.ToDouble() >= b.ToDouble();
        public static bool operator <=(Fraction a, Fraction b) => a.ToDouble() <= b.ToDouble();
        public static bool operator ==(Fraction a, Fraction b) => a.ToDouble() == b.ToDouble();
        public static bool operator !=(Fraction a, Fraction b) => !(a == b);

        public double ToDouble() => (double)Numerator / Denominator;

        public override string ToString() => $"{Numerator}/{Denominator}";

        private void Reduce()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        private int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);

        public override bool Equals(object obj)
        {
            if (obj is Fraction fraction)
            {
                return Numerator == fraction.Numerator && Denominator == fraction.Denominator;
            }
            return false;
        }
    }
}
