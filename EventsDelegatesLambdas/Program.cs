using System;

namespace EventsDelegatesLambdas
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            //SimpleDelegate.Call();

            // 2
            //MultiCastDelegates.Call();

            //3
            //ReturnValuesFromDelegate.Call();

            //4
            //var worker = new WorkerWithAdvance();
            //worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(worker.Worker_WorkPerformed);
            //worker.WorkCompleted += new EventHandler(worker.Worker_WorkCompleted);
            //worker.DoWork(2, WorkType.GenerateReports);

            //5 - Delegate Inference
            //var worker = new WorkerWithAdvance();
            //worker.WorkPerformed += worker.Worker_WorkPerformed;
            //worker.WorkCompleted += worker.Worker_WorkCompleted;

            //worker.WorkCompleted -= worker.Worker_WorkCompleted;
            //worker.DoWork(2, WorkType.GenerateReports);

            //6 - Anonymous method
            var worker = new WorkerWithAdvance();
            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine(e.Hours.ToString());
            };
            worker.DoWork(2, WorkType.GenerateReports);
            Console.ReadKey();
        }

    }

    public enum WorkType
    {
        GoToMeetings,
        GenerateReports,
        Golf
    }
}
