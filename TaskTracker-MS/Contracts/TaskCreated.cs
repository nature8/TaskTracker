namespace Contracts;

public record TaskCreated(
    int Id,
    string Title,
    bool IsCompleted
);
