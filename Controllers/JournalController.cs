using CopeAndHope.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CopeAndHope.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JournalController : ControllerBase
{
    private CopeAndHopeDbContext _dbContext;
    public JournalController(CopeAndHopeDbContext context)
    {
        _dbContext = context;
    }
    [HttpGet("{userId}")]
    public IActionResult GetCurrentUserJournals(int userId)
    {
        return Ok(_dbContext.CopeJournals
        .Include(j => j.CopeStrategy)
        .Include(j => j.UserProfile)
        .Include(j => j.CopeEmotions)
        .ThenInclude(ce => ce.Emotion)
        .Where(j => j.UserProfileId == userId)
        .OrderBy(j => j.LastUpdated)
        .ToList());
    }
}