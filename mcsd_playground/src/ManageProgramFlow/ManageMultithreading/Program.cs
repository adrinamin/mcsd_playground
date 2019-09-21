using System;
using System.Threading;
using System.Threading.Tasks;

namespace ManageMultithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter();
            CounterLocked();
            CounterInterlocked();
            WaitForCancellationToken();
        }

        // What would the output be? The answer is, it depends. 
        // When you run this application, you get a different output each time.
        private static void Counter()
        {
            int number = 0;
            Task task = new Task(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    number++;
                }
            });

            task.Start();

            for (int i = 0; i < 1000000; i++)
            {
                number--;
            }

            task.Wait();
            Console.WriteLine(number);
        }

        // This is because the operation is not atomic. 
        // It consists of both a read and a write that happen at different moments. 
        // This is why access to the data you’re working with needs to be synchronized, 
        // so you can reliably predict how your data is affected.
        // It’s important to synchronize access to shared data. 
        // One feature the C# language offers is the lock operator,
        private static void CounterLocked()
        {
            int number = 0;
            object _lock = new object();

            // After this change, the program always outputs 0 because access to the variable n is now synchronized. 
            // There is no way that one thread could change the value while the other thread is working with it.
            // However, it also causes the threads to block while they are waiting for each other. 
            // This can give performance problems and it could even lead to a deadlock, 
            // where both threads wait on each other, causing neither to ever complete.
            Task task = new Task(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock (_lock)
                    {
                        number++;
                    }
                }
            });

            task.Start();

            for (int i = 0; i < 1000000; i++)
            {
                lock (_lock)
                {
                    number--;
                }
            }

            task.Wait();
            Console.WriteLine(number);

        }

        // Making operations atomic is the job of the Interlocked class that can be found in the System.Threading namespace. 
        // When using the Interlocked.Increment and Interlocked.Decrement, you create an atomic operation
        // Interlocked guarantees that the increment and decrement operations are executed atomically. 
        // No other thread will see any intermediate results. 
        // Of course, adding and subtracting is a simple operation. 
        // If you have more complex operations, you would still have to use a lock.
        private static void CounterInterlocked()
        {
            int number = 0;
            Task task = new Task(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Interlocked.Increment(ref number);
                }
            });

            task.Start();

            for (int i = 0; i < 1000000; i++)
            {
                Interlocked.Decrement(ref number);
            }

            task.Wait();
            Console.WriteLine(number);
        }

        private static void WaitForCancellationToken()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task = Task.Run(()=>{
                
                while (!token.IsCancellationRequested)
                {
                    Console.WriteLine("Waiting...");
                    Thread.Sleep(1000);
                }
            },token);

            // You could also throw an exception afterwards and surround this call with try-catch.
            // Or you can add a ContinueWith method to handle what should happen after cancellation.
            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            cancellationTokenSource.Cancel();
            Console.WriteLine("Operation cancelled");
        }


    }
}
