using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Enums;
using Task_3.Interfaces;

namespace Task_3.TestingUtils
{
    abstract class Issue : IIssue
    {
        public static int cntr = 0;
        public DateTime creationDate { get; set; }
        public Priority priority { get; set; }

        public string summary { get; set; }
        public string precondition { get; set; }
        public Status status { get; set; }


        public Issue()
        {
            creationDate = DateTime.Now;
        }

        public Issue(string summary,
                          string precondition,
                          Priority priority,
                          Status status)
        {
            this.creationDate = DateTime.Now;
            this.summary = summary;
            this.priority = priority;
            this.precondition = precondition;
            this.status = status;
        }

        public virtual void ShowInfo() => Console.WriteLine($"creationDate = {creationDate},\npriority = {priority},\nsummary = {summary},\nprecondition = {precondition},\nstatus = {status}");
        public virtual void SetInfo()
        {
            bool flag;
            while (true)
            {
                Console.WriteLine("Set priority: 1 - Low, 2 - Medium, 3 - High");

                int temp;
                flag = true;
                if (int.TryParse(Console.ReadLine(), out temp))
                {
                    switch (temp)
                    {
                        case 1:
                            priority = Priority.Low;
                            break;
                        case 2:
                            priority = Priority.Medium;
                            break;
                        case 3:
                            priority = Priority.High;
                            break;
                        default:
                            flag = false;
                            break;
                    }
                }
                else
                {
                    flag = false;
                }
                if (flag == true) break;
                else Console.WriteLine("Incorect input! Please repeat entering");
            }


            Console.WriteLine("Set summary");
            summary = Console.ReadLine();

            Console.WriteLine("Set precondition");
            precondition = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Set status: 1 - New, 2 - InProgress, 3 - Failed, 4 - Done");

                int temp;
                flag = true;
                if (int.TryParse(Console.ReadLine(), out temp))
                {
                    switch (temp)
                    {
                        case 1:
                            status = Status.New;
                            break;
                        case 2:
                            status = Status.InProgress;
                            break;
                        case 3:
                            status = Status.Failed;
                            break;
                        case 4:
                            status = Status.Done;
                            break;
                        default:
                            flag = false;
                            break;
                    }
                }
                else
                {
                    flag = false;
                }
                if (flag == true) break;
                else Console.WriteLine("Incorect input! Please repeat entering");
            }
        }


    }

}
