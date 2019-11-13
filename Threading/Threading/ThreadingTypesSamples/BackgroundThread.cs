using System;
using System.Threading;

namespace Threading.ThreadingTypesSamples
{
    public class BackgroundThread
    {
        public void Run()
        {
            Console.WriteLine("Background thread");

            var thread = new Thread(PrintThread)
            {
                IsBackground = true,
                Name = "Background"
            };

            thread.Start();

            Console.WriteLine("Exiting main thread");
        }

        private void PrintThread()
        {
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thread: #{i}, name: {Thread.CurrentThread.Name}");
                Thread.Sleep(1000);
            }
        }
    }
}
