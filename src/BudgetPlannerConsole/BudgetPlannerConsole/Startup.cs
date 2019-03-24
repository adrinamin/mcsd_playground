using Autofac;
using BudgetPlannerConsole.AppOptionsHandling;
using BudgetPlannerConsole.BudgetHandling;

namespace BudgetPlannerConsole
{
    public class Startup
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new BudgetModule());
            //builder.RegisterModule(new AppOptionsHandlingModule());
            //TODO register components here...
            return builder.Build();
        }
    }
}
