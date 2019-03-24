using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerConsole.AppOptionsHandling
{
    public class AppOption
    {
        public AppOption()
        {
            Console.WriteLine("AppOption created");
        }

        public string RunningTask { get; set; }
    }
}
