using System;

namespace EventsDelegatesLambdas
{
    public delegate void WorkPerformedHandler(int hours, WorkType workType);
    public class Worker
    {
        //Two custom events
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
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
                WorkPerformed(hours, workType);
            }
        }

        protected virtual void OnWorkCompleted()
        {
            if (WorkCompleted != null)
            {
                WorkCompleted(this, EventArgs.Empty);
            }
        }
    }
}
