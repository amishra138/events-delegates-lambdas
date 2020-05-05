using System;

namespace EventsDelegatesLambdas
{
    public delegate void WorkPerformedHandler(int hours, WorkType workType);
    class Program
    {
        static void Main(string[] args)
        {
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);

            DoWork(del1);

            Console.ReadKey();
        }

        static void DoWork(WorkPerformedHandler del)
        {
            del(5, WorkType.GoToMeetings);
        }

        static void WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed1 called " + hours.ToString());
        }

        static void WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed2 called " + hours.ToString());
        }

    }

    public enum WorkType
    {
        GoToMeetings,
        GenerateReports,
        Golf
    }
}
