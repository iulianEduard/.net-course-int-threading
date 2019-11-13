using System;
using System.Threading;

namespace Threading.ThreadingTypesSamples
{
    public class CombinedTypesThread
    {
        public void Run()
        {
            Console.WriteLine("Foreground and background combined!");

            var foregroundThread = new Thread(PrintForegroundThread)
            {
                IsBackground = false,
                Name = "Foreground"
            };

            foregroundThread.Start();

            var backgroundThread = new Thread(PrintBackgroundThread)
            {
                IsBackground = true,
                Name = "Background"
            };

            backgroundThread.Start();

            Console.WriteLine("Exit main thread...");
        }

        private void PrintForegroundThread()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thread: #{i}, name: {Thread.CurrentThread.Name}");
                Thread.Sleep(1000);
            }
        }

        private void PrintBackgroundThread()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thread: #{i}, name: {Thread.CurrentThread.Name}");
                Thread.Sleep(1000);
            }
        }
    }
}
