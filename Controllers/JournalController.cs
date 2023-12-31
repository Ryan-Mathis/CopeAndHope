using CopeAndHope.Data;
using CopeAndHope.Models;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("user/{userId}")]
    [Authorize]
    public IActionResult GetCurrentUserJournals(int userId)
    {
        return Ok(_dbContext.CopeJournals
        .Include(j => j.CopeStrategy)
        .Include(j => j.CopeEmotions)
        .ThenInclude(ce => ce.Emotion)
        .Where(j => j.UserProfileId == userId)
        .OrderBy(j => j.LastUpdated)
        .ToList());
    }

    [HttpGet("{journalId}")]
    [Authorize]
    public IActionResult GetJournalById(int journalId)
    {
        return Ok(_dbContext.CopeJournals
        .Include(j => j.CopeStrategy)
        .Include(j => j.UserProfile)
        .Include(j => j.CopeEmotions)
        .ThenInclude(ce => ce.Emotion)
        .SingleOrDefault(j => j.Id == journalId));
    }

    [HttpPost]
    [Authorize]
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

    [HttpPut("myjournals/{id}")]
    [Authorize]
    public IActionResult EditJournal(int id, CopeJournal copeJournal)
    {

        CopeJournal journalToEdit = _dbContext.CopeJournals.SingleOrDefault(cj => cj.Id == id);

        if (journalToEdit == null)
        {
            return NotFound();
        }

        journalToEdit.JournalText = copeJournal.JournalText;
        journalToEdit.LastUpdated = DateTime.Now;

        List<CopeEmotion> existingCopeEmotions = _dbContext.CopeEmotions
        .Where(ce => ce.CopeJournalId == journalToEdit.Id)
        .ToList();

        foreach (CopeEmotion existingCopeEmotion in existingCopeEmotions)
        {
            if (!copeJournal.CopeEmotions.Any(ce => ce.Id == existingCopeEmotion.Id))
            {
                _dbContext.CopeEmotions.Remove(existingCopeEmotion);
            }
        }

        journalToEdit.CopeEmotions ??= new List<CopeEmotion>();

        foreach (CopeEmotion ce in copeJournal.CopeEmotions)
        {
            ce.Emotion = _dbContext.Emotions.Single(e => e.Id == ce.EmotionId);
            journalToEdit.CopeEmotions.Add(ce);
        }

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]

    public IActionResult DeleteJournal(int id)
    {
        CopeJournal JournalToDelete = _dbContext.CopeJournals.SingleOrDefault(j => j.Id == id);

        if (JournalToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Remove(JournalToDelete);
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpGet("filter")]
    [Authorize]

    public IActionResult getJournalsByEmotionId(int? emotionId)
    {
        //need to find Posts.postTags.Id that match the tagId passed in from the front-end
        return Ok(_dbContext.CopeJournals
        .Include(j => j.CopeStrategy)
        .Include(j => j.UserProfile)
        .Include(j => j.CopeEmotions)
        .ThenInclude(ce => ce.Emotion)
        .Where(j => j.CopeEmotions.Any(ce => ce.EmotionId == emotionId))
        .OrderBy(j => j.JournalDate)
        .ToList());
    }

}