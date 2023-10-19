using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CopeAndHope.Models;
using Microsoft.AspNetCore.Identity;


namespace CopeAndHope.Data;
public class CopeAndHopeDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<CopeStrategy> CopeStrategies { get; set; }
    public DbSet<Emotion> Emotions { get; set; }
    public DbSet<CopeEmotion> CopeEmotions { get; set; }
    public DbSet<CopeJournal> CopeJournals { get; set; }

    public CopeAndHopeDbContext(DbContextOptions<CopeAndHopeDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
        {
            new IdentityUser
            {
                Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                UserName = "Administrator",
                Email = "admina@strator.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                UserName = "RyanMathis",
                Email = "ryan@mathis.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                UserName = "EthanMathis",
                Email = "ethan@mathis.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                UserName = "SimoneHenderson",
                Email = "simone@henderson.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                UserName = "BobWilliams",
                Email = "bob@williams.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                UserName = "EveDavis",
                Email = "Eve@Davis.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            }
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
        {
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
            },
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df"
            },
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile
            {
                Id = 1,
                FirstName = "Admina",
                LastName = "Strator",
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            },
             new UserProfile
            {
                Id = 2,
                FirstName = "Ryan",
                LastName = "Mathis",
                IdentityUserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
            },
            new UserProfile
            {
                Id = 3,
                FirstName = "Ethan",
                LastName = "Mathis",
                IdentityUserId = "a7d21fac-3b21-454a-a747-075f072d0cf3",
            },
            new UserProfile
            {
                Id = 4,
                FirstName = "Simone",
                LastName = "Henderson",
                IdentityUserId = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
            },
            new UserProfile
            {
                Id = 5,
                FirstName = "Bob",
                LastName = "Williams",
                IdentityUserId = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
            },
            new UserProfile
            {
                Id = 6,
                FirstName = "Eve",
                LastName = "Davis",
                IdentityUserId = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
            }
        });

        modelBuilder.Entity<CopeStrategy>().HasData(new CopeStrategy[]
        {
            new CopeStrategy
            {
                Id = 1,
                CopeStrategyText = "Example Coping Strategy 1"
            },
            new CopeStrategy
            {
                Id = 2,
                CopeStrategyText = "Example Coping Strategy 2"
            },
            new CopeStrategy
            {
                Id = 3,
                CopeStrategyText = "Example Coping Strategy 3"
            },
            new CopeStrategy
            {
                Id = 4,
                CopeStrategyText = "Example Coping Strategy 4"
            },
            new CopeStrategy
            {
                Id = 5,
                CopeStrategyText = "Example Coping Strategy 5"
            },
            new CopeStrategy
            {
                Id = 6,
                CopeStrategyText = "Example Coping Strategy 6"
            },
            new CopeStrategy
            {
                Id = 7,
                CopeStrategyText = "Example Coping Strategy 7"
            },
            new CopeStrategy
            {
                Id = 8,
                CopeStrategyText = "Example Coping Strategy 8"
            },
            new CopeStrategy
            {
                Id = 9,
                CopeStrategyText = "Example Coping Strategy 9"
            },
            new CopeStrategy
            {
                Id = 10,
                CopeStrategyText = "Example Coping Strategy 10"
            },
            new CopeStrategy
            {
                Id = 11,
                CopeStrategyText = "Example Coping Strategy 11"
            },
            new CopeStrategy
            {
                Id = 12,
                CopeStrategyText = "Example Coping Strategy 12"
            },
            new CopeStrategy
            {
                Id = 13,
                CopeStrategyText = "Example Coping Strategy 13"
            },
            new CopeStrategy
            {
                Id = 14,
                CopeStrategyText = "Example Coping Strategy 14"
            },
            new CopeStrategy
            {
                Id = 15,
                CopeStrategyText = "Example Coping Strategy 15"
            },
            new CopeStrategy
            {
                Id = 16,
                CopeStrategyText = "Example Coping Strategy 16"
            },
            new CopeStrategy
            {
                Id = 17,
                CopeStrategyText = "Example Coping Strategy 17"
            },
            new CopeStrategy
            {
                Id = 18,
                CopeStrategyText = "Example Coping Strategy 18"
            },
            new CopeStrategy
            {
                Id = 19,
                CopeStrategyText = "Example Coping Strategy 19"
            },
            new CopeStrategy
            {
                Id = 20,
                CopeStrategyText = "Example Coping Strategy 20"
            },
            new CopeStrategy
            {
                Id = 21,
                CopeStrategyText = "Example Coping Strategy 21"
            },
            new CopeStrategy
            {
                Id = 22,
                CopeStrategyText = "Example Coping Strategy 22"
            },
            new CopeStrategy
            {
                Id = 23,
                CopeStrategyText = "Example Coping Strategy 23"
            },
            new CopeStrategy
            {
                Id = 24,
                CopeStrategyText = "Example Coping Strategy 24"
            },
            new CopeStrategy
            {
                Id = 25,
                CopeStrategyText = "Example Coping Strategy 25"
            },
            new CopeStrategy
            {
                Id = 26,
                CopeStrategyText = "Example Coping Strategy 26"
            },
            new CopeStrategy
            {
                Id = 27,
                CopeStrategyText = "Example Coping Strategy 27"
            },
            new CopeStrategy
            {
                Id = 28,
                CopeStrategyText = "Example Coping Strategy 28"
            },
            new CopeStrategy
            {
                Id = 29,
                CopeStrategyText = "Example Coping Strategy 29"
            },
            new CopeStrategy
            {
                Id = 30,
                CopeStrategyText = "Example Coping Strategy 30"
            },
            new CopeStrategy
            {
                Id = 31,
                CopeStrategyText = "Example Coping Strategy 31"
            }
        });

        modelBuilder.Entity<Emotion>().HasData(new Emotion[]
        {
            new Emotion
            {
                Id = 1,
                EmotionName = "Hopeful"
            },
            new Emotion
            {
                Id = 2,
                EmotionName = "Empowered"
            },
            new Emotion
            {
                Id = 3,
                EmotionName = "Optimistic"
            },
            new Emotion
            {
                Id = 4,
                EmotionName = "Calm"
            },
            new Emotion
            {
                Id = 5,
                EmotionName = "Gracious"
            },
            new Emotion
            {
                Id = 6,
                EmotionName = "Joyful"
            }
        });

        modelBuilder.Entity<CopeEmotion>().HasData(new CopeEmotion[]
        {
            new CopeEmotion
            {
                Id = 1,
                EmotionId = 1,
                CopeJournalId = 1
            },
            new CopeEmotion
            {
                Id = 2,
                EmotionId = 2,
                CopeJournalId = 2
            }
        });

        modelBuilder.Entity<CopeJournal>().HasData(new CopeJournal[]
        {
            new CopeJournal
            {
                Id = 1,
                JournalText = "This strategy was a tough one for me to implement...",
                JournalDate = new DateTime(2023, 10, 15),
                UserProfileId = 1,
                CopeStrategyId = 3,
            },
            new CopeJournal
            {
                Id = 2,
                JournalText = "This strategy was easier for me to implement...",
                JournalDate = new DateTime(2023, 10, 17),
                UserProfileId = 1,
                CopeStrategyId = 6
            },
        });
    }
}