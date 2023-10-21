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
                CopeStrategyName = "Deep Breathing",
                CopeStrategyContent = "Sit comfortably and place one hand on your abdomen. Breathe in through your nose, deeply enough that the hand on your abdomen rises. Hold the air in your lungs, and then exhale slowly through your mouth, with your lips puckered as if you are blowing out through a straw. Time the inhalation (4s), pause (4s), and exhalation (6s). Practice for 3 to 5 minutes."
            },
            new CopeStrategy
            {
                Id = 2,
                CopeStrategyName = "Progressive Muscle Relaxation",
                CopeStrategyContent = "By tensing and relaxing the muscles throughout your body, you can acheive a powerful feeling of relaxation. Additionally, progressive muscle relaxation will help you spot anxiety by teaching you to recognize feelings of muscle tension. Sit back in a comfortable position. You will tense your muscles tightly, but not to the point of strain. Hold the tension for 10 seconds and pay close attention to how it feels. Then, release the tension, and notice how the feeling of relaxation differs from the feeling of tension. Day 1 (feet, calves, thighs), Day 2 (back, shoulders, arms), Day 3 (hands, face, full body)"
            },
            new CopeStrategy
            {
                Id = 3,
                CopeStrategyName = "Imagery",
                CopeStrategyContent = "Your thoughts have the power to change how you feel. If you think of something sad, it's likely you'll start to feel sad. The opposite is also true: When you think of something positive and calming, you feel relaxed. The imagery technique harnesses this power to reduce anxiety. Think of a place that you find comforting. For 5 to 10 minutes, use all your senses to imagine this setting in great detail. Don't just think fleetingly about this place--really imagine it (hit all 5 sense in your description - what do you see at the place, what do your hear, what do you smell, what could you feel there, what would you be eating or drinking there)."
            },
            new CopeStrategy
            {
                Id = 4,
                CopeStrategyName = "Meditation",
                //try to implement some sort of embeded YouTube video here maybe?
                CopeStrategyContent = "Here are some examples of guided meditation."
            },
            new CopeStrategy
            {
                Id = 5,
                CopeStrategyName = "Gratitude",
                CopeStrategyContent = "Write 10 things every day that you are grateful for, consider sharing those with a loved one."
            },
            new CopeStrategy
            {
                Id = 6,
                CopeStrategyName = "Energy Redirection",
                CopeStrategyContent = "Do 10 pushups or 10 jumping jacks. This can help to expend any anxiety by redirecting your nervous system to positively channel that energy."
            },
            new CopeStrategy
            {
                Id = 7,
                CopeStrategyName = "3-3-3",
                CopeStrategyContent = "Name 3 things you can see, 3 sounds you can hear, and then name 3 things with different texture around you."
            },
            new CopeStrategy
            {
                Id = 8,
                CopeStrategyName = "Changing Endorphins",
                CopeStrategyContent = "Tell a joke(they can be a little inappropriate if you like :D)"
            },
            new CopeStrategy
            {
                Id = 9,
                CopeStrategyName = "Increasing Endorphins",
                CopeStrategyContent = "Name 2 things you are proud of yourself for."
            },
            new CopeStrategy
            {
                Id = 10,
                CopeStrategyName = "Nervous System Regulation: Butterfly hug",
                CopeStrategyContent = "Clasp your hands together and gently tap on your chest one side at a time for 2 minutes. Focus on your breathing."
            },
            new CopeStrategy
            {
                Id = 11,
                CopeStrategyName = "Nervous System Regulation: Pysiological Sigh",
                CopeStrategyContent = "Take a big, deep, long breath in - do another short breath at the top - then breath out. Repeat for 10 cycles."
            },
            new CopeStrategy
            {
                Id = 12,
                CopeStrategyName = "Neuro Tapping",
                CopeStrategyContent = "This uses energy points to turn off the brain's alarm system. We will tap 10 times at each point. First point is the side of your hand(one hand horizontal, the other vertical - the horizontal hand will be tapping on the vertical one), second point is the eyebrow in the middle of the head using one hands, third point is the sides of the eyebrows using one hand on each side, fourth point is under the eyes at the cheek bone, fifth point is one hand under the nose with one hand, sixth point is on the chin with one hand."
            },
            new CopeStrategy
            {
                Id = 13,
                CopeStrategyName = "Mantras",
                CopeStrategyContent = "Saying a phrase that helps calm us. 'I am okay.' 'I am safe.' 'This will pass.' 'I have come a long way.' 'I will succeed.'"
            },
            new CopeStrategy
            {
                Id = 14,
                CopeStrategyName = "Seated Stretches",
                CopeStrategyContent = "Go to YouTube and find a guide to seated stretches. Find a place with a secure seat and practice some of these stretches for 5 to 10 minutes a day."
            },
            new CopeStrategy
            {
                Id = 15,
                CopeStrategyName = "5-4-3-2-1",
                CopeStrategyContent = "Find five things you can see, four things you can touch, three things you can hear, two things you can smell, and one thing you can taste."
            },
            new CopeStrategy
            {
                Id = 16,
                CopeStrategyName = "Creating Endorpins - Categories",
                CopeStrategyContent = "Think of a category that you can name at least 10 items in, these might include songs, sports, dog breeds, cities, etc."
            },
            new CopeStrategy
            {
                Id = 17,
                CopeStrategyName = "Back to Basics",
                CopeStrategyContent = "Describe an everyday activity in great detail, for example: Cooking breakfast - first I pick out ingredients from the fridge, then I pull out my pan, then I turn on the stove, etc.  Pick an activity you feel like you can describe in great detail."
            },
            new CopeStrategy
            {
                Id = 18,
                CopeStrategyName = "Wash",
                CopeStrategyContent = "Running water over your hands can help to regulate your nervous system, try either washing your hands or just running water over them for at least 30 seconds, 5 - 10 times a day."
            },
            new CopeStrategy
            {
                Id = 19,
                CopeStrategyName = "Grounding Objects",
                CopeStrategyContent = "Identify a grounding object, this could be a piece of jewelry you often wear or something as simple as a nicely textured rock or piece of fabric. Whenever you are starting to feel overwhelmed by negative emotions, trauma triggers, or anxiety, touch your grounding object to help you stay rooted in the present"
            },
            new CopeStrategy
            {
                Id = 20,
                CopeStrategyName = "Coloring Therapy",
                CopeStrategyContent = "Color in a coloring book for 10 minutes. Let your mind focus on the colors and your creativity to help relax your mind."
            },
            new CopeStrategy
            {
                Id = 21,
                CopeStrategyName = "Laughter Therapy",
                CopeStrategyContent = "Watch a funny stand-up comedy show or humorous videos online to make yourself laugh and revel in the laughter."
            },
            new CopeStrategy
            {
                Id = 22,
                CopeStrategyName = "Nature Walk",
                CopeStrategyContent = "Take a leisurely walk in a nearby park or forest. Connect with nature and breath the fresh air around you."
            },
            new CopeStrategy
            {
                Id = 23,
                CopeStrategyName = "Remember a Safe Place",
                CopeStrategyContent = "Describe a place that you find very soothing(example: the beach - the sounds, colors, shapes, textures)"
            },
            new CopeStrategy
            {
                Id = 24,
                CopeStrategyName = "Aromatherapy",
                CopeStrategyContent = "Using essential oils like lavender or eucalyptus in a diffuser to create a calming and soothing atmosphere in your space."
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