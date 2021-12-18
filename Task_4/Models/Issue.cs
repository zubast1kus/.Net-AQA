using System;
using Task_4.Enums;
using Task_4.Interfaces;
using static Task_4.Actions.Actions;

namespace Task_4.Models
{
    abstract class Issue : IIssue
    {
        public ID Id { get; }
        public DateTime CreationDate { get; }
        public Priority Priority { get; set; }
        public string Summary { get; set; }
        public string Precondition { get; set; }
        public Status Status { get; set; }

        public Issue()
        {
            CreationDate = DateTime.Now;
            Status = Status.New;
            Id = new ID();
        }

        public Issue(string summary,
                     string precondition,
                     Priority priority,
                     Status status = Status.New)
        {
            Id = new ID();
            CreationDate = DateTime.Now;
            Summary = summary;
            Priority = priority;
            Precondition = precondition;
            Status = status;
        }
        public virtual void Show()
        {
            Console.WriteLine($"Id = {Id},\n" +
                              $"creationDate = {CreationDate},\n" +
                              $"priority = {Priority},\n" +
                              $"summary = {Summary},\n" +
                              $"precondition = {Precondition},\n" +
                              $"status = {Status}");
        }
        public override string ToString()
        {
            return $"Id = {Id},\n" +
                   $"creationDate = {CreationDate},\n" +
                   $"priority = {Priority},\n" +
                   $"summary = {Summary},\n" +
                   $"precondition = {Precondition},\n" +
                   $"status = {Status}";
        }
        public virtual void Fill()
        {
            int choice = Choose("Set priority:", "Low", "Medium", "High");
            switch (choice)
            {
                case 1:
                    Priority = Priority.Low;
                    break;
                case 2:
                    Priority = Priority.Medium;
                    break;
                case 3:
                    Priority = Priority.High;
                    break;
                default:
                    break;
            }

            Console.WriteLine("Set summary");
            Summary = Console.ReadLine();

            Console.WriteLine("Set precondition");
            Precondition = Console.ReadLine();

            choice = Choose("Set status:", "New", "InProgress", "Failed", "Done");
            switch (choice)
            {
                case 1:
                    Status = Status.New;
                    break;
                case 2:
                    Status = Status.InProgress;
                    break;
                case 3:
                    Status = Status.Failed;
                    break;
                case 4:
                    Status = Status.Done;
                    break;
                default:
                    break;
            }
        }
    }
}
