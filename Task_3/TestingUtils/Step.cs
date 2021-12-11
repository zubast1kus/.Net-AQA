using System;

namespace Task_3.TestingUtils
{
    class Step
    {
        public int number { get; set; }
        public string action { get; set; }
        public string result { get; set; }
        private static int cntr = 0;

        public Step()
        {            
            this.number = cntr;
            cntr++;
        }

        public Step(string action, string result)
        {
            this.action = action;
            this.result = result;            
            this.number = cntr;
            cntr++;
        }

        public void SetInfo()
        {
            Console.WriteLine("Enter action");
            action = Console.ReadLine();

            Console.WriteLine("Enter result");
            result = Console.ReadLine();

        }

        public void ShowInfo() => Console.WriteLine($"number = {number},\naction = {action},\nresult = {result}\n");

    }
}
