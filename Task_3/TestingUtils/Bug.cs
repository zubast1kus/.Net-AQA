using System;
using Task_3.Enums;

namespace Task_3.TestingUtils
{
    class Bug : Issue
    {
        public int id { get; set; }
        public int testCaseId { get; set; }
        public int stepNumber { get; set; }
        public string actualResult { get; set; }
        public string expectedResult { get; set; }
        
        public Bug() : base()
        {            
            this.id = cntr;
            cntr++;
        }
        public Bug(string summary,
                   string precondition,
                   Priority priority,
                   Status status,
                   int testCaseId,
                   int stepNumber,
                   string actualResult,
                   string expectedResult) : base(summary, precondition, priority, status)
        {
            this.id = cntr;
            cntr++;
            this.testCaseId = testCaseId;
            this.stepNumber = stepNumber;
            this.actualResult = actualResult;
            this.expectedResult = expectedResult;

        }

        public override void SetInfo()
        {            
            base.SetInfo();

            while (true)
            {
                Console.WriteLine("Set testCaseId");
                int temp;
                if (int.TryParse(Console.ReadLine(), out temp))
                {
                    testCaseId = temp;
                    break;
                }
                else
                {
                    Console.WriteLine("Incorect input! Please repeat entering");
                }
            }

            while (true)
            {
                Console.WriteLine("Set stepNumber");
                int temp;
                if (int.TryParse(Console.ReadLine(), out temp))
                {
                    stepNumber = temp;
                    break;
                }
                else
                {
                    Console.WriteLine("Incorect input! Please repeat entering");
                }
            }


            Console.WriteLine("Set actualResult");
            actualResult = Console.ReadLine();

            Console.WriteLine("Set expectedResult");
            expectedResult = Console.ReadLine();
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"id = {id},");
            base.ShowInfo();
            Console.WriteLine($"testCaseId = {testCaseId},\nstepNumber = {stepNumber},\nactualResult = {actualResult},\nexpectedResult = {expectedResult}\n");
        }
    }
}
