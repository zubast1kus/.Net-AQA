using System;
using System.Collections.Generic;
using System.Linq;
using static Task_4.Actions.Actions;
using Task_4.Enums;
using Task_4.Models;

namespace Task_4.Extensions
{
    static class ICollectionExtensions
    {
        public static void AddIssue<T>(this ICollection<T> issues)
            where T : Issue, new()
        {
            T issue = new T();
            issue.Fill();
            issues.Add(issue);
        }

        public static void ShowAll<T>(this ICollection<T> issues)
            where T : Issue
        {
            foreach (Issue issue in issues)
            {
                issue.Show();
            }
        }
        public static void ShowIssueById<T>(this ICollection<T> issues, long id)
            where T : Issue
        {
            foreach (T issue in issues)
            {
                if (issue.Id.Equals(id))
                {
                    issue.Show();
                }
            }
        }
        public static void SortIssues<T>(this ICollection<T> issues, string orderBy, int dest = 0)
            where T : Issue
        {

            var propertyInfo = typeof(T).GetProperty(orderBy);
            var sorted = issues.OrderBy(issues => propertyInfo.GetValue(issues, null));
            if (dest != 0) sorted.Reverse();
            foreach (T issue in sorted)
            {
                issue.Show();
            }
        }
        public static void FilterIssues<T>(this ICollection<T> issues, string filterBy, string value)
            where T : Issue
        {
            var propertyInfo = typeof(T).GetProperty(filterBy);
            var filtered = issues.Where(issues => propertyInfo.GetValue(issues, null).ToString().Equals(value));
            foreach (T issue in filtered)
            {
                issue.Show();
            }
        }
        public static void DeleteIssueById<T>(this ICollection<T> issues, long id)
            where T : Issue
        {
            var filtered = issues.Where(issues => !issues.Id.Equals(id));
            issues.Clear();
            foreach (T issue in filtered)
            {
                issues.Add(issue);
            }
        }        
        public static void RunTestCaseById(this ICollection<TestCase> testCases, long id, ICollection<Bug> bugs)
        {
            TestCase temp = null;
            foreach (TestCase testCase in testCases)
            {
                if (testCase.Id.Equals(id))
                {
                    temp = testCase;
                    break;
                }
            }
            if (temp == null) return;
            bool flag = true;
            int index = 0;
            for (int i = 0; i < temp.Steps.Count; i++)
            {                            
                int choice = Choose(temp.Steps.ElementAt(i) + "\nDoes the expexted result match?",
                                   "Yes");
                switch (choice)
                {
                    case 1:
                        break;
                    default:
                        flag = false;
                        index = i;
                        break;
                }
                if (flag == false) break;
            }
            if (flag == true) temp.Status = Status.Done;
            else
            {
                string preconditionSteps = "";
                for (int i = 0; i <= index; i++)
                {
                    preconditionSteps += temp.Steps.ElementAt(i);
                }
                int choice = Choose("Choose priority:", "Low", "Medium", "High");
                Priority priority = Priority.Medium;
                switch (choice)
                {
                    case 1:
                        priority = Priority.Low;
                        break;
                    case 2:
                        priority = Priority.Medium;
                        break;
                    case 3:
                        priority = Priority.High;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Input Actual Result");
                string actualResult = Console.ReadLine();
                Bug bug = new Bug(temp.Steps.ElementAt(index).Result + " doesn’t work",
                                  temp.Precondition + "\n" + preconditionSteps,
                                  priority,
                                  Status.New,
                                  temp.Id.Id,
                                  temp.Steps.ElementAt(index).Number,
                                  actualResult,
                                  temp.Steps.ElementAt(index).Result);
                bugs.Add(bug);
                Console.WriteLine("Test case is failed new bug created");
            }
        }
        public static void ChangeBugStatusById(this ICollection<Bug> bugs, ICollection<TestCase> testCases, long id)
        {
            int index = -1;
            for (int i = 0; i < bugs.Count; i++)
            {
                if (bugs.ElementAt(i).Id.Equals(id))
                {
                    index = i;
                    break;
                }
            }            
            if (index == -1) return;
            int choice = Choose("Choose new status:", "New", "InProgress", "Failed", "Done");
            switch (choice)
            {
                case 1:
                    bugs.ElementAt(index).Status = Status.New;
                    break;
                case 2:
                    bugs.ElementAt(index).Status = Status.InProgress;
                    break;
                case 3:
                    bugs.ElementAt(index).Status = Status.Failed;
                    break;
                case 4:
                    bugs.ElementAt(index).Status = Status.Done;
                    break;
                default:
                    break;
            }
            if (bugs.ElementAt(index).Status == Status.Done)
            {                
                for (int i = 0; i < testCases.Count; i++)
                {
                    if (testCases.ElementAt(i).Id.Equals(bugs.ElementAt(index).TestCaseId))
                    {
                        testCases.ElementAt(i).Status = Status.InProgress;
                        break;
                    }
                }                
            }
        }       
    }
}