using SimpleClassLibrary;
using System;
using System.Collections.Generic;

namespace EntrantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var workload = new TeachersWorkload();

            workload.InputSemesterDuration();

            workload.DisplaySemesterDuration();
        }
    }

}
