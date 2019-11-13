using System;
using System.Threading;

namespace Threading.ThreadPrioritySamples
{
    public class ThreadPriorities
    {
        public void Run()
        {
            var lambdaThread = new Thread(() => { LambdaWorker(); })
            {
                Priority = ThreadPriority.Highest
            };

            var threadStartThread = new Thread(new ThreadStart(ThreadStartWorker))
            {
                Priority = ThreadPriority.Lowest
            };

            threadStartThread.Start();
            lambdaThread.Start();
        }

        private void LambdaWorker()
        {
            Console.WriteLine($"Lambda started at: {DateTime.Now.Ticks}");

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Lambda initialization: {i}");
                Thread.Sleep(400);
            }

            Console.WriteLine("-- Lambda: EOF");
        }

        private void ThreadStartWorker()
        {
            Console.WriteLine($"Thread start started at: {DateTime.Now.Ticks}");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thread start initialization: {i}");
                Thread.Sleep(400);
            }

            Console.WriteLine(">> Thread start: EOF");
        }
    }
}
