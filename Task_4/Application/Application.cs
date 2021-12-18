using System;
using System.Collections.Generic;
using Task_4.Exceptions;
using Task_4.Extensions;
using Task_4.Models;
using static Task_4.Actions.Actions;

namespace Task_4.Application
{
    static class Application
    {
        private static List<Bug> bugs = new List<Bug>();
        private static List<TestCase> testCases = new List<TestCase>();
        
        public static void Run()
        {
            while (true)
            {
                bool flag = false;
                long id;
                string parameterName, value;
                int dest = 0, choiceShowMethod;
                int choice = Choose("Menu:",
                                    "Create a test case",
                                    "Show a test case by id",
                                    "Show all test cases",
                                    "Delete test case by id",
                                    "Run a test case by id",
                                    "Show a bug by id",
                                    "Show all bugs",
                                    "Change a bug status by id",
                                    "Delete a bug");
                switch (choice)
                {
                    case 1:
                        ICollectionExtensions.AddIssue(testCases);
                        break;
                    case 2:
                        id = inputId();
                        ICollectionExtensions.ShowIssueById(testCases, id);
                        break;
                    case 3:
                        choiceShowMethod = Choose("Choose the options:", "Show all", "Show sorted", "Show filtered");
                        switch (choiceShowMethod)
                        {
                            case 1:
                                ICollectionExtensions.ShowAll(testCases);
                                break;
                            case 2:
                                Console.WriteLine("Enter the parameter name for sorting:");
                                parameterName = Console.ReadLine();
                                dest = Choose("Enter the order of sorting:", "Ascending", "Descending"); 
                                ICollectionExtensions.SortIssues(testCases, parameterName, dest - 1);
                                break;
                            case 3:
                                Console.WriteLine("Enter the parameter name for filtering:");
                                parameterName = Console.ReadLine();
                                Console.WriteLine("Enter the value for choosen parameter:");
                                value = Console.ReadLine();
                                ICollectionExtensions.FilterIssues(testCases, parameterName, value);                                
                                break;
                        }
                        break;
                    case 4:
                        id = inputId();
                        ICollectionExtensions.DeleteIssueById(testCases, id);
                        break;
                    case 5:
                        id = inputId();
                        ICollectionExtensions.RunTestCaseById(testCases, id, bugs);
                        break;
                    case 6:
                        id = inputId();
                        ICollectionExtensions.ShowIssueById(bugs, id);
                        break;
                    case 7:
                        choiceShowMethod = Choose("Choose the options:", "Show all", "Show sorted", "Show filtered");
                        switch (choiceShowMethod)
                        {
                            case 1:
                                ICollectionExtensions.ShowAll(bugs);
                                break;
                            case 2:
                                Console.WriteLine("Enter the parameter name for sorting:");
                                parameterName = Console.ReadLine();
                                dest = Choose("Enter the order of sorting:", "Ascending", "Descending");
                                ICollectionExtensions.SortIssues(bugs, parameterName, dest - 1);
                                break;
                            case 3:
                                Console.WriteLine("Enter the parameter name for filtering:");
                                parameterName = Console.ReadLine();
                                Console.WriteLine("Enter the value for choosen parameter:");
                                value = Console.ReadLine();
                                ICollectionExtensions.FilterIssues(bugs, parameterName, value);
                                break;
                        }
                        break;
                    case 8:
                        id = inputId();
                        ICollectionExtensions.ChangeBugStatusById(bugs, testCases, id);
                        break;
                    case 9:
                        id = inputId();
                        ICollectionExtensions.DeleteIssueById(bugs, id);
                        break;
                    default:
                        flag = true;
                        break;
                }
                if (flag == true) break;
                Console.WriteLine("To continue enter any button");
                Console.ReadKey();
            }
        }
        private static long inputId()
        {
            long number;
            while (true)
            {
                Console.WriteLine("Enter Id");
                try
                {
                    if (long.TryParse(Console.ReadLine(), out number))
                    {
                        break;
                    }
                    else
                    {
                        throw new InvalidInputException();
                    }
                }
                catch (InvalidInputException ex)
                {
                    ex.ShowMessage();
                }
            }
            return number;
        }
    }
}
