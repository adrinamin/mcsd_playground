using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ExamPreparation
{
    public class Program
    {
        private static Stopwatch _execTimer = new Stopwatch();

        private static void Delay(int delay)
        {
            Thread.Sleep(delay);
        }

        private static void LogLongExecution(string msg)
        {
            if (_execTimer.Elapsed.Seconds > 2)
            {
                throw new Exception(string.Format("execution took too long: {0:N3} seconds", _execTimer.Elapsed.TotalMilliseconds));
            }
        }

        private static void StartExecTimer()
        {
            _execTimer.Start();
            Console.WriteLine("execTimer started");
            try
            {
                Delay(10);
                LogLongExecution("execution 10 milliseconds");
                Delay(3000);
                LogLongExecution("execution 6000 milliseconds");
                Delay(3000);
                LogLongExecution("execution 6000 milliseconds");
                Delay(4000);
                LogLongExecution("execution 6000 milliseconds");
            }
            catch (System.Exception ex)
            {
                using (XmlWriterTraceListener xmlLogger = new XmlWriterTraceListener("./ErrorLog.xml"))
                {
                    xmlLogger.TraceEvent(new TraceEventCache(),ex.Message,TraceEventType.Error,ex.HResult);
                    xmlLogger.Flush();
                }

                XmlWriterTraceListener xmlLogger2 = new XmlWriterTraceListener("./ErrorLog2.xml");
                xmlLogger2.WriteLine(ex.Message);
                xmlLogger2.Flush();
                xmlLogger2.Close();
            }
        }

        public static void Main(string[] args)
        {
            LinqTest();
            EnumarbleTesting();
            var date = new DateTime(2019, 09, 23);
            var temparature = -23.0d;
            Console.WriteLine(DisplayTemperature(date, temparature));
            GetTypesInAssembly();
            MyArraListCast();
        }

        private static void MyArraListCast()
        {
            ArrayList arrayList = new ArrayList();
            int var1 = 10;
            int var2;
            arrayList.Add(var1);
            // var2 = (int)arrayList[0];
            // var2 = Convert.ToInt32(arrayList[0]);
            Console.WriteLine("Setting var2 with the value of var1: {0}", var2);
        }

        private static void LinqTest()
        {
            IEnumerable<int> someRange = Enumerable.Range(0, 10);
            var result = from item in someRange
                         where item % 2 == 0
                         orderby item ascending
                         select item;

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
        }

        private static void EnumarbleTesting()
        {
            People people = new People();
            Person person = new Person
            {
                Name = "Adrin",
                Age = 29
            };

            Person person2 = new Person
            {
                Name = "Leonie",
                Age = 23
            };

            people.AddAscendingByAge(person);
            people.AddAscendingByAge(person2);
            Console.WriteLine("Number of people inside the person list: " + people.CountPeople());

            foreach (Person p in people)
            {
                Console.WriteLine("The persons name inside the list: " + p.Name);
            }
        }

        private static string DisplayTemperature(DateTime date, double temp)
        {
            string output = string.Empty;
            output = string.Format("temparature at {0:t} on {0:d} is {1:N2}", date, temp);
            return output;
        }

        private static void GetTypesInAssembly()
        {
            People people = new People();
            List<Type> types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(t => t.GetTypes())
            .Where(t => t.IsClass && t.Assembly == people.GetType().Assembly).ToList<Type>();
            foreach (var type in types)
            {
                Debug.WriteLine("The type: {0}", type);
                Debug.Indent();
                Debug.WriteLine("The base type: {0}", type.BaseType);
                Debug.Unindent();
            }
        }
    }
}
