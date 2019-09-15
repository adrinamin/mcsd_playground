using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ImplementMultithreading
{
    public class Program
    {
        // A thread can also have its own data that’s not a local variable. 
        // By marking a field with the ThreadStatic attribute, each thread gets its own copy of a field.
        //With the ThreadStaticAttribute applied, the maximum value of _field becomes 10. 
        // If you remove it, you can see that both threads access the same value and it becomes 20.
        [ThreadStatic]
        private static int _counter;

        // If you want to use local data in a thread and initialize it for each thread, you can use the ThreadLocal<T> class.
        // This class takes a delegate to a method that initializes the value.
        private static ThreadLocal<int> _localCounter = new ThreadLocal<int>(() =>
        {
            return Thread.CurrentThread.ManagedThreadId;
        });

        public static void Main(string[] args)
        {
            ImplementingThreads();
            ImplementTasks();
            ImplementParallel();
            ImplementAsyncAwait();
            ImplementPLinq();
        }

        // Parallel Language-Integrated Query (PLINQ) can be used on objects 
        // to potentially turn a sequential query into a parallel one.
        private static void ImplementPLinq()
        {
            var numbers = Enumerable.Range(0, 10);
            // force parallelism
            var result = numbers.AsParallel()
            .Where(i => i % 2 == 0)
            .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            .ToArray();

            foreach (var resultitem in result)
            {
                Console.WriteLine(resultitem);
            }

            Console.WriteLine("--------------------------------------------------");

            // limit parallelism
            var result2 = numbers.AsParallel()
            .Where(i => i % 2 == 0)
            .WithDegreeOfParallelism(2)
            .ToArray();

            foreach (var resultitem in result2)
            {
                Console.WriteLine(resultitem);
            }

            Console.WriteLine("--------------------------------------------------");

            //order output
            var result3 = numbers.AsParallel().AsOrdered()
            .Where(i => i % 2 == 0)
            .ToArray();

            foreach (var resultitem in result3)
            {
                Console.WriteLine(resultitem);
            }

            Console.WriteLine("--------------------------------------------------");

            //force sequential querying
            var result4 = numbers.AsParallel()
            .Where(i => i % 2 == 0).AsSequential()
            .ToArray();

            foreach (var resultitem in result4)
            {
                Console.WriteLine(resultitem);
            }

            Console.WriteLine("--------------------------------------------------");
            // When using PLINQ, you can use the ForAll operator 
            // to iterate over a collection when the iteration can also be done in a parallel way.
            var result5 = numbers.AsParallel().Where(i => i % 2 == 0);
            result5.ForAll(e => Console.WriteLine(e));
        }

        private static void ImplementAsyncAwait()
        {
            var result = DownloadContent().Result;
            Console.WriteLine(result);
        }

        // Asynchronous code solves this problem. 
        // Instead of blocking your thread until the I/O operation finishes, you get back a Task object that represents the result of the asynchronous operation. 
        // By setting a continuation on this Task, you can continue when the I/O is done. 
        // In the meantime, your thread is available for other work. 
        // When the I/O operation finishes, Windows notifies the runtime and the continuation Task is scheduled on the thread pool.
        // You use the async keyword to mark a method for asynchronous operations. 
        // This way, you signal to the compiler that something asynchronous is going to happen.
        // A method marked with async just starts running synchronously on the current thread. 
        // What it does is enable the method to be split into multiple pieces. 
        // The boundaries of these pieces are marked with the await keyword.
        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                // If you are building a client application that needs to stay responsive while background operations are running, 
                // you can use the await keyword to offload a long-running operation to another thread. 
                // Although this does not improve performance, it does improve responsiveness. 
                // The await keyword also makes sure that the remainder of your method runs on the correct user interface thread 
                // so you can update the user interface.
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }

        // The Parallel class has a couple of static methods—For, ForEach, and Invoke—that you can use to parallelize work.
        // Parallelism involves taking a certain task and splitting it into a set of related tasks that can be executed concurrently.
        // Increasing performance with parallel processing happens only when you have a lot of work to be done that can be executed in parallel. 
        // For smaller work sets or for work that has to synchronize access to resources, using the Parallel class can hurt performance.
        private static void ImplementParallel()
        {
            // Due to parallelization the console calls are completely in parallel.
            // There is no order anymore!
            Parallel.For(0, 10, (int i, ParallelLoopState state) =>
            {
                if (i == 5)
                {
                    Console.WriteLine("Breaking loop.");
                    state.Break();
                }
                Console.WriteLine("Parallel for loop: {0}", i);
            });

            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Console.WriteLine("parallel foreach loop: {0}.", i);
            });
        }

        // Tasks can be used to make your application more responsive. 
        // If the thread that manages the user interface offloads work to another thread from the thread pool, 
        // it can keep processing user events and ensure that the application can still be used. 
        // But it doesn’t help with scalability. 
        // If a thread receives a web request and it would start a new Task, 
        // it would just consume another thread from the thread pool while the original thread waits for results.
        // Executing a Task on another thread makes sense only if you want to keep the user interface thread free for other work 
        // or if you want to parallelize your work on to multiple processors.
        private static void ImplementTasks()
        {
            Task task = new Task(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("This loop runs inside a new Task");
                }
            });

            Task<int> task2 = new Task<int>(() =>
            {
                return 8;
            });

            Task<int> task3 = new Task<int>(() =>
            {
                return 4;
            });

            task.Start();
            task2.Start();

            // task.Wait() is the equivalent to thread.Join().
            // It waits until the task is finished before exiting the application.
            Console.WriteLine("task 2 status: " + task2.Status);
            task.Wait();
            task2.Wait();

            // IsCompleted is false until the task is finished.
            // If not using task.Wait() before it exits the application before the task is finished
            // and IsCompleted stays false.
            if (task2.IsCompleted)
            {
                Console.WriteLine("task 2 status: " + task2.Status);
                // Attempting to read the Result property on a Task will force the thread 
                // that’s trying to read the result to wait until the Task is finished before continuing. 
                // As long as the Task has not finished, it is impossible to give the result. 
                // If the Task is not finished, this call will block the current thread.
                Console.WriteLine("Show result of task 2: {0}.", task2.Result);
            }

            TaskContinuation();
            ChildTasks();
        }

        // The ContinueWith method has a couple of overloads that you can use to configure when the continuation will run. 
        // This way you can add different continuation methods that will run when an exception happens, 
        // the Task is canceled, or the Task completes successfully.
        private static void TaskContinuation()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();
        }

        // Next to continuation Tasks, a Task can also have several child Tasks. 
        // The parent Task finishes when all the child tasks are ready.
        private static void ChildTasks()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[6];

                // This can also be realized with taskfactory
                new Task(() => results[0] = 0,
                TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1,
                TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2,
                TaskCreationOptions.AttachedToParent).Start();

                // TaskFactory
                var factory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.None);
                factory.StartNew(() => results[3] = 3);
                factory.StartNew(() => results[4] = 4);
                factory.StartNew(() => results[5] = 5);

                return results;
            });

            var finalTask = parent.ContinueWith(
            parentTask =>
            {
                foreach (int i in parentTask.Result)
                    Console.WriteLine(i);
            });

            finalTask.Wait();

            // Wait for multiple Tasks:
            Task[] tasks = new Task[2];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });

            Task.WaitAll(tasks);

            // Next to WaitAll, you also have a WhenAll method that you can use to schedule a continuation method after all Tasks have finished.
            // Instead of waiting until all tasks are finished, you can also wait until one of the tasks is finished. 
            // You use the WaitAny method for this.
            int i = Task.WaitAny(tasks[0]);
            Console.WriteLine("WaitAny: {0}", i);
            Task<int> whenAnyTask = Task.WhenAny(tasks[1]).ContinueWith((i) =>
            {
                Console.WriteLine(i.Id);
                return 3;
            });

            Console.WriteLine("when any task: {0}.", whenAnyTask);
        }

        /// This belongs to the section Understanding threads.
        private static void ImplementingThreads()
        {
            Thread thread = new Thread(new ThreadStart(Counter));
            // If you run this application with the IsBackground property set to true, 
            // the application exits immediately. If you set it to false (creating a foreground thread), 
            //the application prints the Counter message ten times.
            thread.IsBackground = false;
            thread.Start();

            // The Thread constructor has another overload that takes an instance of a ParameterizedThreadStart delegate. 
            // This overload can be used if you want to pass some data through the start method of your thread to your worker method.
            // The parameter needs to be of type object. If necessary you need to cast it to another type.
            Thread threadWithParam = new Thread(new ParameterizedThreadStart(CounterWithParam));
            threadWithParam.Start(10);

            for (int i = 0; i < 10; i++)
            {
                _counter++;
                Console.WriteLine("The main thread. count {0}. ThreadStatic: {1}", i, _counter);
            }

            // The Thread.Join method is called on the main thread to let it wait until the other threads finish.
            thread.Join();
            threadWithParam.Join();

            //The thread pool automatically manages the amount of threads it needs to keep around.
            // When it is first created, it starts out empty. As a request comes in, it creates additional threads
            // to handle those requests. As long as it can finish an operation before a new one comes in,
            // no new threads have to be created. If new threads are no longer in use after some time, the
            // thread pool can kill those threads so they no longer use any resources.
            // Queuing a work item to a thread pool can be useful, but it has its shortcomings. There is no
            // built-in way to know when the operation has finished and what the return value is.
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine("thread from thread pool");
            });
        }

        private static void Counter()
        {
            for (int i = 0; i < _localCounter.Value; i++)
            {
                _counter++;
                Console.WriteLine("The second thread.count {0}. ThreadStatic: {1}", i, _counter);


                // Why the Thread.Sleep(0)? It is used to signal to Windows that this thread is finished. 
                // Instead of waiting for the whole time-slice of the thread to finish, it will immediately switch to another thread.
                Thread.Sleep(0);
            }
        }

        private static void CounterWithParam(object length)
        {
            for (int i = 0; i < (int)length; i++)
            {
                _counter++;
                Console.WriteLine("The third thread. count {0}. ThreadStatic: {1}", i, _counter);
            }
            Thread.Sleep(0);

        }
    }
}
