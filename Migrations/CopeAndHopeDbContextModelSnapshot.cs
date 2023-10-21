﻿// <auto-generated />
using System;
using CopeAndHope.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CopeAndHope.Migrations
{
    [DbContext(typeof(CopeAndHopeDbContext))]
    partial class CopeAndHopeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CopeAndHope.Models.CopeEmotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CopeJournalId")
                        .HasColumnType("integer");

                    b.Property<int>("EmotionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CopeJournalId");

                    b.HasIndex("EmotionId");

                    b.ToTable("CopeEmotions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CopeJournalId = 1,
                            EmotionId = 1
                        },
                        new
                        {
                            Id = 2,
                            CopeJournalId = 2,
                            EmotionId = 2
                        });
                });

            modelBuilder.Entity("CopeAndHope.Models.CopeJournal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CopeStrategyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("JournalDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("JournalText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CopeStrategyId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("CopeJournals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CopeStrategyId = 3,
                            JournalDate = new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JournalText = "This strategy was a tough one for me to implement...",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 2,
                            CopeStrategyId = 6,
                            JournalDate = new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JournalText = "This strategy was easier for me to implement...",
                            UserProfileId = 1
                        });
                });

            modelBuilder.Entity("CopeAndHope.Models.CopeStrategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CopeStrategyContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CopeStrategyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CopeStrategies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CopeStrategyContent = "Sit comfortably and place one hand on your abdomen. Breathe in through your nose, deeply enough that the hand on your abdomen rises. Hold the air in your lungs, and then exhale slowly through your mouth, with your lips puckered as if you are blowing out through a straw. Time the inhalation (4s), pause (4s), and exhalation (6s). Practice for 3 to 5 minutes.",
                            CopeStrategyName = "Deep Breathing"
                        },
                        new
                        {
                            Id = 2,
                            CopeStrategyContent = "By tensing and relaxing the muscles throughout your body, you can acheive a powerful feeling of relaxation. Additionally, progressive muscle relaxation will help you spot anxiety by teaching you to recognize feelings of muscle tension. Sit back in a comfortable position. You will tense your muscles tightly, but not to the point of strain. Hold the tension for 10 seconds and pay close attention to how it feels. Then, release the tension, and notice how the feeling of relaxation differs from the feeling of tension. Day 1 (feet, calves, thighs), Day 2 (back, shoulders, arms), Day 3 (hands, face, full body)",
                            CopeStrategyName = "Progressive Muscle Relaxation"
                        },
                        new
                        {
                            Id = 3,
                            CopeStrategyContent = "Your thoughts have the power to change how you feel. If you think of something sad, it's likely you'll start to feel sad. The opposite is also true: When you think of something positive and calming, you feel relaxed. The imagery technique harnesses this power to reduce anxiety. Think of a place that you find comforting. For 5 to 10 minutes, use all your senses to imagine this setting in great detail. Don't just think fleetingly about this place--really imagine it (hit all 5 sense in your description - what do you see at the place, what do your hear, what do you smell, what could you feel there, what would you be eating or drinking there).",
                            CopeStrategyName = "Imagery"
                        },
                        new
                        {
                            Id = 4,
                            CopeStrategyContent = "Here are some examples of guided meditation.",
                            CopeStrategyName = "Meditation"
                        },
                        new
                        {
                            Id = 5,
                            CopeStrategyContent = "Write 10 things every day that you are grateful for, consider sharing those with a loved one.",
                            CopeStrategyName = "Gratitude"
                        },
                        new
                        {
                            Id = 6,
                            CopeStrategyContent = "Do 10 pushups or 10 jumping jacks. This can help to expend any anxiety by redirecting your nervous system to positively channel that energy.",
                            CopeStrategyName = "Energy Redirection"
                        },
                        new
                        {
                            Id = 7,
                            CopeStrategyContent = "Name 3 things you can see, 3 sounds you can hear, and then name 3 things with different texture around you.",
                            CopeStrategyName = "3-3-3"
                        },
                        new
                        {
                            Id = 8,
                            CopeStrategyContent = "Tell a joke(they can be a little inappropriate if you like :D)",
                            CopeStrategyName = "Changing Endorphins"
                        },
                        new
                        {
                            Id = 9,
                            CopeStrategyContent = "Name 2 things you are proud of yourself for.",
                            CopeStrategyName = "Increasing Endorphins"
                        },
                        new
                        {
                            Id = 10,
                            CopeStrategyContent = "Clasp your hands together and gently tap on your chest one side at a time for 2 minutes. Focus on your breathing.",
                            CopeStrategyName = "Nervous System Regulation: Butterfly hug"
                        },
                        new
                        {
                            Id = 11,
                            CopeStrategyContent = "Take a big, deep, long breath in - do another short breath at the top - then breath out. Repeat for 10 cycles.",
                            CopeStrategyName = "Nervous System Regulation: Pysiological Sigh"
                        },
                        new
                        {
                            Id = 12,
                            CopeStrategyContent = "This uses energy points to turn off the brain's alarm system. We will tap 10 times at each point. First point is the side of your hand(one hand horizontal, the other vertical - the horizontal hand will be tapping on the vertical one), second point is the eyebrow in the middle of the head using one hands, third point is the sides of the eyebrows using one hand on each side, fourth point is under the eyes at the cheek bone, fifth point is one hand under the nose with one hand, sixth point is on the chin with one hand.",
                            CopeStrategyName = "Neuro Tapping"
                        },
                        new
                        {
                            Id = 13,
                            CopeStrategyContent = "Saying a phrase that helps calm us. 'I am okay.' 'I am safe.' 'This will pass.' 'I have come a long way.' 'I will succeed.'",
                            CopeStrategyName = "Mantras"
                        },
                        new
                        {
                            Id = 14,
                            CopeStrategyContent = "Go to YouTube and find a guide to seated stretches. Find a place with a secure seat and practice some of these stretches for 5 to 10 minutes a day.",
                            CopeStrategyName = "Seated Stretches"
                        },
                        new
                        {
                            Id = 15,
                            CopeStrategyContent = "Find five things you can see, four things you can touch, three things you can hear, two things you can smell, and one thing you can taste.",
                            CopeStrategyName = "5-4-3-2-1"
                        },
                        new
                        {
                            Id = 16,
                            CopeStrategyContent = "Think of a category that you can name at least 10 items in, these might include songs, sports, dog breeds, cities, etc.",
                            CopeStrategyName = "Creating Endorpins - Categories"
                        },
                        new
                        {
                            Id = 17,
                            CopeStrategyContent = "Describe an everyday activity in great detail, for example: Cooking breakfast - first I pick out ingredients from the fridge, then I pull out my pan, then I turn on the stove, etc.  Pick an activity you feel like you can describe in great detail.",
                            CopeStrategyName = "Back to Basics"
                        },
                        new
                        {
                            Id = 18,
                            CopeStrategyContent = "Running water over your hands can help to regulate your nervous system, try either washing your hands or just running water over them for at least 30 seconds, 5 - 10 times a day.",
                            CopeStrategyName = "Wash"
                        },
                        new
                        {
                            Id = 19,
                            CopeStrategyContent = "Identify a grounding object, this could be a piece of jewelry you often wear or something as simple as a nicely textured rock or piece of fabric. Whenever you are starting to feel overwhelmed by negative emotions, trauma triggers, or anxiety, touch your grounding object to help you stay rooted in the present",
                            CopeStrategyName = "Grounding Objects"
                        },
                        new
                        {
                            Id = 20,
                            CopeStrategyContent = "Color in a coloring book for 10 minutes. Let your mind focus on the colors and your creativity to help relax your mind.",
                            CopeStrategyName = "Coloring Therapy"
                        },
                        new
                        {
                            Id = 21,
                            CopeStrategyContent = "Watch a funny stand-up comedy show or humorous videos online to make yourself laugh and revel in the laughter.",
                            CopeStrategyName = "Laughter Therapy"
                        },
                        new
                        {
                            Id = 22,
                            CopeStrategyContent = "Take a leisurely walk in a nearby park or forest. Connect with nature and breath the fresh air around you.",
                            CopeStrategyName = "Nature Walk"
                        },
                        new
                        {
                            Id = 23,
                            CopeStrategyContent = "Describe a place that you find very soothing(example: the beach - the sounds, colors, shapes, textures)",
                            CopeStrategyName = "Remember a Safe Place"
                        },
                        new
                        {
                            Id = 24,
                            CopeStrategyContent = "Using essential oils like lavender or eucalyptus in a diffuser to create a calming and soothing atmosphere in your space.",
                            CopeStrategyName = "Aromatherapy"
                        });
                });

            modelBuilder.Entity("CopeAndHope.Models.Emotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("EmotionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Emotions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmotionName = "Hopeful"
                        },
                        new
                        {
                            Id = 2,
                            EmotionName = "Empowered"
                        },
                        new
                        {
                            Id = 3,
                            EmotionName = "Optimistic"
                        },
                        new
                        {
                            Id = 4,
                            EmotionName = "Calm"
                        },
                        new
                        {
                            Id = 5,
                            EmotionName = "Gracious"
                        },
                        new
                        {
                            Id = 6,
                            EmotionName = "Joyful"
                        });
                });

            modelBuilder.Entity("CopeAndHope.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Admina",
                            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            LastName = "Strator"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Ryan",
                            IdentityUserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                            LastName = "Mathis"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Ethan",
                            IdentityUserId = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                            LastName = "Mathis"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Simone",
                            IdentityUserId = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                            LastName = "Henderson"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Bob",
                            IdentityUserId = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                            LastName = "Williams"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Eve",
                            IdentityUserId = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                            LastName = "Davis"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                            ConcurrencyStamp = "70b09414-fb74-4ba0-9c43-d7890fd95289",
                            Name = "Admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d5044a8d-7dc2-49c3-9b6c-e40a37a3ad1f",
                            Email = "admina@strator.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEEKOtqqaONl46lGoGi48L57g/mWnIqFZV+RRMpcRnbISeI22xQ49pvaLvOjEh900EA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c17771c4-aa3b-4b41-889b-dbca225ab377",
                            TwoFactorEnabled = false,
                            UserName = "Administrator"
                        },
                        new
                        {
                            Id = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c02c30e4-3a6d-42b2-9669-15e12f0b9f65",
                            Email = "ryan@mathis.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEDqmeG4WmME9+rluZFXc4P7UaCCnjdi7ISnZV4DLWlkHngEnrKCd3laFo89QyWghHg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4220b793-2f22-4cae-881a-87eb4094c279",
                            TwoFactorEnabled = false,
                            UserName = "RyanMathis"
                        },
                        new
                        {
                            Id = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e71c2c45-c13e-4fee-ab01-2413c9597c28",
                            Email = "ethan@mathis.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEO6xVrNJ9hkEURIbMHvVK5T8hbRLVELlxYdoA753dsobBs3xAoff5Xz+oYZLIe1fVw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cbc6bec4-c52c-446d-bacc-af174b2be9ec",
                            TwoFactorEnabled = false,
                            UserName = "EthanMathis"
                        },
                        new
                        {
                            Id = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "413682ff-8220-4a86-bf84-d63f76e44274",
                            Email = "simone@henderson.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEM193gkur22PMh68r1IlKYeFTITotiLQNXfaeKszT9PqyPnpp8sYEm6YZHtGUMHJFA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "385e2999-40a2-45a1-aa37-d70cb557bcb4",
                            TwoFactorEnabled = false,
                            UserName = "SimoneHenderson"
                        },
                        new
                        {
                            Id = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7ab80fcc-22ec-49db-99ee-2cbd01ee39ea",
                            Email = "bob@williams.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEGAlB1um8TtR4CmG+uzD6vZJ3UG1aRjGKtmlshyp0L+ilvr8kRM24WCDOeLh6Y4QNg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2e04dec8-d4f7-4ac0-86d3-56ae7d4dec19",
                            TwoFactorEnabled = false,
                            UserName = "BobWilliams"
                        },
                        new
                        {
                            Id = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fbce4d8c-4da2-4595-88d4-0029de5b1cd0",
                            Email = "Eve@Davis.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEB6h6rhKrDz4YWWFjlrNCUteSMAwgmRl7BUubArX6HColZLMvbnBThmEsaOyZBddmw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5f0c029d-2ee2-4917-8e05-25e43243d653",
                            TwoFactorEnabled = false,
                            UserName = "EveDavis"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35"
                        },
                        new
                        {
                            UserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CopeAndHope.Models.CopeEmotion", b =>
                {
                    b.HasOne("CopeAndHope.Models.CopeJournal", "CopeJournal")
                        .WithMany("CopeEmotions")
                        .HasForeignKey("CopeJournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CopeAndHope.Models.Emotion", "Emotion")
                        .WithMany()
                        .HasForeignKey("EmotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CopeJournal");

                    b.Navigation("Emotion");
                });

            modelBuilder.Entity("CopeAndHope.Models.CopeJournal", b =>
                {
                    b.HasOne("CopeAndHope.Models.CopeStrategy", "CopeStrategy")
                        .WithMany("CopeJournals")
                        .HasForeignKey("CopeStrategyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CopeAndHope.Models.UserProfile", "UserProfile")
                        .WithMany("CopeJournals")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CopeStrategy");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("CopeAndHope.Models.UserProfile", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CopeAndHope.Models.CopeJournal", b =>
                {
                    b.Navigation("CopeEmotions");
                });

            modelBuilder.Entity("CopeAndHope.Models.CopeStrategy", b =>
                {
                    b.Navigation("CopeJournals");
                });

            modelBuilder.Entity("CopeAndHope.Models.UserProfile", b =>
                {
                    b.Navigation("CopeJournals");
                });
#pragma warning restore 612, 618
        }
    }
}
