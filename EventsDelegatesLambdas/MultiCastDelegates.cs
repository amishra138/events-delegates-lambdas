using System;

namespace EventsDelegatesLambdas
{
    public class MultiCastDelegates
    {
        public delegate void WorkPerformedHandler(int hours, WorkType workType);
        public static void Call()
        {
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            //del1 += del2;
            //del1 += del3;

            //DoWork(del1);

            //Another way to do that
            del1 += del2 + del3;

            DoWork(del1);
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

        static void WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed3 called " + hours.ToString());
        }
    }
}
