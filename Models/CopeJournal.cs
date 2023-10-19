using System.ComponentModel.DataAnnotations;

namespace CopeAndHope.Models;

public class CopeJournal
{
    public int Id { get; set; }
    [Required]
    public string JournalText { get; set; }
    public DateTime JournalDate { get; set; }
    public DateTime? LastUpdated { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public int CopeStrategyId { get; set; }
    public CopeStrategy CopeStrategy { get; set; }
    public List<CopeEmotion> CopeEmotions { get; set; }
}

