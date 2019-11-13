using System;
using Threading.ThreadCreationSamples;
using Threading.ThreadExceptionHandlingSamples;
using Threading.ThreadingTypesSamples;
using Threading.ThreadMethodsSamples;
using Threading.ThreadPoolSamples;
using Threading.ThreadPrioritySamples;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            //BackgroundThreadExample();

            //ForegroundThreadExample();

            //CombinedThreadsExample();

            //ThreadCreationExample();

            //ThreadPoolExample();

            //ThreadPoolWithAsyncDelegatesExample();

            //ThreadExceptionHandlingExample();

            //ThreadPrioritiesExample();

            ThreadMethodsExample();
        }

        private static void BackgroundThreadExample()
        {
            var backgroundThread = new BackgroundThread();
            backgroundThread.Run();

            Console.ReadKey();
        }

        private static void ForegroundThreadExample()
        {
            var foregroundThread = new ForegroundThread();
            foregroundThread.Run();

            Console.ReadKey();
        }

        private static void CombinedThreadsExample()
        {
            var combinedTypesThread = new CombinedTypesThread();
            combinedTypesThread.Run();

            Console.ReadKey();
        }

        private static void ThreadCreationExample()
        {
            var threadCreation = new ThreadCreation();

            threadCreation.UsingThread();

            threadCreation.UsingThreadStart();

            threadCreation.UsingThreadStartWithParameters();

            threadCreation.UsingLambdaExpressions();

            Console.ReadKey();
        }

        private static void ThreadPoolExample()
        {
            var threadPool = new ThreadPools();
            threadPool.Run();

            Console.ReadKey();
        }

        private static void ThreadPoolWithAsyncDelegatesExample()
        {
            var threadPoolAsyncDelegates = new ThreadPoolsAsynDelegates();
            threadPoolAsyncDelegates.Run();

            Console.ReadKey();
        }

        private static void ThreadExceptionHandlingExample()
        {
            var threadExceptionHandling = new ThreadExceptionHandling();
            //threadExceptionHandling.RunWithRegularFlow();

            threadExceptionHandling.RunWithThreadFlow();

            threadExceptionHandling.RunWithHandlingOnCaller();

            Console.ReadKey();
        }

        private static void ThreadPrioritiesExample()
        {
            var threadPriorities = new ThreadPriorities();
            threadPriorities.Run();

            Console.ReadKey();
        }

        private static void ThreadMethodsExample()
        {
            //new ThreadBasicMethods().Run();

            //new ThreadMutex().Run();

            //new ThreadSemaphore().Run();

            //new ThreadLock().Run();

            new ThreadMonitor().Run();

            Console.ReadKey();
        }
    }
}
