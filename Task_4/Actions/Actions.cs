using System;
using System.Collections.Generic;
using Task_4.Exceptions;

namespace Task_4.Actions
{
    public static class Actions
    {
        public static int Choose(string title, params string[] options)
        {
            int choice;
            while (true)
            {
                Console.Clear();
                ShowOptions(title, options);
                try
                {
                    if (int.TryParse(Console.ReadLine(), out choice) && (choice >= 0) && (choice <= options.Length))
                    {
                        return choice;
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
        }
        public static int ChooseEnumOptions<T>()
            where T : Enum
        {
            var options = new List<string>();
            foreach (var option in Enum.GetValues(typeof(T)))
            {
                options.Add(option.ToString());
            }
            return Choose($"Choose a {nameof(T)}:", options.ToArray());
        }
        private static void ShowOptions(string title, params string[] paramList)
        {
            Console.WriteLine(title);
            for (int i = 0; i < paramList.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + paramList[i]);
            }
            Console.WriteLine("0 - Exit");
            Console.Write("Pleass enter your choice: ");
        }
    }
}
