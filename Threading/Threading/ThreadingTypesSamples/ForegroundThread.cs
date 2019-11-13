using System;
using System.Threading;

namespace Threading.ThreadingTypesSamples
{
    public class ForegroundThread
    {
        public void Run()
        {
            Console.WriteLine("Foreground thread");

            var thread = new Thread(PrintThread)
            {
                IsBackground = false,
                Name = "Foreground"
            };

            thread.Start();

            Console.WriteLine("Exiting main thread");
        }

        private void PrintThread()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thread: #{i}, name: {Thread.CurrentThread.Name}");
                Thread.Sleep(1000);
            }
        }
    }
}
