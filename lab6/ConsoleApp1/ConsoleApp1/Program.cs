using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TeachersWorkload[] workloads = null;
            ShowMenu(ref workloads);
        }

        static void ShowMenu(ref TeachersWorkload[] workloads)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create workloads");
                Console.WriteLine("2. Show a specific workload");
                Console.WriteLine("3. Show all workloads");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        workloads = CreateWorkloads();
                        break;
                    case 2:
                        if (workloads == null)
                        {
                            Console.WriteLine("No workloads created yet.");
                        }
                        else
                        {
                            ShowSpecificWorkload(workloads);
                        }
                        break;
                    case 3:
                        if (workloads == null)
                        {
                            Console.WriteLine("No workloads created yet.");
                        }
                        else
                        {
                            ShowAllWorkloads(workloads);
                        }
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static TeachersWorkload[] CreateWorkloads()
        {
            Console.Write("Enter the number of workloads: ");
            int n = int.Parse(Console.ReadLine());
            TeachersWorkload[] workloads = new TeachersWorkload[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Workload {i + 1}:");
                Console.Write("Subject Name: ");
                string subjectName = Console.ReadLine();
                Console.Write("Semester: ");
                int semester = int.Parse(Console.ReadLine());
                Console.Write("Students Count: ");
                int studentsCount = int.Parse(Console.ReadLine());

                Console.WriteLine("Semester Control Info:");
                Console.Write("Control Form: ");
                string controlForm = Console.ReadLine();
                Console.Write("Scale: ");
                string scale = Console.ReadLine();
                Console.Write("Examination Date (yyyy-MM-dd): ");
                DateTime examinationDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Results Filling Date (yyyy-MM-dd): ");
                DateTime resultsFillingDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Hours per Student: ");
                double hours = double.Parse(Console.ReadLine());

                SemesterControlInfo controlInfo = new SemesterControlInfo(controlForm, scale, examinationDate, resultsFillingDate, hours);
                workloads[i] = new TeachersWorkload(subjectName, semester, studentsCount, controlInfo);
            }

            Console.WriteLine("Workloads created successfully!");
            return workloads;
        }

        static void ShowSpecificWorkload(TeachersWorkload[] workloads)
        {
            Console.Write("Enter the index of the workload (1-based): ");
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < workloads.Length)
            {
                Console.WriteLine(workloads[index]);
            }
            else
            {
                Console.WriteLine("Invalid index!");
            }
        }

        static void ShowAllWorkloads(TeachersWorkload[] workloads)
        {
            foreach (var workload in workloads)
            {
                Console.WriteLine(workload);
            }
        }
    }

    class SemesterControlInfo
    {
        private string controlForm;
        private string scale;
        private DateTime examinationDate;
        private DateTime resultsFillingDate;
        private double hours;

        public string ControlForm
        {
            get { return controlForm; }
            set { controlForm = value; }
        }

        public string Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public DateTime ExaminationDate
        {
            get { return examinationDate; }
            set { examinationDate = value; }
        }

        public DateTime ResultsFillingDate
        {
            get { return resultsFillingDate; }
            set { resultsFillingDate = value; }
        }

        public double Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        public SemesterControlInfo()
        {
            controlForm = "Exam";
            scale = "5-point";
            examinationDate = DateTime.MinValue;
            resultsFillingDate = DateTime.MinValue;
            hours = 1.0;
        }

        public SemesterControlInfo(string controlForm, string scale, DateTime examinationDate, DateTime resultsFillingDate, double hours)
        {
            this.controlForm = controlForm;
            this.scale = scale;
            this.examinationDate = examinationDate;
            this.resultsFillingDate = resultsFillingDate;
            this.hours = hours;
        }

        public SemesterControlInfo(SemesterControlInfo other)
        {
            controlForm = other.controlForm;
            scale = other.scale;
            examinationDate = other.examinationDate;
            resultsFillingDate = other.resultsFillingDate;
            hours = other.hours;
        }

        public double GetTotalTime(int studentsCount)
        {
            return studentsCount * hours;
        }

        public bool IsHappeningToday()
        {
            return examinationDate.Date == resultsFillingDate.Date;
        }

        public override string ToString()
        {
            return $"ControlForm: {controlForm}, Scale: {scale}, ExaminationDate: {examinationDate}, ResultsFillingDate: {resultsFillingDate}, Hours: {hours}";
        }
    }

    class TeachersWorkload
    {
        private string subjectName;
        private int semester;
        private int studentsCount;
        private SemesterControlInfo semesterControl;

        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }

        public int Semester
        {
            get { return semester; }
            set { semester = value; }
        }

        public int StudentsCount
        {
            get { return studentsCount; }
            set { studentsCount = value; }
        }

        public SemesterControlInfo SemesterControl
        {
            get { return semesterControl; }
            set { semesterControl = value; }
        }

        public TeachersWorkload()
        {
            subjectName = "Undefined";
            semester = 1;
            studentsCount = 0;
            semesterControl = new SemesterControlInfo();
        }

        public TeachersWorkload(string subjectName, int semester, int studentsCount, SemesterControlInfo semesterControl)
        {
            this.subjectName = subjectName;
            this.semester = semester;
            this.studentsCount = studentsCount;
            this.semesterControl = semesterControl;
        }

        public TeachersWorkload(TeachersWorkload other)
        {
            subjectName = other.subjectName;
            semester = other.semester;
            studentsCount = other.studentsCount;
            semesterControl = new SemesterControlInfo(other.semesterControl);
        }

        public override string ToString()
        {
            return $"Subject: {subjectName}, Semester: {semester}, StudentsCount: {studentsCount}, SemesterControl: {semesterControl}";
        }
    }
}
