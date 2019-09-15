using System;
using System.Diagnostics;

namespace ImplementDiagnostics
{
    class Program
    {
        static void Main(string[] args)
        {
            //The .NET Framework offers classes that can help you with logging and tracing in the System.Diagnostics namespace. 
            // One such class is the Debug class, which can, as its name suggests, be used only in a debug build.
            Debug.WriteLine("Starting application");
            Debug.Indent();
            int i = 1 + 2;
            Debug.Assert(i == 3);
            Debug.WriteLineIf(i > 0, "i is greater than 0");

            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            traceSource.TraceInformation("Tracing application..");
            traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");
            traceSource.TraceData(TraceEventType.Information, 1, new object[] { "a", "b", "c" });
            traceSource.Flush();
            traceSource.Close();


            Console.ReadKey();


        }
    }
}
