using CopeAndHope.Data;
using CopeAndHope.Models;
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

    [HttpPost]
    public IActionResult CreateNewJournal(CopeJournal copeJournal)
    {
        copeJournal.JournalDate = DateTime.Now;
        
        List<CopeEmotion> copeEmotions = new List<CopeEmotion>();

        foreach (CopeEmotion ce in copeJournal.CopeEmotions)
        {
            ce.Emotion = _dbContext.Emotions.Single(e => e.Id == ce.EmotionId);
            copeEmotions.Add(ce);
        }

        copeJournal.CopeEmotions = copeEmotions;

        _dbContext.CopeJournals.Add(copeJournal);
        _dbContext.SaveChanges();

        return Created($"/api/journal/myjournals/{copeJournal.Id}", copeJournal);
    }
}