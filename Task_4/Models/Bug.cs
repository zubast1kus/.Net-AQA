using System;
using Task_4.Enums;
using Task_4.Exceptions;

namespace Task_4.Models
{
    class Bug : Issue
    {
        public long? TestCaseId { get; set; }
        public int? StepNumber { get; set; }
        public string ActualResult { get; set; }
        public string ExpectedResult { get; set; }
        
        public Bug() : base()
        {
        }
        public Bug(string summary,
                   string precondition,
                   Priority priority,
                   Status status,
                   long testCaseId,
                   int stepNumber,
                   string actualResult,
                   string expectedResult) : base(summary, precondition, priority, status)
        {            
            TestCaseId = testCaseId;
            StepNumber = stepNumber;
            ActualResult = actualResult;
            ExpectedResult = expectedResult;
        }

        public override void Fill()
        {            
            base.Fill();

            while (true)
            {
                Console.WriteLine("Set Test Case Id");
                int temp;
                try
                {
                    if (int.TryParse(Console.ReadLine(), out temp))
                    {
                        TestCaseId = temp;
                        break;
                    }
                    else
                    {
                        throw new InvalidInputException();
                    }
                }
                catch (InvalidInputException ex)
                {
                    ex.ShowMessage();
                }
            }

            while (true)
            {
                Console.WriteLine("Set Step Number");
                int temp;
                try
                {
                    if (int.TryParse(Console.ReadLine(), out temp))
                    {
                        StepNumber = temp;
                        break;
                    }
                    else
                    {
                        throw new InvalidInputException();
                    }
                }
                catch (InvalidInputException ex)
                {
                    ex.ShowMessage();
                }
            }

            Console.WriteLine("Set actualResult");
            ActualResult = Console.ReadLine();

            Console.WriteLine("Set expectedResult");
            ExpectedResult = Console.ReadLine();
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"testCaseId = {TestCaseId},\nstepNumber = {StepNumber},\nactualResult = {ActualResult},\nexpectedResult = {ExpectedResult}\n");
        }
        public override string ToString()
        {
            return base.ToString() + $"testCaseId = {TestCaseId},\nstepNumber = {StepNumber},\nactualResult = {ActualResult},\nexpectedResult = {ExpectedResult}\n";
        }
    }
}
