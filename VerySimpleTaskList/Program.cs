using System;
using System.Collections.Generic;

namespace VerySimpleTaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            while (true)
            {
                Console.WriteLine("Add, prioritize or complete a task, or exit? (add/mark/p/exit)");
                string choice = Console.ReadLine();
                if (choice == "exit")
                {
                    break;
                }

                if (choice == "add")
                {
                    Console.WriteLine("What is your task?");
                    string description = Console.ReadLine();
                    Task task = new Task(description);
                    tasks.Add(task);

                    Console.WriteLine("YOUR TASKS:");
                    Console.WriteLine("----------------------------------");
                    foreach (Task t in tasks)
                    {
                        Console.WriteLine(t.DescribeYourself());
                    }
                }
                else if (choice == "mark")
                {
                    for (int i = 0; i < tasks.Count; i += 1)
                    {
                        Task t = tasks[i];
                        string desc = t.DescribeYourself();
                        Console.WriteLine($"{i}. {desc}");
                        // Console.WriteLine($"{i}. {tasks[i].DescribeYourself()}");
                    }
                    Console.WriteLine("Which task would you like to complete?");
                    string input = Console.ReadLine();
                    int num = int.Parse(input);
                    tasks[num].MarkCompleted();
                }
                else if (choice == "p")
                {
                    for (int i = 0; i < tasks.Count; i += 1)
                    {
                        Console.WriteLine($"{i}. {tasks[i].DescribeYourself()}");
                    }
                    Console.WriteLine("Which task would you like to prioritize?");
                    string input = Console.ReadLine();
                    int num = int.Parse(input);
                    Console.WriteLine("What is the task's priority?");
                    input = Console.ReadLine();
                    int priority = int.Parse(input);
                    tasks[num].SetPriority(priority);
                }
            }
        }
    }
}
