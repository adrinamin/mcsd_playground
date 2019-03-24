using Autofac;

namespace BudgetPlannerConsole.BudgetHandling
{
    public class BudgetModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<BudgetCreator>().As<IBudgetCreator>();
        }
    }
}
