using System;

namespace Task_4.Models
{
    class Step
    {
        public int Number { get; }
        public string Action { get; set; }
        public string Result { get; set; }        
        private static int cntr = 0;

        public Step()
        {            
            Number = cntr;
            cntr++;
        }
        public Step(string action, string result)
        {
            Action = action;
            Result = result;            
            Number = cntr;
            cntr++;
        }
        public void Fill()
        {
            Console.WriteLine("Enter action");
            Action = Console.ReadLine();

            Console.WriteLine("Enter result");
            Result = Console.ReadLine();
        }
        public void Show() => Console.WriteLine($"number = {Number},\naction = {Action},\nresult = {Result}\n");
        public void Set(string action, string result)
        {
            Action = action;
            Result = result;
        }
        public override string ToString()
        {
            return $"number = {Number},\naction = {Action},\nresult = {Result}\n";
        }
    }
}
