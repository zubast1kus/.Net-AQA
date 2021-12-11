using System;
using System.Collections.Generic;
using Task_3.Enums;

namespace Task_3.TestingUtils
{
    class TestCase : Issue
    {
        public int id { get; set; }
        public List<Step> steps;
        
        public TestCase() : base()
        {
            this.id = cntr;
            cntr++;
            steps = new List<Step>();
        }

        public TestCase(string summary,
                        string precondition,
                        Priority priority,
                        Status status,
                        List<Step> steps) : base(summary, precondition, priority, status)
        {            
            this.id = cntr;
            cntr++;
            this.steps = steps;
        }
        public override void SetInfo()
        {
            base.SetInfo();
            steps.Clear();
            while (true)
            {
                bool flag = false;                
                Console.WriteLine("Do you want to add new step? \n 1 - Yes, Anything else - No ");                
                int temp;
                if (int.TryParse(Console.ReadLine(), out temp))
                {                    
                    
                    switch (temp)
                    {
                        case 1:
                            Step step = new Step();
                            step.SetInfo();
                            steps.Add(step);
                            break;
                        default:
                            flag = true;
                            break;
                    }
                    if (flag == true) break;
                }
                else
                {
                    Console.WriteLine("Incorect input! Please repeat entering");
                }                

            }
            
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"id = {id},");
            base.ShowInfo();
            Console.WriteLine("steps:");
            foreach (Step step in steps)
            {
                step.ShowInfo();
            }
        }
    }
}
