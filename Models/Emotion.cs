using System.ComponentModel.DataAnnotations;

namespace CopeAndHope.Models;

public class Emotion
{
    public int Id { get; set; }
    [Required]
    public string EmotionName { get; set; }
}