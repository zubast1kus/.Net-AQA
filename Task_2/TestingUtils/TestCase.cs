using System;
using System.Collections.Generic;
using Task_2.Enums;

namespace Task_2.TestingUtils
{
    class TestCase : CommonInfo
    {
        public int id { get; set; }
        public List<Step> steps;
        private static int cntr = 0;

        public TestCase() : base()
        {
            this.id = TestCase.cntr;
            TestCase.cntr++;
            steps = new List<Step>();
        }

        public TestCase(string summary,
                        string precondition,
                        Priority priority,
                        Status status,
                        List<Step> steps) : base(summary, precondition, priority, status)
        {
            this.id = TestCase.cntr;
            TestCase.cntr++;
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
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
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
