//Задание 1:
//1.Создать массив int с рандомно-сгенерированными числами
//2.Отсортировать массив не используя временных переменных temp (все способы, что знаете)
//Задание 2:
//  1.Создать enum Priority (Low, Medium, High) и Status(New, InProgress, Failed, Done)
//  2.Создать переменные основных полей бага:
//    a)	Id;
//    b)	CreationDate; (заполняется автоматически)
//    c)	Priority; (тип Priority)
//    d)	Summary;
//    e)	Precondition;
//    f)	Status; (тип Status)
//    g)	TestCaseId;
//    h)	StepNumber;
//    i)	ActualResult;
//    j)	ExpectedResult.
//  3.Реализовать метод заполнения переменных с помощью ввода из консоли (Сделать с помощью примера: Fill(ref int id, ref Datetime creationDate, …) {…} )
//  4.Реализовать метод вывода заполненных переменных на экран
//  5.	Реализовать меню (Switch) для выбора действия для заданий 3 и 4
//*Задание 2а:
//  1.Вместо заданий 2 - 4, Определить переменные в класс, реализовать конструктор и метод вывода

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //1.Создать массив int с рандомно-сгенерированными числами
            Random rnd = new Random();
            int [] mas = new int[10];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(0, 10);
                for (int j = 0; j < i; j++)
                {
                    if (mas[i] == mas[j])
                    {
                        mas[i] = rnd.Next(0, 10);
                        j = -1;
                    }
                }
            }
            // 1 2 3 4 4 6 7 8 9 0
            Console.WriteLine("Исходный рандомный массив типа int");
            foreach (int i in mas)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();

            //2.Отсортировать массив не используя временных переменных temp(все способы, что знаете)
            ArrayList list = new ArrayList(mas);
            list.Sort();
            Console.WriteLine("Сортировка через структуру ArrayList с импользованием sort");
            foreach (int i in list)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
            Console.WriteLine("Сортировка c использованием LINQ");

            var orderedNumbers = from i in mas
                                 orderby i
                                 select i;
            foreach (int i in orderedNumbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Сортировка через структуру SorttedSet");

            SortedSet<int> sortedSet = new SortedSet<int>(mas);
            foreach (int i in sortedSet)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            //Задания 2-5

            Console.WriteLine("Задание 2 ");

            Bug bug = new Bug();

            while (true)
            {
                
                Console.WriteLine("Menu: 1 - Set Info, 2 - Show Info, 3 - Closed, 0 - Repeat ");
                int variant = Convert.ToInt32(Console.ReadLine());

                switch (variant)
                {
                    case 1:

                        int id = 0;
                        DateTime creationDate = DateTime.Now;
                        Priority priority  = new Priority();
                        string summary = "";
                        string precondition = "";
                        Status status = new Status();
                        int testCaseId = 0;
                        int stepNumber = 0;
                        string actualResult = "";
                        string expectedResult = "";

                        SetInfo(ref id,
                                ref summary,
                                ref precondition,
                                ref priority,
                                ref status,
                                ref testCaseId,
                                ref stepNumber,
                                ref actualResult,
                                ref expectedResult);

                        bug = new Bug(id,
                                      summary,
                                      precondition,
                                      priority,
                                      status,
                                      testCaseId,
                                      stepNumber,
                                      actualResult,
                                      expectedResult);
                        Console.Clear();

                        break;
                    case 2:
                        bug.ShowInfo();
                        break;
                    case 3:
                        Console.Clear();
                        return;
                        break;
                    case 0:
                        Console.Clear();
                        continue;
                        break;
                    default:
                        Console.Clear();
                        continue;
                        break;


                }

            }

             void SetInfo(ref int id,
                          ref string summary,
                          ref string precondition,
                          ref Priority priority,
                          ref Status status,
                          ref int testCaseId,
                          ref int stepNumber,
                          ref string actualResult,
                          ref string expectedResult)
            {
                Console.WriteLine("Set id");
                id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Set priority: 1 - Low, 2 - Medium, 3 - High");

                int nPriority = Convert.ToInt32(Console.ReadLine());
                switch (nPriority)
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
                        priority = Priority.Low;
                        break;
                }

                Console.WriteLine("Set summary");
                summary = Console.ReadLine();

                Console.WriteLine("Set precondition");
                precondition = Console.ReadLine();

                Console.WriteLine("Set status: 1 - New, 2 - InProgress, 3 - Failed, 4 - Done");

                int nStatus = Convert.ToInt32(Console.ReadLine());
                switch (nStatus)
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
                        status = Status.New;
                        break;
                }

                Console.WriteLine("Set testCaseId");
                testCaseId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Set stepNumber");
                stepNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Set actualResult");
                actualResult = Console.ReadLine();

                Console.WriteLine("Set expectedResult");
                expectedResult = Console.ReadLine();
            }
        }

    }
    
    class Bug
    {
        int id;
        DateTime creationDate = DateTime.Now;
        Priority priority = new Priority();
        string summary;
        string precondition;
        Status status = new Status();
        int testCaseId;
        int stepNumber;
        string actualResult;
        string expectedResult;
        public Bug()
        {

        }
        public Bug(int id,
                   string summary,
                   string precondition,
                   Priority priority,
                   Status status,
                   int testCaseId,
                   int stepNumber,
                   string actualResult,
                   string expectedResult)
        {
            this.id = id;
            this.creationDate = DateTime.Now;
            this.summary = summary;
            this.priority = priority;
            this.precondition = precondition;
            this.status = status;
            this.testCaseId = testCaseId;
            this.stepNumber = stepNumber;
            this.actualResult = actualResult;
            this.expectedResult = expectedResult;
        }
        
       
        public void ShowInfo() => Console.WriteLine(" id = {0},\n " +
            "creationDate = {1},\n " +
            "priority = {2},\n " +
            "summary = {3},\n " +
            "precondition = {4},\n " +
            "status = {5},\n " +
            "testCaseId = {6},\n " +
            "stepNumber = {7},\n " +
            "actualResult = {8},\n " +
            "expectedResult = {9}", 
            id, creationDate, priority, summary, precondition, status, testCaseId, stepNumber, actualResult, expectedResult);
    }
    public enum Priority
    {
        Low,
        Medium,
        High
    }
    public enum Status
    {
        New,
        InProgress,
        Failed,
        Done
    }
}
