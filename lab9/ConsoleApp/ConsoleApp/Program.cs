using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    interface ITaxCalculator
    {
        double CalculateTax();
    }

    class LandTax : ITaxCalculator
    {
        public double Area { get; set; }
        public double TaxRate { get; set; }

        public LandTax(double area, double taxRate)
        {
            Area = area;
            TaxRate = taxRate;
        }

        public double CalculateTax()
        {
            return Area * TaxRate;
        }
    }

    class CarTax : ITaxCalculator
    {
        public double CarValue { get; set; }
        public double TaxRate { get; set; }

        public CarTax(double carValue, double taxRate)
        {
            CarValue = carValue;
            TaxRate = taxRate;
        }

        public double CalculateTax()
        {
            return CarValue * TaxRate;
        }
    }

    class IncomeTax : ITaxCalculator
    {
        public double Income { get; set; }
        public double TaxRate { get; set; }

        public IncomeTax(double income, double taxRate)
        {
            Income = income;
            TaxRate = taxRate;
        }

        public double CalculateTax()
        {
            return Income * TaxRate;
        }
    }

    class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }

        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public int CompareTo(Product other)
        {
            if (other == null) return 1;
            return this.Weight.CompareTo(other.Weight);
        }
    }

    class PriceComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x == null || y == null) return 0;
            return x.Price.CompareTo(y.Price);
        }
    }

    class QualityComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x == null || y == null) return 0;
            double xQuality = x.Weight / x.Price;
            double yQuality = y.Weight / y.Price;
            return xQuality.CompareTo(yQuality);
        }
    }

    class ProductCollection : IEnumerable<Product>
    {
        private List<Product> products;

        public ProductCollection(List<Product> products)
        {
            this.products = products;
        }

        public IEnumerator<Product> GetEnumerator()
        {
            foreach (var product in products)
            {
                yield return product;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Розрахунок податків");
                Console.WriteLine("2. Сортування виробів за вагою");
                Console.WriteLine("3. Сортування виробів за ціною");
                Console.WriteLine("4. Сортування виробів за якістю");
                Console.WriteLine("5. Вийти");
                Console.Write("Виберіть опцію: ");
                var option = Console.ReadLine();

                if (option == "1")
                {
                    TaxMenu();
                }
                else if (option == "2")
                {
                    SortProductsByWeight();
                }
                else if (option == "3")
                {
                    SortProductsByPrice();
                }
                else if (option == "4")
                {
                    SortProductsByQuality();
                }
                else if (option == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    Console.ReadKey();
                }
            }
        }

        static void TaxMenu()
        {
            Console.Clear();
            Console.WriteLine("Меню податків:");
            Console.WriteLine("1. Податок на землю");
            Console.WriteLine("2. Податок на автомобіль");
            Console.WriteLine("3. Податок на доходи");
            Console.WriteLine("4. Назад");
            Console.Write("Виберіть опцію: ");
            var option = Console.ReadLine();

            if (option == "1")
            {
                Console.Write("Введіть площу землі: ");
                double area = double.Parse(Console.ReadLine());
                Console.Write("Введіть ставку податку: ");
                double taxRate = double.Parse(Console.ReadLine());
                ITaxCalculator landTax = new LandTax(area, taxRate);
                Console.WriteLine($"Податок на землю: {landTax.CalculateTax()}");
            }
            else if (option == "2")
            {
                Console.Write("Введіть вартість автомобіля: ");
                double carValue = double.Parse(Console.ReadLine());
                Console.Write("Введіть ставку податку: ");
                double taxRate = double.Parse(Console.ReadLine());
                ITaxCalculator carTax = new CarTax(carValue, taxRate);
                Console.WriteLine($"Податок на автомобіль: {carTax.CalculateTax()}");
            }
            else if (option == "3")
            {
                Console.Write("Введіть доходи: ");
                double income = double.Parse(Console.ReadLine());
                Console.Write("Введіть ставку податку: ");
                double taxRate = double.Parse(Console.ReadLine());
                ITaxCalculator incomeTax = new IncomeTax(income, taxRate);
                Console.WriteLine($"Податок на доходи: {incomeTax.CalculateTax()}");
            }
            else if (option == "4")
            {
                return;
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
                Console.ReadKey();
            }

            Console.WriteLine("Натисніть будь-яку клавішу для повернення.");
            Console.ReadKey();
        }

        static void SortProductsByWeight()
        {
            Product[] products = new Product[]
            {
                new Product("Product1", 100, 2.5),
                new Product("Product2", 150, 1.2),
                new Product("Product3", 50, 3.0)
            };

            Array.Sort(products);
            Console.Clear();
            Console.WriteLine("Вироби, відсортовані за вагою:");
            foreach (var product in products)
            {
                Console.WriteLine($"Назва: {product.Name}, Ціна: {product.Price}, Вага: {product.Weight}");
            }

            Console.WriteLine("Натисніть будь-яку клавішу для повернення.");
            Console.ReadKey();
        }

        static void SortProductsByPrice()
        {
            Product[] products = new Product[]
            {
                new Product("Product1", 100, 2.5),
                new Product("Product2", 150, 1.2),
                new Product("Product3", 50, 3.0)
            };

            Array.Sort(products, new PriceComparer());
            Console.Clear();
            Console.WriteLine("Вироби, відсортовані за ціною:");
            foreach (var product in products)
            {
                Console.WriteLine($"Назва: {product.Name}, Ціна: {product.Price}, Індекс якості: {product.Weight / product.Price}");
            }

            Console.WriteLine("Натисніть будь-яку клавішу для повернення.");
            Console.ReadKey();
        }

        static void SortProductsByQuality()
        {
            Product[] products = new Product[]
            {
                new Product("Product1", 100, 2.5),
                new Product("Product2", 150, 1.2),
                new Product("Product3", 50, 3.0)
            };

            Array.Sort(products, new QualityComparer());
            Console.Clear();
            Console.WriteLine("Вироби, відсортовані за якістю:");
            foreach (var product in products)
            {
                Console.WriteLine($"Назва: {product.Name}, Ціна: {product.Price}, Індекс якості: {product.Weight / product.Price}");
            }

            Console.WriteLine("Натисніть будь-яку клавішу для повернення.");
            Console.ReadKey();
        }
    }
}
