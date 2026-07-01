/*using Contracts;
using MassTransit;

namespace UserService.Consumers;

public class TaskCreatedConsumer : IConsumer<TaskCreated>
{
    public Task Consume(ConsumeContext<TaskCreated> context)
    {
        var task = context.Message;

        Console.WriteLine(
            $"Task Received: {task.Id} - {task.Title}");

        return Task.CompletedTask;
    }
}*/


using Contracts;
using MassTransit;

namespace UserService.Consumers;

public class TaskCreatedConsumer :
    IConsumer<TaskCreated>
{
    private readonly ILogger<TaskCreatedConsumer> _logger;

    public TaskCreatedConsumer(ILogger<TaskCreatedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(
        ConsumeContext<TaskCreated> context)
    {
        var task = context.Message;

        _logger.LogInformation(
            "Task Received From RabbitMQ: Id={Id}, Title={Title}",
            task.Id,
            task.Title);

        Console.WriteLine(
            $"Task Received: {task.Title}");

        return Task.CompletedTask;
    }
}