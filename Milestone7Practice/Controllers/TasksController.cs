using Microsoft.AspNetCore.Mvc;
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
    
    
    // POST endpoint 
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
        ); // this means: 201 created + the created object + a location header pointing to the action that can retrieve it
    }
    
    // what is [FromBody]?
    // [FromBody] explicitly means: take this parameter from the HTTP request body
    // so: request JSON body -> TaskItem
    // i didn't really understand what happened inside createtask, only th efirst line is clear
    // tasks.add(task), anything else is not clear at all
    

}