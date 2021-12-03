using System;
using Task_2.Enums;

namespace Task_2.TestingUtils
{
    abstract class CommonInfo
    {

        public DateTime creationDate { get; set; }
        public Priority priority { get; set; }

        public string summary { get; set; }
        public string precondition { get; set; }
        public Status status { get; set; }

        public CommonInfo()
        {
            creationDate = DateTime.Now;
        }

        public CommonInfo(string summary,
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
            while (true)
            {
                Console.WriteLine("Set priority: 1 - Low, 2 - Medium, 3 - High");

                int temp;
                bool flag = true;
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
                bool flag = true;
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
