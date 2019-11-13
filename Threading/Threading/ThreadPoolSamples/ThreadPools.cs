using System;
using System.Threading;

namespace Threading.ThreadPoolSamples
{
    public class ThreadPools
    {
        public void Run()
        {
            ThreadPool.QueueUserWorkItem(Worker);
            ThreadPool.QueueUserWorkItem(Worker, 5);
        }

        private void Worker(object countTo)
        {
            if (countTo != null)
            {
                Console.WriteLine("Worker with paramter");
                for (int i = 0; i < Convert.ToInt32(countTo); i++)
                {
                    Console.WriteLine($"-- With param: {i}");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine("Worker with no param");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($">> Without param: {i}");
                    Thread.Sleep(800);
                }
            }
        }
    }

}
