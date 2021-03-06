﻿using System;
using System.Collections.Generic;

namespace VerySimpleTaskList
{
    public class TaskManager
    {
        public TaskManager()
        {
            _tasks = new List<Task>();
        }

        public void Run()
        {
            while (true)
            {
                ShowMenu();
                int choice = GetNumberFromUser();

                if (choice == 0)
                {
                    break;
                }
                else if (choice == 1)
                {
                    DoAddTask();
                }
                else if (choice == 2)
                {
                    DoMarkTaskComplete();
                }
                else if (choice == 3)
                {
                    DoSetPriority();
                }
                else if (choice == 4)
                {
                    DoListAllTasks();
                }
            }
        }

        private void DoListAllTasks()
        {
            Console.Clear();
            Console.WriteLine("YOUR TASKS");
            Console.WriteLine("-------------------------");
            PrintNumberedTaskList();
            Console.WriteLine("-------------------------");
            Console.Write("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        private void DoSetPriority()
        {
            Console.Clear();
            Console.WriteLine("CHANGE TASK PRIORITY");
            Console.WriteLine("-------------------------");
            PrintNumberedTaskList();
            Console.WriteLine("-------------------------");
            Console.Write("What task do you want to change? ");

            int index = GetNumberFromUser();

            Console.Write("What is the new task's priority? ");

            int newPriority = GetNumberFromUser();

            _tasks[index].SetPriority(newPriority);
        }

        private void DoMarkTaskComplete()
        {
            Console.Clear();
            Console.WriteLine("COMPLETE A TASK");
            Console.WriteLine("-------------------------");
            PrintNumberedTaskList();
            Console.WriteLine("-------------------------");
            Console.Write("What task did you complete? ");

            int index = GetNumberFromUser();
            _tasks[index].MarkCompleted();
        }

        private void PrintNumberedTaskList()
        {
            for (int i = 0; i < _tasks.Count; i += 1)
            {
                Task task = _tasks[i];
                Console.WriteLine($"{i}. {task.DescribeYourself()}");
            }
        }

        private void DoAddTask()
        {
            Console.Clear();
            Console.WriteLine("ADD A TASK");
            Console.WriteLine("-------------------------");
            Console.WriteLine("What is your next task?");

            string description = GetStringFromUser();
            Task newTask = new Task(description);
            _tasks.Add(newTask);
        }

        private string GetStringFromUser()
        {
            return Console.ReadLine();
        }

        private int GetNumberFromUser()
        {
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("TASK MANAGEMENT!");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Add a task");
            Console.WriteLine("2. Mark a task complete");
            Console.WriteLine("3. Set a task's priority");
            Console.WriteLine("4. List the tasks");
            Console.WriteLine();
            Console.WriteLine("0. Exit");
            Console.WriteLine("-------------------------");
            Console.Write("What would you like to do? ");
        }

        private List<Task> _tasks;
    }
}
