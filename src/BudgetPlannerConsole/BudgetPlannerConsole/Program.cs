using Autofac;
using BudgetPlannerConsole.BudgetHandling;
using System;
using System.IO;

namespace BudgetPlannerConsole
{
    public class Program
    {
        private const string DIRECTORY_NAME = @"test_files";
        private const string FILE_NAME = @"testFile.txt";
        private const string SEPARATOR = @"\";
        private const string TEXT_FILE_ENDING = ".txt";
        private static IContainer container;
        private static Budget budget;

        static void Main(string[] args)
        {
            var startUp = new Startup();
            container = startUp.BuildContainer();
            CreateDirectory();
            WelcomeMessage();
            var selectedOption = GetSelectedOption();
            RunOption(selectedOption);
            Console.ReadKey(true);
        }

        static void CreateDirectory()
        {
            try
            {
                CheckIfDirectoryExists();
                var directoryInfo = Directory.CreateDirectory(DIRECTORY_NAME);
                Console.WriteLine("Directory {0} was successfully created at {1}.", directoryInfo.Name, directoryInfo.CreationTime);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private static void CheckIfDirectoryExists()
        {
            if (Directory.Exists(DIRECTORY_NAME))
            {
                Console.WriteLine("The directory {0} already exists.", DIRECTORY_NAME);
            }
        }

        static void WelcomeMessage()
        {
            Console.WriteLine("Hi! Welcome to BudgetPlanner.");
            Console.WriteLine("Following options are available: \n 1) Create Budget \n 2) Change Budget \n 3) Delete Budget");
        }

        static string GetSelectedOption()
        {
            Console.WriteLine("Please press a number from 1-3 to run a option");
            return ReadUserInput();
        }

        static void RunOption(string selectedOption)
        {
            switch (selectedOption)
            {
                case "1":
                    RunBudgetCeation();
                    BudgetNameMessage();
                    InitializeBudget();
                    CreateFile(budget.Name);
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Wrong input!");
                    break;
            }
        }

        private static void RunBudgetCeation()
        {
            var budgetCreator = container.Resolve<IBudgetCreator>();
            budget = budgetCreator.CreateBudget();
        }

        private static void BudgetNameMessage()
        {
            Console.WriteLine("Please type the name of your new budget: ");
        }

        static void InitializeBudget()
        {
            budget.Name = GetBudgetNameByUserInput();
            budget.Amount = 0.0;
        }

        private static string GetBudgetNameByUserInput()
        {
            return ReadUserInput();
        }

        private static void CreateFile(string fileName)
        {
            try
            {
                if (!File.Exists(DIRECTORY_NAME + SEPARATOR + fileName + TEXT_FILE_ENDING))
                {
                    var file = File.Create(DIRECTORY_NAME + SEPARATOR + fileName + TEXT_FILE_ENDING);
                    Console.WriteLine("created File {0}", fileName + TEXT_FILE_ENDING);
                    file.Close();
                }
                Console.WriteLine("You created the budget {0} with {1} Euro", budget.Name, budget.Amount);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private static void LogError(Exception exception)
        {
            Console.WriteLine(exception);
        }

        private static string ReadUserInput()
        {
            return Console.ReadLine();
        }
    }
}
