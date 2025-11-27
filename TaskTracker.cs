
public class TaskTracker
{
    public Guid id { get; set; }
    public string? description { get; set; }
    public Status status { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime? updatedAt { get; set; }


    public override string ToString()
    {
        return $"{id} - {description} - {status} - {createdAt}";
    }
}


public enum Status
{
    Todo = 1,
    InProgress = 2,
    Done = 3
}
