using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CopeAndHope.Models;

public class UserProfile
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [NotMapped] // not mapped means that EF Core won't create column for this property in the db
    public string Email { get; set; }

    [NotMapped]
    public string UserName { get; set; }

    [NotMapped]
    public List<string> Roles { get; set; }

    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }

    public List<CopeJournal> CopeJournals { get; set; }
}