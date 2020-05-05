using System;

namespace EventsDelegatesLambdas
{
    public delegate int BizRuleDelegate(int x, int y);
    public class ProcessData
    {
        public void Process(int x, int y, BizRuleDelegate del)
        {
            int result = del(x, y);
            Console.WriteLine("Result for delegate operation is - " + result.ToString());
        }

        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
            Console.WriteLine("Action processed ");
        }

        public void ProcessFunc(int x, int y, Func<int, int, int> func)
        {
            int result = func(x, y);
            Console.WriteLine("Result for func operation is - " + result.ToString());
        }
    }
}
