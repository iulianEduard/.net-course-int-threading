using System;
using System.Threading;

namespace Threading.ThreadMethodsSamples
{
    public class ThreadSemaphore
    {
        private Semaphore _semaphore;
        private static int _padding;

        public void Run()
        {
            _semaphore = new Semaphore(0, 3);

            for (int i = 1; i <= 5; i++)
            {
                var thread = new Thread(new ParameterizedThreadStart(Worker))
                {
                    Name = $"Thread {i}"
                };

                thread.Start();
            }

            Thread.Sleep(4000);

            Console.WriteLine("Release 3");
            _semaphore.Release(3);

            Console.WriteLine("EOF");
        }

        private void Worker(object num)
        {
            var threadName = Thread.CurrentThread.Name;
            Console.WriteLine($"{threadName} requests the semaphore");

            _semaphore.WaitOne();

            _padding = Interlocked.Add(ref _padding, 100);

            Console.WriteLine($"{threadName} enters semaphore");

            Thread.Sleep(2000 + _padding);

            Console.WriteLine($"{threadName} realeases semaphore");

            int semaphoreCount = _semaphore.Release();

            Console.WriteLine($"Previous semaphore count: {semaphoreCount}");
        }
    }
}
