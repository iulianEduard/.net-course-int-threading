using System;
using System.Threading;

namespace Threading.ThreadMethodsSamples
{
    public class ThreadMonitor
    {
        private Random _random = new Random();
        private long _total = 0;
        private int _n = 0;

        public void Run()
        {
            for(int i = 0; i < 5; i++)
            {
                var thread = new Thread(Worker)
                {
                    Name = $"Thread {i}"
                };
                thread.Start();
            }
        }

        private void Worker()
        {
            var values = new int[1000];
            var index = 0;
            int threadTotal = 0;
            int threads = 0;

            Monitor.Enter(_random);

            for(index = 0; index < 1000; index++)
            {
                values[index] = _random.Next(0, 1001);
            }

            Monitor.Exit(_random);

            threads = index;

            foreach(var v in values)
            {
                threadTotal += v;
            }

            Console.WriteLine($"Mean for thread: {Thread.CurrentThread.Name} {(threadTotal * 1.0) / threads}");

            Interlocked.Add(ref _n, threads);
            Interlocked.Add(ref _total, threadTotal);
        }
    }
}
