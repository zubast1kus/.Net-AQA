using System;

namespace Task_4.Exceptions
{
    class InvalidInputException : Exception
    {
        public InvalidInputException() : base("Incorect input!")
        {
        }
        public InvalidInputException(string message) : base(message)
        {
        }
        public void ShowMessage()
        {
            Console.Clear();
            Console.WriteLine(Message);
            Console.WriteLine("To continue enter any button");
            Console.ReadKey();
        }
    }
}
