using System.Security.Claims;
using CopeAndHope.Data;
using CopeAndHope.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CopeAndHope.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CopeStrategyController : ControllerBase
{
    private CopeAndHopeDbContext _dbContext;
    public CopeStrategyController(CopeAndHopeDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("{copeStrategyId}")]
    public IActionResult GetCopeStrategyById(int copeStrategyId)
    {
        return Ok(_dbContext.CopeStrategies.SingleOrDefault(cs => cs.Id == copeStrategyId));
    }

    // [HttpGet("user/{userId}")]
    // public IActionResult GetCopeStrategiesByUserId(int userId)
    // {
    //     List<CopeStrategy> copeStrategies = _dbContext.CopeStrategies
    //     .Include(cs => cs.CopeJournals)
    //     .Where(cs => cs.CopeJournals.Any(cj => cj.UserProfileId == userId)).ToList();
    //     if (copeStrategies == null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(copeStrategies);
    // }

    [HttpGet("active/{userId}")]
    public IActionResult GetActiveCopeStrategyByUserId(int userId)
    {
        DateTime threeDaysAgo = DateTime.Now.AddDays(-3);

        CopeStrategy activeCopeStrategy = _dbContext.CopeStrategies
            .Include(cs => cs.CopeJournals)
            .Where(cs => cs.CopeJournals
                .Any(cj => cj.UserProfileId == userId && cj.JournalDate >= threeDaysAgo))
            .OrderByDescending(cs => cs.CopeJournals
            .Max(cj => cj.JournalDate))
            .FirstOrDefault();

        if (activeCopeStrategy == null)
        {
            return NotFound();
        }

        bool hasOlderJournals = _dbContext.CopeJournals
            .Any(cj => cj.UserProfileId == userId && cj.CopeStrategyId == activeCopeStrategy.Id && cj.JournalDate < threeDaysAgo);

        if (hasOlderJournals == false)
        {
            return Ok(activeCopeStrategy);
        }
        else
        {
            return NotFound("There are older journal entries.");
        }
    }

    [HttpGet("unused/{userId}")]
    public IActionResult GetUnusedCopeStrategies(int userId)
    {
        List<CopeStrategy> copeStrategiesUsedByCurrentUser = _dbContext.CopeStrategies
        .Include(cs => cs.CopeJournals)
        .Where(cs => cs.CopeJournals.Any(cj => cj.UserProfileId == userId))
        .ToList();

        List<CopeStrategy> unusedCopeStrategies = _dbContext.CopeStrategies
        .Where(cs => !copeStrategiesUsedByCurrentUser.Contains(cs))
        .ToList();

        return Ok(unusedCopeStrategies);
    }
}