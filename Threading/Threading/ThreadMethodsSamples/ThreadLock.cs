using System;
using System.Threading;

namespace Threading.ThreadMethodsSamples
{
    public class ThreadLock
    {
        public void Run()
        {
            var threadSafeClass = new ThreadSafeClass();

            var thread1 = new Thread(threadSafeClass.Run)
            {
                Name = "Thread 1"
            };
            var thread2 = new Thread(threadSafeClass.Run)
            {
                Name = "Thread 2"
            };

            thread1.Start();
            thread2.Start();
        }

        public class ThreadSafeClass
        {
            private int _num1 = 0;
            private int _num2 = 0;
            private Random _random = new Random();
            private object _myLock = new object();

            public void Run()
            {
                lock (_myLock)
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.Name} has locked the object!");

                    for (int i = 0; i < 10; i++)
                    {
                        _num1 = _random.Next(1, 5);
                        _num2 = _random.Next(1, 5);
                        Console.WriteLine(_num1 / _num2);

                        _num1 = _num2 = 0;
                    }

                    Console.WriteLine($"Thread {Thread.CurrentThread.Name} has unlocked the object!");
                }
            }
        }
    }
}
