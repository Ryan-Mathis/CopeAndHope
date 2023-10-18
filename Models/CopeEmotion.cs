using System.ComponentModel.DataAnnotations;

namespace CopeAndHope.Models;

public class CopeEmotion
{
    public int Id { get; set; }
    [Required]
    public int EmotionId { get; set; }
    public Emotion Emotion { get; set;}
    [Required]
    public int CopeJournalId { get; set; }
    public CopeJournal CopeJournal { get; set;}
}