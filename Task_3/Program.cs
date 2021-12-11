using System;
using System.Collections.Generic;
using Task_3.Enums;
using Task_3.TestingUtils;

namespace Task_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Task 3");

            List<Bug> bugs = new List<Bug>();
            List<TestCase> testCases = new List<TestCase>();

            while (true)
            {                
                int choice = Actions.Choose(new string[] { "Add new Bug", "Remove Bug", "Show all Bugs", "Add new Test case", "Remove Test case", "Show all Test cases", "Show bug by id", "Show test case by id", "Sort Bugs By Summary", "Sort Test Case By Summary" });                
                bool flag = true;
                int id;                
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Services.AddBug(bugs);
                        break;
                    case 2:
                        while (true)
                        {
                            Console.WriteLine("Please enter bug`s id");
                            if (int.TryParse(Console.ReadLine(), out id))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Incorect input! Please repeat entering");
                            }
                        }
                        Services.RemoveBug(bugs, id);   
                        break;
                    case 3:
                        Services.ShowAllBugs(bugs);
                        break;
                    case 4:
                        Services.AddTestCase(testCases);    
                        break;
                    case 5:
                        while (true)
                        {
                            Console.WriteLine("Please enter Test case`s id");
                            if (int.TryParse(Console.ReadLine(), out id))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Incorect input! Please repeat entering");
                            }
                        }
                        Services.RemoveTestCase(testCases, id); 
                        break;
                    case 6:
                        Services.ShowAllTestCase(testCases);
                        break;
                    case 7:
                        while (true)
                        {
                            Console.WriteLine("Please enter Bug`s id");
                            if (int.TryParse(Console.ReadLine(), out id))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Incorect input! Please repeat entering");
                            }
                        }
                        Services.ShowBugById(bugs, id);
                        break;
                    case 8:
                        while (true)
                        {
                            Console.WriteLine("Please enter Test case`s id");
                            if (int.TryParse(Console.ReadLine(), out id))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Incorect input! Please repeat entering");
                            }
                        }
                        Services.ShowTestCaseById(testCases, id);
                        break;
                    case 9:
                        Services.SortBugsBySummary(bugs);
                        break;
                    case 10:
                        Services.SortTestCaseBySummary(testCases);
                        break;
                    default:
                        flag = false;
                        break;
                }

                if (flag == false) break;

            }

        }

    }


}
