using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Data;
using Portfolio.Models;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly PortfolioDbContext _context;
    public ContactController(PortfolioDbContext context)
    {
        _context = context;
        
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] ContactMessage message)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

    
        _context.ContactMessages.Add(message);
        await _context.SaveChangesAsync();

        return Ok(); 
    }
}
