using System;
using System.Threading;

namespace Threading.ThreadCreationSamples
{
    public class ThreadCreation
    {
        public void UsingThread()
        {
            var thread = new Thread(ThreadUsingThread);
            thread.Start();
        }

        public void UsingThreadStart()
        {
            var thread = new Thread(new ThreadStart(ThreadUsingThreadStart));
            thread.Start();
        }

        public void UsingThreadStartWithParameters()
        {
            var thread = new Thread(new ParameterizedThreadStart(ThreadUsingThreadStartWithParameters));
            thread.Start(DateTime.Now);
        }

        public void UsingLambdaExpressions()
        {
            var thread = new Thread(() => 
            {
                ThreadUsingThreadParameters(DateTime.Now);
            });

            thread.Start();
        }

        private void ThreadUsingThread()
        {
            Console.WriteLine("I am creating using Thread Class!");
            Console.WriteLine(Environment.NewLine);
        }

        private void ThreadUsingThreadStart()
        {
            Console.WriteLine("I am created using ThreadStart class");
            Console.WriteLine(Environment.NewLine);
        }

        private void ThreadUsingThreadStartWithParameters(object obj)
        {
            Console.WriteLine($"Thread created using ThreadStart with param. Date: {obj}");
            Console.WriteLine(Environment.NewLine);
        }

        private void ThreadUsingThreadParameters(object obj)
        {
            Console.WriteLine($"Thread created using ThreadStart with param. Date: {obj}");
            Console.WriteLine(Environment.NewLine);
        }
    }
}
