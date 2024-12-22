using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            ArrayList list = new ArrayList();
            Dictionary<int, TeachersWorkload> workload = new Dictionary<int, TeachersWorkload>();

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Демонстрація можливостей класу ArrayList");
                Console.WriteLine("2. Демонстрація можливостей класу Dictionary<TKey, TValue>");
                Console.WriteLine("3. Вихід");
                Console.Write("Оберіть опцію: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowArrayListMenu(list);
                        break;
                    case "2":
                        ShowDictionaryMenu(workload);
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void ShowArrayListMenu(ArrayList list)
        {
            bool listRunning = true;

            while (listRunning)
            {
                Console.Clear();
                Console.WriteLine("Меню ArrayList:");
                Console.WriteLine("1. Додати елемент");
                Console.WriteLine("2. Показати елементи");
                Console.WriteLine("3. Видалити елемент");
                Console.WriteLine("4. Пошук елемента");
                Console.WriteLine("5. Очищення колекції");
                Console.WriteLine("6. Назад");
                Console.Write("Оберіть опцію: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddToArrayList(list);
                        break;
                    case "2":
                        ShowArrayList(list);
                        break;
                    case "3":
                        RemoveFromArrayList(list);
                        break;
                    case "4":
                        SearchInArrayList(list);
                        break;
                    case "5":
                        ClearArrayList(list);
                        break;
                    case "6":
                        listRunning = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void ShowDictionaryMenu(Dictionary<int, TeachersWorkload> workload)
        {
            bool dictRunning = true;

            while (dictRunning)
            {
                Console.Clear();
                Console.WriteLine("Меню Dictionary:");
                Console.WriteLine("1. Додати елемент");
                Console.WriteLine("2. Показати елементи");
                Console.WriteLine("3. Видалити елемент");
                Console.WriteLine("4. Пошук елемента");
                Console.WriteLine("5. Очищення колекції");
                Console.WriteLine("6. Назад");
                Console.Write("Оберіть опцію: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddToDictionary(workload);
                        break;
                    case "2":
                        ShowDictionary(workload);
                        break;
                    case "3":
                        RemoveFromDictionary(workload);
                        break;
                    case "4":
                        SearchInDictionary(workload);
                        break;
                    case "5":
                        ClearDictionary(workload);
                        break;
                    case "6":
                        dictRunning = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void AddToArrayList(ArrayList list)
        {
            Console.WriteLine("Введіть елемент для додавання:");
            string input = Console.ReadLine();
            list.Add(input);
            Console.WriteLine("Елемент додано. Натисніть Enter для повернення в меню.");
            Console.ReadLine();
        }

        static void ShowArrayList(ArrayList list)
        {
            Console.WriteLine("Елементи в ArrayList:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Натисніть Enter для повернення в меню.");
            Console.ReadLine();
        }

        static void RemoveFromArrayList(ArrayList list)
        {
            Console.WriteLine("Введіть елемент для видалення:");
            string input = Console.ReadLine();
            if (list.Contains(input))
            {
                list.Remove(input);
                Console.WriteLine("Елемент видалено.");
            }
            else
            {
                Console.WriteLine("Елемент не знайдено.");
            }
            Console.WriteLine("Натисніть Enter для повернення в меню.");
            Console.ReadLine();
        }

        static void SearchInArrayList(ArrayList list)
        {
            Console.WriteLine("Введіть елемент для пошуку:");
            string input = Console.ReadLine();
            if (list.Contains(input))
            {
                Console.WriteLine("Елемент знайдено.");
            }
            else
            {
                Console.WriteLine("Елемент не знайдено.");
            }
            Console.WriteLine("Натисніть Enter для повернення в меню.");
            Console.ReadLine();
        }

        static void ClearArrayList(ArrayList list)
        {
            list.Clear();
            Console.WriteLine("ArrayList очищено.");
            Console.WriteLine("Натисніть Enter для повернення в меню.");
            Console.ReadLine();
        }

        static void AddToDictionary(Dictionary<int, TeachersWorkload> workload)
        {
            Console.WriteLine("Введіть ID для нового запису:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть ім'я викладача:");
            string name = Console.ReadLine();
            Console.WriteLine("Введіть кількість класів:");
            int classes = int.Parse(Console.ReadLine());
            workload.Add(id, new TeachersWorkload(name, classes));
            Console.WriteLine("Запис додано. Натисніть Enter для повернення в меню.");
            Console.ReadLine();
        }

        static void ShowDictionary(Dictionary<int, TeachersWorkload> workload)
        {
            Console.WriteLine("Викладачі та їх навантаження:");
            foreach (var entry in workload)
            {
                Console.WriteLine($"ID: {entry.Key}, Name: {entry.Value.TeacherName}, Classes: {entry.Value.NumberOfClasses}");
            }
            Console.WriteLine("Натисніть Enter для повернення в меню.");
            Console.ReadLine();
        }

        static void RemoveFromDictionary(Dictionary<int, TeachersWorkload> workload)
        {
            Console.WriteLine("Введіть ID для видалення:");
            int id = int.Parse(Console.ReadLine());
            if (workload.ContainsKey(id))
            {
                workload.Remove(id);
                Console.WriteLine("Запис видалено.");
            }
            else
            {
                Console.WriteLine("Запис не знайдено.");
            }
            Console.WriteLine("Натисніть Enter для повернення в меню.");
            Console.ReadLine();
        }

        static void SearchInDictionary(Dictionary<int, TeachersWorkload> workload)
        {
            Console.WriteLine("Введіть ID для пошуку:");
            int id = int.Parse(Console.ReadLine());
            if (workload.ContainsKey(id))
            {
                var teacher = workload[id];
                Console.WriteLine($"Знайдено: {teacher.TeacherName}, Кількість класів: {teacher.NumberOfClasses}");
            }
            else
            {
                Console.WriteLine("Запис не знайдено.");
            }
            Console.WriteLine("Натисніть Enter для повернення в меню.");
            Console.ReadLine();
        }

        static void ClearDictionary(Dictionary<int, TeachersWorkload> workload)
        {
            workload.Clear();
            Console.WriteLine("Dictionary очищено.");
            Console.WriteLine("Натисніть Enter для повернення в меню.");
            Console.ReadLine();
        }
    }

    class TeachersWorkload
    {
        public string TeacherName { get; set; }
        public int NumberOfClasses { get; set; }

        public TeachersWorkload(string teacherName, int numberOfClasses)
        {
            TeacherName = teacherName;
            NumberOfClasses = numberOfClasses;
        }
    }
}
