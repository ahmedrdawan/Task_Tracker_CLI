

using System;

public class Menu
{
    private readonly CRUD _crud = new CRUD();

    public void Display()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("============== Task Tracker ==============");
            Console.WriteLine("1) Add Task");
            Console.WriteLine("2) View All Tasks");
            Console.WriteLine("3) Update Task");
            Console.WriteLine("4) Delete Task");
            Console.WriteLine("5) Mark Task Status");
            Console.WriteLine("6) View Tasks by Status");
            Console.WriteLine("0) Exit");
            Console.WriteLine("==========================================");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddTaskMenu();
                    break;

                case "2":
                    ViewAllTasksMenu();
                    break;

                case "3":
                    UpdateTaskMenu();
                    break;

                case "4":
                    DeleteTaskMenu();
                    break;

                case "5":
                    MarkStatusMenu();
                    break;

                case "6":
                    FilterTasksMenu();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid option!");
                    Pause();
                    break;
            }
        }
    }

    private void AddTaskMenu()
    {
        Console.Write("Enter task description: ");
        string desc = Console.ReadLine();

        _crud.AddTask(desc);
        Console.WriteLine("Task added successfully!");
        Pause();
    }

    private void ViewAllTasksMenu()
    {
        var tasks = _crud.GetAllTasks();
        Console.WriteLine("\n===== All Tasks =====");

        foreach (var t in tasks)
        {
            Console.WriteLine($"ID: {t.id}\nDesc: {t.description}\nStatus: {t.status}\nCreated: {t.createdAt}\n");
        }

        if (tasks.Count == 0)
            Console.WriteLine("No tasks found.");

        Pause();
    }

    private void UpdateTaskMenu()
    {
        Console.Write("Enter Task ID to update: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            Console.WriteLine("Invalid GUID format.");
            Pause();
            return;
        }

        Console.Write("Enter new description: ");
        string newTask = Console.ReadLine();

        bool ok = _crud.UpdateTask(id, newTask);
        Console.WriteLine(ok ? "Task updated." : "Task not found.");
        Pause();
    }

    private void DeleteTaskMenu()
    {
        Console.Write("Enter Task ID to delete: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            Console.WriteLine("Invalid GUID format.");
            Pause();
            return;
        }

        bool ok = _crud.DeleteTask(id);
        Console.WriteLine(ok ? "Task deleted." : "Task not found.");
        Pause();
    }

    private void MarkStatusMenu()
    {
        Console.Write("Enter Task ID to change status: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            Console.WriteLine("Invalid GUID format.");
            Pause();
            return;
        }

        Console.WriteLine("\n1 = Todo\n2 = InProgress\n3 = Done");
        Console.Write("Choose status: ");
        int status = int.Parse(Console.ReadLine());
        
        bool ok = _crud.MarkIn(id, status);
        Console.WriteLine(ok ? "Status updated." : "Task not found.");
        Pause();
    }

    private void FilterTasksMenu()
    {
        Console.WriteLine("\n1 = Todo\n2 = InProgress\n3 = Done");
        Console.Write("Choose status: ");

        int status = int.Parse(Console.ReadLine());

        var filtered = _crud.GetAllTasksStatus(t => t.status == (Status)status);

        Console.WriteLine("\n===== Filtered Tasks =====");
        foreach (var t in filtered)
        {
            Console.WriteLine($"ID: {t.id}\nDesc: {t.description}\nStatus: {t.status}\n");
        }

        if (filtered.Count == 0)
            Console.WriteLine("No tasks for this status.");

        Pause();
    }

    private void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
