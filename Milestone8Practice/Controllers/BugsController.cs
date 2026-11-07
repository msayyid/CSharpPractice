using Microsoft.AspNetCore.Mvc;
using Milestone8Practice.Services;

namespace Milestone8Practice.Controllers;



[ApiController] // this tells ASP.NET:
// this class is an API controller, so apply API-specific behavior like 
// model binding and automatic API conventions
[Route("bugs")] 
public class BugsController : ControllerBase
// ControllerBase gives us controller helper methods like Ok(), NotFound()...
{
    
    // create a BugService object so this controller can use it
    // private readonly BugService _bugService = new(); 
    // private - only this class can access it
    // readonly - once _bugService has been assigned, this field
    // cannot be reassigned later
    // static - is it shared between all objects? // yes one field shared by all instances of the class
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // from here BugService is provided by dependency injection,
    // BugsController no longer creates BuService itself.
    // ASP.NET creates/provides BugService through dependency injection.
    

    // private readonly BugService _bugService; // this creates a field where we can keep the service

    private readonly IBugService _bugService;
    
    // a constructor; ASP.NET sees it and thinks:
    // BugsController needs a BugService
    // because we registered builder.Services.AddSingleton<BugService>();
    
    public BugsController(IBugService bugService)
    {
        _bugService = bugService;
    } // this means: ASP.NET gives us: bugService, and we store it in _bugService
    

    [HttpGet]
    public IActionResult GetAllBugs()
    {
        List<BugTicket> bugs = _bugService.GetAll(); // BugService, give me all the bugs

        return Ok(bugs);
    }

    [HttpGet("{id}")]
    public IActionResult GetBugById(int id)
    {
        BugTicket? bug = _bugService.GetById(id);

        if (bug is null)
        {
            return NotFound();
        }

        return Ok(bug);
    }

    [HttpPost]
    public IActionResult CreateBug(BugTicket bug)
    {
        BugTicket createdBug = _bugService.Create(bug);

        return CreatedAtAction(
            nameof(GetBugById),
            new { id = createdBug.Id },
            createdBug
        );
    
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBug(int id, BugTicket updatedBug)
    {
        BugTicket? result = _bugService.Update(id, updatedBug);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
        // there's a mistake in here possibly
        // maybe not
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBug(int id)
    {
        bool deleted = _bugService.Delete(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}


// Controller asks WHAT it needs
// Service handles HOW to do it