using System.ComponentModel.DataAnnotations;

namespace CopeAndHope.Models;

public class CopeStrategy
{
    public int Id { get; set; }
    [Required]
    public string CopeStrategyText { get; set; }
    public List<CopeJournal> CopeJournals { get; set; }
}