using System;

namespace EventsDelegatesLambdas
{

    class Program
    {
        static void Main(string[] args)
        {
            //SimpleDelegate.Call();

            //MultiCastDelegates.Call();

            //ReturnValuesFromDelegate.Call();

            #region Events
            //var worker = new WorkerWithAdvance();
            //worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(worker.Worker_WorkPerformed);
            //worker.WorkCompleted += new EventHandler(worker.Worker_WorkCompleted);
            //worker.DoWork(2, WorkType.GenerateReports); 
            #endregion

            #region Delegate Inference
            //var worker = new WorkerWithAdvance();
            //worker.WorkPerformed += worker.Worker_WorkPerformed;
            //worker.WorkCompleted += worker.Worker_WorkCompleted;

            //worker.WorkCompleted -= worker.Worker_WorkCompleted;
            //worker.DoWork(2, WorkType.GenerateReports); 
            #endregion

            #region Anonymous method
            //var worker = new WorkerWithAdvance();
            //worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            //{
            //    Console.WriteLine(e.Hours.ToString());
            //};
            //worker.DoWork(2, WorkType.GenerateReports); 
            #endregion

            #region Lambda function
            //var worker = new WorkerWithAdvance();
            //worker.WorkPerformed += (sender, e) => Console.WriteLine(e.Hours.ToString());

            //worker.DoWork(2, WorkType.GenerateReports); 
            #endregion

            #region Different use of delegate
            //var processData = new ProcessData();
            //BizRuleDelegate add = (x, y) => x + y;
            //BizRuleDelegate multiply = (x, y) => x * y;

            //processData.Process(2, 3, add);

            //processData.Process(2, 3, multiply); 
            #endregion

            #region Action Example
            //var processData = new ProcessData();
            //Action<int, int> addAction = (x, y) => Console.WriteLine(x + y); ;
            //Action<int, int> multiplyAction = (x, y) => Console.WriteLine(x * y);

            //processData.ProcessAction(2, 3, addAction);
            //processData.ProcessAction(2, 3, multiplyAction);
            #endregion

            #region Func Delegate Use
            var processData = new ProcessData();
            Func<int, int, int> addFunc = (x, y) => x + y;
            Func<int, int, int> multiplyFunc = (x, y) => x * y;

            processData.ProcessFunc(2, 3, addFunc);

            processData.ProcessFunc(2, 3, multiplyFunc);
            #endregion

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
