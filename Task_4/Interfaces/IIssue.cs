using System;
using Task_4.Enums;
using Task_4.Models;

namespace Task_4.Interfaces
{
    internal interface IIssue
    {        
        ID Id { get; }
        DateTime CreationDate { get; }
        Priority Priority { set; get; }
        string Summary { set; get; }
        string Precondition { set; get; }
        Status Status { set; get; }
        void Show();
        void Fill();
    }
}
