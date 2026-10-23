using Milestone6Project;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(); // do i have to manually install these every time?, i did install the package and then it worked

var app = builder.Build();

app.MapOpenApi();


app.MapGet("/", () => "Hello World!");


// Milestone 6 Project Task Management API

// Checkpoint 1 - Model + GET endpoints

List<TaskItem> tasks = new()
{
    new(1, "Learn ASP.NET", "Practice Minimal APIs", false, "High"),
    new(2, "Go gym", "Back workout", true, "Medium"),
    new(3, "Study HTTP", "Review status codes", false, "High")
};

app.MapGet("/tasks", (bool? isCompleted, string? priority) =>
{
    if (isCompleted is not null && priority is not null)
    {
        List<TaskItem> combinedQueryTasks = tasks
            .Where(task => task.IsCompleted == isCompleted)
            .Where(task => task.Priority == priority)
            .ToList();
        return Results.Ok(combinedQueryTasks);
    }
    if (isCompleted is not null)
    {
        List<TaskItem> completedTasks = tasks
            .Where(task => task.IsCompleted == isCompleted)
            .ToList();
        return Results.Ok(completedTasks);
    }

    if (priority is not null)
    {
        List<TaskItem> priorityTasks = tasks
            .Where(task => task.Priority == priority)
            .ToList();
        return Results.Ok(priorityTasks);
    }
    
    return Results.Ok(tasks);
});


app.MapGet("/tasks/{id}", (int id) =>
{
    var task = tasks.FirstOrDefault(task => task.Id == id);
    if (task is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(task);
});

// Checkpoint 1 is done


// Checkpoint 2 - POST + validation + 201 created

string[] validPriorities = ["Low", "High", "Medium"];


app.MapPost("/tasks", (TaskItem task) =>
{
    if (string.IsNullOrWhiteSpace(task.Title))
    {
        return Results.BadRequest("Title cannot be empty");
    }

    if (string.IsNullOrWhiteSpace(task.Description))
    {
        return Results.BadRequest("Description cannot be empty");

    }

    if (string.IsNullOrWhiteSpace(task.Priority))
    {
        return Results.BadRequest("Priority cannot be empty");
    }

    // if (task.Priority != "Low" || task.Priority != "Medium" || task.Priority != "High")
    if (!validPriorities.Contains(task.Priority))
    {
        return Results.BadRequest("Priority must be one of these (Low, Medium, High)");
    }

    tasks.Add(task);

    return Results.Created($"/tasks/{task.Id}", task);
});


// Checkpoint 3 - PUT

app.MapPut("/tasks/{id}", (int id, TaskItem updatedTask) =>
{
    var task = tasks.FirstOrDefault(task => task.Id == id);
    if (task is null)
    {
        return Results.NotFound();
    }

    if (string.IsNullOrWhiteSpace(updatedTask.Priority))
    {
        return Results.BadRequest("Priority cannot be empty");

    }

    if (string.IsNullOrWhiteSpace(updatedTask.Title))
    {
        return Results.BadRequest("Title cannot be empty");

    }

    if (string.IsNullOrWhiteSpace(updatedTask.Description))
    {
        return Results.BadRequest("Description cannot be empty");
    }

    if (!validPriorities.Contains(updatedTask.Priority))
    {
        return Results.BadRequest("Allowed Priorities: Low, Medium, High");
    }

    int index = tasks.IndexOf(task);
    TaskItem replacement = updatedTask with { Id = id };
    tasks[index] = replacement;
    return Results.Ok(replacement);
});


// Checkpoint 4 - PATCH
app.MapPatch("/tasks/{id}", (int id, UpdateTaskStatusRequest request) =>
{
    var task = tasks.FirstOrDefault(task => task.Id == id);
    if (task is null)
    {
        return Results.NotFound();
    }

    TaskItem updatedTask = task with { IsCompleted = request.IsCompleted };
    int index = tasks.IndexOf(task);
    tasks[index] = updatedTask;
    return Results.Ok(updatedTask);
});


// Checkpoint 5 - DELETE
app.MapDelete("/tasks/{id}", (int id) =>
{
    var task = tasks.FirstOrDefault(task => task.Id == id);
    if (task is null)
    {
        return Results.NotFound();
    }

    tasks.Remove(task);
    return Results.NoContent();
});


app.Run();