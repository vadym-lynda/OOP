using System;
using System.Linq;
using System.Windows;

namespace ArrayProcessingApp
{
    public partial class MainWindow : Window
    {
        private double[] numbers;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateArray_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputSize.Text, out int size) && size > 0)
            {
                Random rnd = new Random();
                numbers = new double[size];
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = Math.Round(rnd.NextDouble() * (110.35 + 110.34) - 110.34, 2);
                }
                OutputArray.Text = $"Згенерований масив: {string.Join(", ", numbers)}";
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректне додатнє число!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CalculateNegativeSum_Click(object sender, RoutedEventArgs e)
        {
            if (numbers == null || numbers.Length == 0)
            {
                MessageBox.Show("Масив не згенеровано!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double negativeSum = 0;
            for (int i = 0; i < numbers.Length; i += 2)
            {
                if (numbers[i] < 0)
                    negativeSum += numbers[i];
            }

            NegativeSumOutput.Text = $"Сума від’ємних елементів з парними індексами: {negativeSum}";
        }

        private void SortOddIndexes_Click(object sender, RoutedEventArgs e)
        {
            if (numbers == null || numbers.Length == 0)
            {
                MessageBox.Show("Масив не згенеровано!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double[] oddIndexedElements = numbers
                .Where((_, index) => index % 2 != 0)
                .OrderByDescending(x => x)
                .ToArray();

            int oddIndexCounter = 0;
            for (int i = 1; i < numbers.Length; i += 2)
            {
                numbers[i] = oddIndexedElements[oddIndexCounter++];
            }

            SortedArrayOutput.Text = $"Масив після сортування: {string.Join(", ", numbers)}";
        }
    }
}
