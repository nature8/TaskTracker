namespace TaskService.Models;

public record TaskItem(
    int Id,
    string Title,
    bool IsCompleted
);