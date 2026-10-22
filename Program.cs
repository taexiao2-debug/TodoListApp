using System;
using System.IO;

class Program
{
    // File used to save the tasks
    static string fileName = "tasks.txt";

    static void Main()
    {
        bool exit = false;

        // Keep showing the menu until the user chooses Exit
        while (!exit)
        {
            ShowMenu();

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;

                case "2":
                    ViewTasks();
                    break;

                case "3":
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Method to display the main menu
    static void ShowMenu()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("        TO-DO LIST APP");
        Console.WriteLine("==============================");
        Console.WriteLine("1. Add Task");
        Console.WriteLine("2. View Tasks");
        Console.WriteLine("3. Exit");
        Console.WriteLine("==============================");
    }

    // Method to add a new taskd
    static void AddTask()
    {
        try
        {
            Console.Write("Enter a new task: ");
            string task = Console.ReadLine() ?? "";

            // Check that the user entered something
            if (string.IsNullOrWhiteSpace(task))
            {
                Console.WriteLine("Task cannot be empty.");
                return;
            }

            // Add the task to the text file
            File.AppendAllText(fileName, task + Environment.NewLine);

            Console.WriteLine("Task added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving task: " + ex.Message);
        }
    }

    // Method to display saved tasks
    static void ViewTasks()
    {
        try
        {
            // Check if the file exists
            if (!File.Exists(fileName))
            {
                Console.WriteLine("No task file exists yet.");
                return;
            }

            // Read all tasks from the file
            string[] tasks = File.ReadAllLines(fileName);

            // Check if the file is empty
            if (tasks.Length == 0)
            {
                Console.WriteLine("No tasks have been saved.");
                return;
            }

            Console.WriteLine("===== SAVED TASKS =====");

            // Display each task
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + tasks[i]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading tasks: " + ex.Message);
        }
    }
}