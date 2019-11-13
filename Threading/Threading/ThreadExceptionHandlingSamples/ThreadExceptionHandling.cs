using System;
using System.Threading;

namespace Threading.ThreadExceptionHandlingSamples
{
    public class ThreadExceptionHandling
    {
        public void RunWithRegularFlow()
        {
            try
            {
                var thread = new Thread(WorkerUnhandled);
                thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RunWithThreadFlow()
        {
            try
            {
                var thread = new Thread(WorkHandled);
                thread.Start();
            }
            /*
             * This becomes obsolete because it the exceptions are handled
             * inside the WorkHandled
             */
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RunWithHandlingOnCaller()
        {
            try
            {
                Action<DateTime> action = AsyncWorkUnhandled;
                action.Invoke(DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void WorkerUnhandled()
        {
            throw new Exception("This is an exeption");
        }

        private void WorkHandled()
        {
            try
            {
                throw new Exception("This is a handled exception");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void AsyncWorkUnhandled(DateTime date)
        {
            throw new Exception($"This is an exeption generated at: {date}");
        }
    }
}
