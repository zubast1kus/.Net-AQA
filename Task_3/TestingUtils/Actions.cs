using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.TestingUtils
{
    static class Actions
    {
        public static int Choose(string[] menu)
        {
            
            int choice;
            while (true)
            {
                for (int i = 0; i < menu.Length; i++)
                {
                    Console.WriteLine((i + 1) + " - " + menu[i]);
                }
                Console.WriteLine("0 - Exit");
                
                Console.Write("Pleass enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && (choice >= 0) && (choice <= menu.Length))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorect input! Please repeat entering");
                }               
                
            }
            return choice;
        }
    }
}
