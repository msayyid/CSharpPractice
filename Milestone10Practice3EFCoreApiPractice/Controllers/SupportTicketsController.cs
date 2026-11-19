namespace Milestone10Practice3EFCoreApiPractice.Controllers;

using Microsoft.AspNetCore.Mvc; // this gives us ASP.NET Core MVC/API things such as: {[ApiController], [Route()], [HttpGet] ...}
// so basically import the ASP.NET Core controller/API functionality we need

using Milestone10Practice3EFCoreApiPractice.Models;
using Milestone10Practice3EFCoreApiPractice.Services;


[ApiController] // -> "ASP.NET, treat this class as an API controller", it enables api-specific behavior such as model binding and controller conventions
[Route("tickets")] // this is like a root route for the api /tickets
public class SupportTicketsController : ControllerBase // means:
// SupportTicketController IS A ControllerBase, it gives us useful API methods such as Ok(), NotFound()...
// without inheriting from it, we wouldn't have the controller helper methods available in the same way
{
    private readonly SupportTicketService _service; // store the injected service so all controller methods can use it
    // private only this controller class can access the field
    // readonly -> after we assign the field in the constructor, we cannot replace it with another service object later

    public SupportTicketsController(SupportTicketService service)
    {
        _service = service; // controller needs SupportTicketService, DI gives it one
        // question: so the constructor asks DI to give us service correct? is that how they connect?
        // the thing is the DI is not here, and i do not see what we are connecting it with, that's why asking 
        // -- asnwer --
        // yes, we registered builder.Services.AddScoped<SupportTicketService>();
        // that tells DI:
        // if somebody asks for a SupportTicketService, i know how to provide one
        
        // so the chain is:
        // ASP.NET wants to create SupportTicketsController
        //     ↓
        // looks at constructor
        //     ↓
        // "This needs SupportTicketService"
        //     ↓
        // DI finds SupportTicketService registration
        //     ↓
        // DI creates/provides SupportTicketService
        //     ↓
        // constructor receives it
        //     ↓
        // _service = service
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tickets = await _service.GetAllAsync();
        return Ok(tickets);
    }
    
    // get by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ticket = await _service.GetByIdAsync(id);

        if (ticket is null)
        {
            return NotFound();
        }

        return Ok(ticket);
    }
    
    // POST, create
    [HttpPost]
    public async Task<IActionResult> Create(SupportTicket newTicket)
    {
        if (string.IsNullOrWhiteSpace(newTicket.Title))
        {
            return BadRequest("Title cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(newTicket.Category))
        {
            return BadRequest("Category cannot be empty");
        }
        var createdTicket = await _service.CreateAsync(newTicket);

        return CreatedAtAction(
            nameof(GetById), // name of the method that could retrieve this new object
            new { id = createdTicket.Id }, // how to retrieve it, what param to use
            createdTicket); // and the created object itself 
    }
    
}


// DI full chain:

// ASP.NET creates Controller
//     ↓
// Controller needs SupportTicketService
//     ↓
// DI creates SupportTicketService
//     ↓
// SupportTicketService needs AppDbContext
//     ↓
// DI provides AppDbContext
//     ↓
// AppDbContext uses EF Core + SQLite