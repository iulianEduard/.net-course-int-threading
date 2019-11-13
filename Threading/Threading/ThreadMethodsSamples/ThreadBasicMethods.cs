using System;
using System.Threading;

namespace Threading.ThreadMethodsSamples
{
    public class ThreadBasicMethods
    {
        private Thread thread1;
        private Thread thread2;

        public void Run()
        {
            thread1 = new Thread(Worker1)
            {
                Name = "Thread 1"
            };
            thread2 = new Thread(Worker2)
            {
                Name = "Thread 2"
            };

            thread1.Start();
            thread1.Join();
            thread2.Start();

            Console.WriteLine($"T1 state: {thread1.ThreadState}");
            Console.WriteLine($"T2 state: {thread2.ThreadState}");
        }

        private void Worker1()
        {
            Console.WriteLine($"T1 state: {thread1.ThreadState}");
            Console.WriteLine($"T2 state: {thread2.ThreadState}");

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Worker1: {i}");
                Thread.Sleep(200);
            }
        }

        private void Worker2()
        {
            Console.WriteLine($"T1 state: {thread1.ThreadState}");
            Console.WriteLine($"T2 state: {thread2.ThreadState}");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Workder2: {i}");
                Thread.Sleep(200);
            }
        }
    }
}
