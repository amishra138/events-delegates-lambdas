using System;

namespace EventsDelegatesLambdas
{
    public class ReturnValuesFromDelegate
    {
        public delegate int WorkPerformedHandler(int hours, WorkType workType);
        public static void Call()
        {
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);

            del1 += del2;

            var finalResult = DoWork(del1);

            Console.WriteLine("Final Result - " + finalResult.ToString());
        }

        static int DoWork(WorkPerformedHandler del)
        {
            return del(5, WorkType.GoToMeetings);
        }

        static int WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed1 called " + hours.ToString());

            return hours + 1;
        }

        static int WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed2 called " + hours.ToString());

            return hours + 2;
        }
    }
}
