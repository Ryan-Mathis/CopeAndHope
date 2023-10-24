using CopeAndHope.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CopeAndHope.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmotionController : ControllerBase
{
    private CopeAndHopeDbContext _dbContext;
    public EmotionController(CopeAndHopeDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult GetEmotions()
    {
        return Ok(_dbContext.Emotions.ToList());
    }
}