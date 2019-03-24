using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetPlannerConsole.BudgetHandling;

namespace BudgetPlannerConsole.AppOptionsHandling
{
    internal class CreateBudgetOptionStrategy : IBudgetOptionStrategy
    {
        private const string PATH = @"..\file.txt";
        private IBudgetCreator budgetCreator;
        private string budgetName;
        private double budgetAmount;

        public CreateBudgetOptionStrategy(IBudgetCreator budgetCreator)
        {
            this.budgetCreator = budgetCreator;
        }

        public Budget IntializeBudget()
        {
            var budget = budgetCreator.CreateBudget();
            budget.Name = budgetName;
            budget.Amount = budgetAmount;
            return budget;
        }

        public void ChangeBudget()
        {
            try
            {
                SaveBudgetIntoTextFile();
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        public void SetBudgetAmount(double amount)
        {
            budgetAmount = amount;
        }

        public void SetBudgetName(string name)
        {
            budgetName = name;
        }

        private void SaveBudgetIntoTextFile()
        {
            File.CreateText(PATH);
            //create a file
            //save amount and name
        }

        private void LogError(Exception exception)
        {
            Console.WriteLine("Creating text failed! {0}", exception);
        }
    }
}
