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
                int choice = Actions.Choose(new string[] { "Add new Bug", "Remove Bug", "Show all Bugs", "Add new Test case",
                    "Remove Test case", "Show all Test cases", "Show bug by id", "Show test case by id",
                    "Sort Bugs By Summary", "Sort Test Case By Summary", "Filter Bug By Status", "Filter Test Case By Status" });
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
                    case 11:
                        Status statusBug = new Status();
                        while (true)
                        {
                            Console.WriteLine("Set status: 1 - New, 2 - InProgress, 3 - Failed, 4 - Done");

                            int temp;
                            flag = true;
                            if (int.TryParse(Console.ReadLine(), out temp))
                            {
                                switch (temp)
                                {
                                    case 1:
                                        statusBug = Status.New;
                                        break;
                                    case 2:
                                        statusBug = Status.InProgress;
                                        break;
                                    case 3:
                                        statusBug = Status.Failed;
                                        break;
                                    case 4:
                                        statusBug = Status.Done;
                                        break;
                                    default:
                                        flag = false;
                                        break;
                                }
                            }
                            else
                            {
                                flag = false;
                            }
                            if (flag == true) break;
                            else Console.WriteLine("Incorect input! Please repeat entering");
                        }
                        Services.FiltrBugsByStatus(bugs, statusBug);
                        break;
                    case 12:
                        Status statusTestCase = new Status();
                        while (true)
                        {
                            Console.WriteLine("Set status: 1 - New, 2 - InProgress, 3 - Failed, 4 - Done");

                            int temp;
                            flag = true;
                            if (int.TryParse(Console.ReadLine(), out temp))
                            {
                                switch (temp)
                                {
                                    case 1:
                                        statusTestCase = Status.New;
                                        break;
                                    case 2:
                                        statusTestCase = Status.InProgress;
                                        break;
                                    case 3:
                                        statusTestCase = Status.Failed;
                                        break;
                                    case 4:
                                        statusTestCase = Status.Done;
                                        break;
                                    default:
                                        flag = false;
                                        break;
                                }
                            }
                            else
                            {
                                flag = false;
                            }
                            if (flag == true) break;
                            else Console.WriteLine("Incorect input! Please repeat entering");
                        }
                        Services.FiltrTestCaseByStatus(testCases, statusTestCase);
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
