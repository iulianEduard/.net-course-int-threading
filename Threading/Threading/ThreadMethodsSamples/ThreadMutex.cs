using System;
using System.Threading;

namespace Threading.ThreadMethodsSamples
{
    public class ThreadMutex
    {
        private readonly Mutex mutex;

        public ThreadMutex()
        {
            mutex = new Mutex();
        }

        public void Run()
        {
            for(int i = 1; i <= 3; i++)
            {
                var thread = new Thread(new ThreadStart(Worker))
                {
                    Name = $"Thread {i}"
                };
                thread.Start();
            }
        }

        private void Worker()
        {
            var threadName = Thread.CurrentThread.Name;
            Console.WriteLine($"{threadName} -> Request mutex");
            mutex.WaitOne();

            Console.WriteLine($"{threadName} -> Safe area");
            Thread.Sleep(3000);

            mutex.ReleaseMutex();
            Console.WriteLine($"{threadName} -> Mutex was released");
        }
    }
}
