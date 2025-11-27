

using System.Text.Json;

public class CRUD {

    public void AddTask(string task)
    {
        var taskObj = new TaskTracker()
        {
            id = Guid.NewGuid(),
            description = task,
            status = Status.Todo,
            createdAt = DateTime.UtcNow,
        };

        List<TaskTracker> result = new List<TaskTracker>();

        if (File.Exists("SaveTasks.json"))
        {
            string json = File.ReadAllText("SaveTasks.json");

            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    result = JsonSerializer.Deserialize<List<TaskTracker>>(json)
                            ?? new List<TaskTracker>();
                }
                catch
                {
                    result = new List<TaskTracker>();
                }
            }
        }

        result.Add(taskObj);

        string output = JsonSerializer.Serialize(result, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("SaveTasks.json", output);
    }


    public bool UpdateTask(Guid id, string newContent)
    {
        var Tasks = GetAllTasks();
        if (Tasks.Count == 0)return false;
        
        bool isFound = false;
        foreach (var task in Tasks)
        {
            if (task.id == id)
            {
                task.description = newContent;
                task.updatedAt = DateTime.UtcNow;
                isFound = true;
                break;
            }
        }
        if (isFound)
        {
            string result = JsonSerializer.Serialize(Tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("SaveTasks.json", result);
            return true;
        }
        return false;
    }
    public bool DeleteTask(Guid id)
    {
        var Tasks = GetAllTasks();
        if (Tasks.Count == 0)return false;
        
        bool isFound = false;
        foreach (var task in Tasks)
        {
            if (task.id == id)
            {
                isFound = true;
                Tasks.Remove(task);
                break;
            }
        }
        if (isFound)
        {
            string result = JsonSerializer.Serialize(Tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("SaveTasks.json", result);
            return true;
        }
        return false;
    }
    public List<TaskTracker> GetAllTasks()
    {
        if (File.Exists("SaveTasks.json"))
        {
            string json = File.ReadAllText("SaveTasks.json");
            var result = new List<TaskTracker>();
            try
            {
                result = JsonSerializer.Deserialize<List<TaskTracker>>(json);
            }
            catch
            {
                result = new List<TaskTracker>();
            }
            return result;
        }
        return [];
    }
    public List<TaskTracker> GetAllTasksStatus(Predicate<TaskTracker> filter)
    {
         var Tasks = GetAllTasks();
        if (Tasks.Count == 0)return [];
        
        var result = new List<TaskTracker>();
        foreach (var task in Tasks)
        {
            if (filter(task))
                result.Add(task);
        }
        return result;
    }


    public bool MarkIn(Guid id, int status)
    {
        var Tasks = GetAllTasks();
        if (Tasks.Count == 0)return false;
        
        bool isFound = false;
        foreach (var task in Tasks)
        {
            if (task.id == id)
            {
                task.status = (Status)status;
                isFound = true;
                break;
            }
        }
        if (isFound)
        {
            string result = JsonSerializer.Serialize(Tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("SaveTasks.json", result);
            return true;
        }
        return false;

    }
}