using System;
using System.Threading;

namespace algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = DateTime.Now.Millisecond;
            for (int i = 0; i < GetPots().Length; i++)
            {
                Console.WriteLine("This is " + GetPots()[i].PotName);
            }
            var t2 = DateTime.Now.Millisecond;

            Console.WriteLine("How long did it take? -> " + (t2 - t1) + "ms");

            Console.WriteLine("Raise an event");
            var nameDetector = new NameDetector();
            nameDetector.DetectName += InputDetected;
            var name = nameDetector.GetName();
            Console.WriteLine("The input is: {0}", name);
            nameDetector.DetectName -= InputDetected;
            Console.WriteLine("Threading");
            ThreadStart threadStart = new ThreadStart(RunInAnotherThread);
            Console.WriteLine("The child threat is created.");
            Thread childThread = new Thread(threadStart);
            Console.WriteLine("The child thread is starting");
            childThread.Start();
            // Thread.Sleep(2000);
            RunJustLikeThat();
        }

        private static MoneyPot[] GetPots()
        {
            var moneyPotFactory = new MoneyPotFactory();
            var pots = new MoneyPot[1000];
            for (int i = 0; i < pots.Length; i++)
            {
                pots[i] = moneyPotFactory.CreateMoneyPot("pot ", i);
            }
            return pots;

        }


        private static void InputDetected(object sender, EventArgs e)
        {
            Console.WriteLine("Input detected!");
        }

        private static void RunInAnotherThread()
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Running in another thread: {0}", i);
                }
            }
            catch (ThreadAbortException exception)
            {
                Console.WriteLine("Threat abort exception: {0}", exception);
            }
            finally
            {
                Console.WriteLine("Couldn't catch the Thread Exception");
            }
        }

        private static void RunJustLikeThat()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Run just like that {0}.", i);
            }
        }
    }
}
