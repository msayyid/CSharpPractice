using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace Milestone7Practice.Controllers;

[ApiController] // this is an attribute
// an attribute adds metadata/instructions to something
// [ApiController] tells ASP.NET: this class is an API controller ands should get API-specific behavior

[Route("tasks")] // this defines base route for the controller
// meaning endpoints inside this class start with:
// /tasks

public class TasksController : ControllerBase
// this means:
// TaskController is A ControllerBase.
// ControllerBase is a class provided by ASP.NET Core
// it gives the controller useful HTTP functionality
// things like : Ok(...), NotFound()...
{
    
    // put some data inside TasksController for now
    private static readonly List<TaskItem> tasks =
        // static field -> belongs to the class / shared
        [
            new(1, "Learn Controllers", false),
            new(2, "Practice ASP.NET", true),
            new(3, "Go gym", false)
        ];

    [HttpGet]
    public IActionResult GetTasks()
    {
        
        // what is IActionResult?
        // IActionResult is an interface representing a possible HTTP result returned by a controller action
        // this method return an HTTP response/result
        
        
        // return Ok("Hello from TasksController");
        return Ok(tasks);
        // what is [HttpGet]
        // before we had app.MapGet() ....
        // now we have [Route("tasks")]
        // plus [HttpGet]
        // together they mean:
        // GET /tasks
        // [Route("tasks")] + [HttpGet] -> GET /tasks
    }
    
    
    // get one task by ID
    [HttpGet("{id}")]
    public IActionResult GetTaskById(int id)
    // [Route("tasks")] + [HttpGet("{id}")] -> GET /tasks/{id}
    {
        TaskItem? task = tasks.FirstOrDefault(task => task.Id == id);
        if (task is null)
        {
            return NotFound();
        }

        return Ok(task);
    }
    
    // -------------------------------------------------------------
    // POST endpoint 
    // [HttpPost]
    // public IActionResult CreateTask(TaskItem task)
    // {
    //
    //     if (string.IsNullOrWhiteSpace(task.Title))
    //     {
    //         return BadRequest("Title cannot be empty");
    //     }
    //     tasks.Add(task);
    //     return CreatedAtAction(
    //         nameof(GetTaskById), // this basically means: which controller action retrieves this resource? -> GetTaskById
    //         new { id = task.Id }, // this tells ASP.NET what value to use for {id}
    //         task // put the created task in the response body
    //     ); // this means: 201 created + the created object + a location header pointing to the action that can retrieve it
    // }
    //
    // CreatedAtAction means:
    // i created something, and here is the controller action that can retrieve it
    // we already have the GetTaskById(), so after creating a task
    // ASP.NET can say: the new task was created, and you can find it using GetTaskById with id
    // ------- all together:
    // 1. return 201 created
    // 2. the newly created resource can be retrieved using GetTaskById
    // 3. Give GetTaskById this route value: id = task.Id
    // 4. return task itself in the response body
    // -------------------------------------------------------------
    [HttpPost]
    public IActionResult CreateTask(TaskItem task)
    {
        if (string.IsNullOrWhiteSpace(task.Title))
        {
            return BadRequest("Title cannot be empty");
        }

        tasks.Add(task);

        return CreatedAtAction(
            nameof(GetTaskById),
            new { id = task.Id },
            task
        );
    }
    
    
    // lesson 3 - continued [FromBody]
    
    
    // [ApiController] present
    // → ASP.NET usually knows TaskItem comes from body
    // → [FromBody] usually optional

    
    
    // lesson 4
    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, TaskItem updatedTask)
    {
        TaskItem? task = tasks.FirstOrDefault(task => task.Id == id);
        if (task is null)
        {
            return NotFound();
        }

        if (string.IsNullOrWhiteSpace(updatedTask.Title))
        {
            return BadRequest("Title cannot be empty");
        }

        int index = tasks.IndexOf(task);
        TaskItem replacement = updatedTask with { Id = id };
        tasks[index] = replacement;
        return Ok(replacement);
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        TaskItem? task = tasks.FirstOrDefault(task => task.Id == id);
        if (task is null)
        {
            return NotFound();
        }

        tasks.Remove(task);
        
        return NoContent();
    }
    
    
    // Lesson 5 - PATCH in controllers
    [HttpPatch("{id}")]
    public IActionResult UpdateTaskStatus(int id, UpdateTaskStatusRequest request)
    {
        TaskItem? task = tasks.FirstOrDefault(task => task.Id == id);
        if (task is null)
        {
            return NotFound();
        }

        TaskItem updatedTask = task with { IsCompleted = request.IsCompleted }; // create a new copy of the existing task and change only IsCompleted
        int index = tasks.IndexOf(task);
        tasks[index] = updatedTask;
        return Ok(updatedTask);
    }
    
    
}