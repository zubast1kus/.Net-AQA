using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task_3.TestingUtils
{
    static class Services
    {
        public static void AddBug(List<Bug> bugs)
        {
            Bug bug = new Bug();
            bug.SetInfo();
            bugs.Add(bug);
        }

        public static void RemoveBug(List<Bug> bugs, int id)
        {                        
            bugs.RemoveAll((Bug bug) => bug.id == id);
        }

        public static void ShowAllBugs(List<Bug> bugs)
        {
            foreach (Bug bug in bugs)
            {
                bug.ShowInfo();
            }
        }
        public static void AddTestCase(List<TestCase> testCases)
        {
            TestCase test = new TestCase();
            test.SetInfo();
            testCases.Add(test);
        }

        public static void RemoveTestCase(List<TestCase> testCases, int id)
        {
            testCases.RemoveAll((TestCase test) => test.id == id);
        }
        public static void ShowAllTestCase(List<TestCase> testCases)
        {
            foreach (TestCase test in testCases)
            {
                test.ShowInfo();
            }
        }
        public static void ShowBugById(List<Bug> bugs, int id)
        {
            foreach (Bug bug in bugs)
            {
                if (bug.id == id)
                {
                    bug.ShowInfo();
                }
            }
        }
        public static void ShowTestCaseById(List<TestCase> testCases, int id)
        { 
            foreach(TestCase test in testCases)
            {
                if (test.id == id)
                {
                    test.ShowInfo();
                }
            }
        }
        public static void SortBugsBySummary(List<Bug> bugs)
        {
            bugs.Sort((a, b) => a.summary.CompareTo(b.summary));
        }
        public static void SortTestCaseBySummary(List<TestCase> testCases)
        {
            testCases.Sort((a, b) => a.summary.CompareTo(b.summary));
        }
    }
}
// void Method(Type name)