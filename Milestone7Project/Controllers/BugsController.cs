using Microsoft.AspNetCore.Mvc;

namespace Milestone7Project.Controllers;

[ApiController]
[Route("bugs")]
public class BugsController : ControllerBase
{
    // fill with temporary data
    private static readonly List<BugTicket> bugs =
    [
        new(1, "Login button not working", "High", false),
        new(2, "Wrong page title", "Low", true),
        new(3, "Application crashes on startup", "Critical", false),
        new(4, "Profile image missing", "Medium", false)
    ];
    
    // endpoint 1
    [HttpGet]
    public IActionResult GetAllBugs(string? severity, bool? isResolved)
    {
        // if (severity is not null && isResolved is not null)
        // {
        //     return Ok(bugs
        //         .Where(bug => bug.Severity == severity)
        //         .Where(bug => bug.IsResolved == isResolved));
        // }
        IEnumerable<BugTicket> result = bugs;

        if (severity is not null)
        {
            // return Ok(bugs.Where(bug => bug.Severity == severity));
            result = result.Where(bug => bug.Severity == severity);
        }
        

        if (isResolved is not null)
        {
            // return Ok(bugs.Where(bug => bug.IsResolved == isResolved));
            result = result.Where(bug => bug.IsResolved == isResolved);
        }

        return Ok(result);
    }
    
    // endpoint 2
    [HttpGet("{id}")]
    public IActionResult GetBugById(int id)
    {
        BugTicket? bug = bugs.FirstOrDefault(bug => bug.Id == id);
        if (bug is null)
        {
            return NotFound();
        }

        return Ok(bug);
    }

    private static readonly string[] validSeverities = ["Low", "Medium", "High", "Critical"];
    
    // checkpoint 2 - POST - validation - CreatedAtAction
    [HttpPost]
    public IActionResult CreateBugTicket(BugTicket bug)
    {
        if (string.IsNullOrWhiteSpace(bug.Title))
        {
            return BadRequest("Title cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(bug.Severity))
        {
            return BadRequest("Severity cannot be empty");
        }

        if (!validSeverities.Contains(bug.Severity))
        {
            return BadRequest($"Invalid severity - {bug.Severity}");
        }

        bugs.Add(bug);
        return CreatedAtAction(
            nameof(GetBugById), // which action retrieves the new bug
            new { id = bug.Id }, // what value should be used for {id}?
            bug // what object should be returned in the response body?
            );

    }
    
    // checkpoint 3 - put
    // replace an existing bug
    [HttpPut("{id}")]
    public IActionResult UpdateBugTicket(int id, BugTicket updatedBug)
    {
        var bug = bugs.FirstOrDefault(bug => bug.Id == id);
        if (bug is null)
        {
            return NotFound();
        }

        if (string.IsNullOrWhiteSpace(updatedBug.Severity))
        {
            return BadRequest("Severity cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(updatedBug.Title))
        {
            return BadRequest("Title cannot be empty");
        }

        if (!validSeverities.Contains(updatedBug.Severity))
        {
            return BadRequest($"Invalid severity - {updatedBug.Severity}");
        }

        int index = bugs.IndexOf(bug);
        BugTicket replacement = updatedBug with { Id = id };
        bugs[index] = replacement;
        return Ok(replacement);
    }
    
    // checkpoint 4 - Patch
    [HttpPatch("{id}")]
    public IActionResult UpdateBugTicketStatus(int id, UpdateBugStatusRequest request)
    {
        var bug = bugs.FirstOrDefault(bug => bug.Id == id);
        if (bug is null)
        {
            return NotFound();
        }

        BugTicket updatedBug = bug with { IsResolved = request.IsResolved };
        int index = bugs.IndexOf(bug);
        bugs[index] = updatedBug;
        return Ok(updatedBug);
    }
    
    
    // checkpoint 5 - delete
    [HttpDelete("{id}")]
    public IActionResult DeleteBugTicket(int id)
    {
        var bug = bugs.FirstOrDefault(bug => bug.Id == id);
        if (bug is null)
        {
            return NotFound();
        }

        bugs.Remove(bug);
        return NoContent();
    }
}