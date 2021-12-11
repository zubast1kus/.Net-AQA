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
                int choice = Actions.Choose(new string[] { "Add new Bug", "Remove Bug", "Show all Bugs", "Add new Test case", "Remove Test case", "Show all Test cases" });                
                bool flag = true;
                int id;                
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Bug bug = new Bug();
                        bug.SetInfo();
                        bugs.Add(bug);
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
                        bugs.RemoveAll((Bug bug) => bug.id == id);
                        break;
                    case 3:

                        foreach (Bug bugg in bugs)
                        {
                            bugg.ShowInfo();
                        }
                        break;
                    case 4:
                        TestCase test = new TestCase();
                        test.SetInfo();
                        testCases.Add(test);
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
                        testCases.RemoveAll((TestCase test) => test.id == id);
                        break;
                    case 6:

                        foreach (TestCase testt in testCases)
                        {
                            testt.ShowInfo();
                        }
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
