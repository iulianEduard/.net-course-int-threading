using System;
using System.Diagnostics;
using System.Threading;

namespace Threading.ThreadPoolSamples
{
    public class ThreadPoolsAsynDelegates
    {
        public void Run()
        {
            Func<int, long> threadMethod = Worker;

            var resultDefaultParamValue = threadMethod.BeginInvoke(0, null, null);

            var resultWithParamValue = threadMethod.Invoke(20);

            var executionTicks = threadMethod.EndInvoke(resultDefaultParamValue);

            Console.WriteLine($"Thread with default param value executed in: {executionTicks} ticks");
            Console.WriteLine($"Thread with default param value executed in: {resultWithParamValue} ticks");
        }

        private long Worker(int countTo)
        {
            if (countTo > 0)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                Console.WriteLine("Worker with paramter");
                for (int i = 0; i < Convert.ToInt32(countTo); i++)
                {
                    Console.WriteLine($"-- With param: {i}");
                    Thread.Sleep(1000);
                }

                stopwatch.Stop();

                Console.WriteLine("Is polled thread? {0}", Thread.CurrentThread.IsThreadPoolThread);

                return stopwatch.ElapsedMilliseconds;
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                Console.WriteLine("Worker with no param");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($">> Without param: {i}");
                    Thread.Sleep(800);
                }

                stopwatch.Stop();

                Console.WriteLine("Is polled thread? {0}", Thread.CurrentThread.IsThreadPoolThread);

                return stopwatch.ElapsedMilliseconds;
            }
        }
    }
}
