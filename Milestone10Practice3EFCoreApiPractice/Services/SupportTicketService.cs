namespace Milestone10Practice3EFCoreApiPractice.Services;
using Microsoft.EntityFrameworkCore;
using Milestone10Practice3EFCoreApiPractice.Models;
using Milestone10Practice3EFCoreApiPractice.Data;

public class SupportTicketService
{
    private readonly AppDbContext _context;

    public SupportTicketService(AppDbContext context)
    {
        _context = context;
    }
    // SupportTicketService -> needs AppDbContext -> DI provides it

    public async Task<List<SupportTicket>> GetAllAsync()
    {
        return await _context.SupportTickets.ToListAsync();
    }
    
    // get by id
    public async Task<SupportTicket?> GetByIdAsync(int id)
    {
        return await _context.SupportTickets
            .FirstOrDefaultAsync(t => t.Id == id);
    }
    
    // create
    public async Task<SupportTicket> CreateAsync(SupportTicket ticket)
    {
        _context.SupportTickets.Add(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }
    
    
}