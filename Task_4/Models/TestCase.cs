using System;
using System.Collections.Generic;
using Task_4.Enums;
using Task_4.Exceptions;
using static Task_4.Actions.Actions;

namespace Task_4.Models
{
    class TestCase : Issue
    {
        public List<Step> Steps;        
        public TestCase() : base()
        {
            Steps = new List<Step>();
        }
        public TestCase(string summary,
                        string precondition,
                        Priority priority,
                        Status status,
                        List<Step> steps) : base(summary, precondition, priority, status)
        {          
           Steps = steps;
        }
        public override void Fill()
        {
            base.Fill();
            Steps.Clear();
                   
            while (true)
            {
                bool flag = false;           
                int temp = Choose("Do you want to add new step?",
                                   "Yes");
                switch (temp)
                {
                    case 1:
                        Step step = new Step();
                        step.Fill();
                        Steps.Add(step);
                        break;
                    default:
                        flag = true;
                        break;
                }
                if (flag == true) break;
            }            
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Steps:");
            foreach (Step step in Steps)
            {
                step.Show();
            }
        }
        public override string ToString()
        {
            string result = base.ToString();
            result += "Steps:\n";
            foreach (Step step in Steps)
            {
               result += step;
            }
            return result;
        }
    }
}
