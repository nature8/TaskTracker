/*
using Microsoft.AspNetCore.Mvc;
using TaskService.Models;
using MassTransit;
using Contracts;
using Microsoft.AspNetCore.Authorization;

namespace TaskService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private static readonly List<TaskItem> Tasks = new()
    {
        new TaskItem(1, "Learn .NET 9", false),
        new TaskItem(2, "Build Microservices", false)
    };

    private readonly ILogger<TasksController> _logger;

    public TasksController(ILogger<TasksController> logger)
    {
        _logger = logger;
    }


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Add(
        TaskItem task,
        [FromServices] IPublishEndpoint publish)
        {
            // Save task
            Tasks.Add(task);

            // Publish event to RabbitMQ
            await publish.Publish(new TaskCreated(
            task.Id,
            task.Title,
            task.IsCompleted));

            return Ok(new
        {
            Message = "Task created and event published successfully",
            Task = task
        });
    }

[HttpPut("{id}")]
public IActionResult Update(int id, TaskItem updated)
{
    var task = Tasks.FirstOrDefault(t => t.Id == id);

    if (task == null)
        return NotFound();

    Tasks.Remove(task);
    Tasks.Add(updated);

    return Ok(updated);
}

[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var task = Tasks.FirstOrDefault(t => t.Id == id);

    if (task == null)
        return NotFound();

    Tasks.Remove(task);

    return NoContent();
}

}
*/

using Microsoft.AspNetCore.Mvc;
using TaskService.Models;
using MassTransit;
using Contracts;
using Microsoft.AspNetCore.Authorization;

namespace TaskService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private static readonly List<TaskItem> Tasks = new()
    {
        new TaskItem(1, "Learn .NET 9", false),
        new TaskItem(2, "Build Microservices", false)
    };

    private readonly ILogger<TasksController> _logger;

    public TasksController(ILogger<TasksController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation(
            "Fetching all tasks at {Time}",
            DateTime.UtcNow);

        return Ok(Tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Add(
        TaskItem task,
        [FromServices] IPublishEndpoint publish)
    {
        _logger.LogInformation(
            "Creating Task: Id={Id}, Title={Title}",
            task.Id,
            task.Title);

        // Save task
        Tasks.Add(task);

        _logger.LogInformation(
            "Task saved successfully: {Title}",
            task.Title);

        // Publish event to RabbitMQ
        await publish.Publish(
            new TaskCreated(
                task.Id,
                task.Title,
                task.IsCompleted));

        _logger.LogInformation(
            "TaskCreated event published to RabbitMQ for Task Id={Id}",
            task.Id);

        return Ok(new
        {
            Message = "Task created and event published successfully",
            Task = task
        });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TaskItem updated)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            _logger.LogWarning(
                "Update failed. Task Id={Id} not found",
                id);

            return NotFound();
        }

        Tasks.Remove(task);
        Tasks.Add(updated);

        _logger.LogInformation(
            "Task Id={Id} updated successfully",
            id);

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            _logger.LogWarning(
                "Delete failed. Task Id={Id} not found",
                id);

            return NotFound();
        }

        Tasks.Remove(task);

        _logger.LogInformation(
            "Task Id={Id} deleted successfully",
            id);

        return NoContent();
    }
}