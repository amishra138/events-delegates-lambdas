using System;

namespace EventsDelegatesLambdas
{
    public class WorkerWithAdvance
    {
        //public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

        //Two custom events
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
        }

        /// <summary>
        /// It provides access to anyone who may be subclasses to override 
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="workType"></param>
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //One way

            //WorkPerformedHandler del = WorkPerformed as WorkPerformedHandler;
            //if (del != null) //Make sure listener are attached
            //{
            //    del(hours, workType); //Raise event
            //}

            //another way

            if (WorkPerformed != null)
            {
                WorkPerformed(this, new WorkPerformedEventArgs(hours, workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            if (WorkCompleted != null)
            {
                WorkCompleted(this, EventArgs.Empty);
            }
        }

        public void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine(e.Hours.ToString());
        }

        public void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work is done");
        }
    }
}
