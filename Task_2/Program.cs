using System;
using System.Collections.Generic;
using Task_2.Enums;
using Task_2.TestingUtils;

namespace Task_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Task 2");

            List<Bug> bugs = new List<Bug>();
            List<TestCase> testCases = new List<TestCase>();

            while (true)
            {
                Console.WriteLine("\nPleass enter your choice: \n1 - Add new Bug, \n2 - Remove Bug, \n3 - Show all Bugs, \n4 - Add new Test case, \n5 - Remove Test case, \n6 - Show all Test cases, \nAnything else - exit");

                int temp = 0;
                bool flag = true;
                int id;
                int.TryParse(Console.ReadLine(), out temp);  
                Console.Clear();    
                switch (temp)
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
