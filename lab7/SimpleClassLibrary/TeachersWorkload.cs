using System;

namespace SimpleClassLibrary
{
    public class TeachersWorkload
    {
        public int SemesterDurationWeeks { get; private set; }
        public int SemesterDurationHours { get; private set; }
        public int SemesterDurationLessons { get; private set; }

        private const double HoursPerLesson = 1.5;
        private const int LessonsPerWeek = 4;

        public void InputSemesterDuration()
        {
            Console.WriteLine("Оберіть одиниці вимірювання для введення тривалості семестру:");
            Console.WriteLine("1. Тижні");
            Console.WriteLine("2. Академічні години");
            Console.WriteLine("3. Аудиторні заняття");
            Console.Write("Ваш вибір: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введіть тривалість семестру в тижнях: ");
                    SemesterDurationWeeks = int.Parse(Console.ReadLine());
                    SemesterDurationLessons = SemesterDurationWeeks * LessonsPerWeek;
                    SemesterDurationHours = (int)(SemesterDurationLessons * HoursPerLesson);
                    break;

                case 2:
                    Console.Write("Введіть тривалість семестру в академічних годинах: ");
                    SemesterDurationHours = int.Parse(Console.ReadLine());
                    SemesterDurationLessons = (int)(SemesterDurationHours / HoursPerLesson);
                    SemesterDurationWeeks = SemesterDurationLessons / LessonsPerWeek;
                    break;

                case 3:
                    Console.Write("Введіть тривалість семестру в аудиторних заняттях: ");
                    SemesterDurationLessons = int.Parse(Console.ReadLine());
                    SemesterDurationHours = (int)(SemesterDurationLessons * HoursPerLesson);
                    SemesterDurationWeeks = SemesterDurationLessons / LessonsPerWeek;
                    break;

                default:
                    Console.WriteLine("Некоректний вибір.");
                    break;
            }
        }

        public void DisplaySemesterDuration()
        {
            Console.WriteLine("\nТривалість семестру:");
            Console.WriteLine($"У тижнях: {SemesterDurationWeeks}");
            Console.WriteLine($"В академічних годинах: {SemesterDurationHours}");
            Console.WriteLine($"В аудиторних заняттях: {SemesterDurationLessons}");
        }
    }
}
