using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CopeAndHope.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CopeStrategies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CopeStrategyName = table.Column<string>(type: "text", nullable: false),
                    CopeStrategyContent = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopeStrategies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmotionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CopeJournals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JournalText = table.Column<string>(type: "text", nullable: false),
                    JournalDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    CopeStrategyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopeJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CopeJournals_CopeStrategies_CopeStrategyId",
                        column: x => x.CopeStrategyId,
                        principalTable: "CopeStrategies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CopeJournals_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CopeEmotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmotionId = table.Column<int>(type: "integer", nullable: false),
                    CopeJournalId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopeEmotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CopeEmotions_CopeJournals_CopeJournalId",
                        column: x => x.CopeJournalId,
                        principalTable: "CopeJournals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CopeEmotions_Emotions_EmotionId",
                        column: x => x.EmotionId,
                        principalTable: "Emotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "70b09414-fb74-4ba0-9c43-d7890fd95289", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9ce89d88-75da-4a80-9b0d-3fe58582b8e2", 0, "7ab80fcc-22ec-49db-99ee-2cbd01ee39ea", "bob@williams.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEGAlB1um8TtR4CmG+uzD6vZJ3UG1aRjGKtmlshyp0L+ilvr8kRM24WCDOeLh6Y4QNg==", null, false, "2e04dec8-d4f7-4ac0-86d3-56ae7d4dec19", false, "BobWilliams" },
                    { "a7d21fac-3b21-454a-a747-075f072d0cf3", 0, "e71c2c45-c13e-4fee-ab01-2413c9597c28", "ethan@mathis.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEO6xVrNJ9hkEURIbMHvVK5T8hbRLVELlxYdoA753dsobBs3xAoff5Xz+oYZLIe1fVw==", null, false, "cbc6bec4-c52c-446d-bacc-af174b2be9ec", false, "EthanMathis" },
                    { "c806cfae-bda9-47c5-8473-dd52fd056a9b", 0, "413682ff-8220-4a86-bf84-d63f76e44274", "simone@henderson.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEM193gkur22PMh68r1IlKYeFTITotiLQNXfaeKszT9PqyPnpp8sYEm6YZHtGUMHJFA==", null, false, "385e2999-40a2-45a1-aa37-d70cb557bcb4", false, "SimoneHenderson" },
                    { "d224a03d-bf0c-4a05-b728-e3521e45d74d", 0, "fbce4d8c-4da2-4595-88d4-0029de5b1cd0", "Eve@Davis.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEB6h6rhKrDz4YWWFjlrNCUteSMAwgmRl7BUubArX6HColZLMvbnBThmEsaOyZBddmw==", null, false, "5f0c029d-2ee2-4917-8e05-25e43243d653", false, "EveDavis" },
                    { "d8d76512-74f1-43bb-b1fd-87d3a8aa36df", 0, "c02c30e4-3a6d-42b2-9669-15e12f0b9f65", "ryan@mathis.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEDqmeG4WmME9+rluZFXc4P7UaCCnjdi7ISnZV4DLWlkHngEnrKCd3laFo89QyWghHg==", null, false, "4220b793-2f22-4cae-881a-87eb4094c279", false, "RyanMathis" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "d5044a8d-7dc2-49c3-9b6c-e40a37a3ad1f", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEEKOtqqaONl46lGoGi48L57g/mWnIqFZV+RRMpcRnbISeI22xQ49pvaLvOjEh900EA==", null, false, "c17771c4-aa3b-4b41-889b-dbca225ab377", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "CopeStrategies",
                columns: new[] { "Id", "CopeStrategyContent", "CopeStrategyName" },
                values: new object[,]
                {
                    { 1, "Sit comfortably and place one hand on your abdomen. Breathe in through your nose, deeply enough that the hand on your abdomen rises. Hold the air in your lungs, and then exhale slowly through your mouth, with your lips puckered as if you are blowing out through a straw. Time the inhalation (4s), pause (4s), and exhalation (6s). Practice for 3 to 5 minutes.", "Deep Breathing" },
                    { 2, "By tensing and relaxing the muscles throughout your body, you can acheive a powerful feeling of relaxation. Additionally, progressive muscle relaxation will help you spot anxiety by teaching you to recognize feelings of muscle tension. Sit back in a comfortable position. You will tense your muscles tightly, but not to the point of strain. Hold the tension for 10 seconds and pay close attention to how it feels. Then, release the tension, and notice how the feeling of relaxation differs from the feeling of tension. Day 1 (feet, calves, thighs), Day 2 (back, shoulders, arms), Day 3 (hands, face, full body)", "Progressive Muscle Relaxation" },
                    { 3, "Your thoughts have the power to change how you feel. If you think of something sad, it's likely you'll start to feel sad. The opposite is also true: When you think of something positive and calming, you feel relaxed. The imagery technique harnesses this power to reduce anxiety. Think of a place that you find comforting. For 5 to 10 minutes, use all your senses to imagine this setting in great detail. Don't just think fleetingly about this place--really imagine it (hit all 5 sense in your description - what do you see at the place, what do your hear, what do you smell, what could you feel there, what would you be eating or drinking there).", "Imagery" },
                    { 4, "Here are some examples of guided meditation.", "Meditation" },
                    { 5, "Write 10 things every day that you are grateful for, consider sharing those with a loved one.", "Gratitude" },
                    { 6, "Do 10 pushups or 10 jumping jacks. This can help to expend any anxiety by redirecting your nervous system to positively channel that energy.", "Energy Redirection" },
                    { 7, "Name 3 things you can see, 3 sounds you can hear, and then name 3 things with different texture around you.", "3-3-3" },
                    { 8, "Tell a joke(they can be a little inappropriate if you like :D)", "Changing Endorphins" },
                    { 9, "Name 2 things you are proud of yourself for.", "Increasing Endorphins" },
                    { 10, "Clasp your hands together and gently tap on your chest one side at a time for 2 minutes. Focus on your breathing.", "Nervous System Regulation: Butterfly hug" },
                    { 11, "Take a big, deep, long breath in - do another short breath at the top - then breath out. Repeat for 10 cycles.", "Nervous System Regulation: Pysiological Sigh" },
                    { 12, "This uses energy points to turn off the brain's alarm system. We will tap 10 times at each point. First point is the side of your hand(one hand horizontal, the other vertical - the horizontal hand will be tapping on the vertical one), second point is the eyebrow in the middle of the head using one hands, third point is the sides of the eyebrows using one hand on each side, fourth point is under the eyes at the cheek bone, fifth point is one hand under the nose with one hand, sixth point is on the chin with one hand.", "Neuro Tapping" },
                    { 13, "Saying a phrase that helps calm us. 'I am okay.' 'I am safe.' 'This will pass.' 'I have come a long way.' 'I will succeed.'", "Mantras" },
                    { 14, "Go to YouTube and find a guide to seated stretches. Find a place with a secure seat and practice some of these stretches for 5 to 10 minutes a day.", "Seated Stretches" },
                    { 15, "Find five things you can see, four things you can touch, three things you can hear, two things you can smell, and one thing you can taste.", "5-4-3-2-1" },
                    { 16, "Think of a category that you can name at least 10 items in, these might include songs, sports, dog breeds, cities, etc.", "Creating Endorpins - Categories" },
                    { 17, "Describe an everyday activity in great detail, for example: Cooking breakfast - first I pick out ingredients from the fridge, then I pull out my pan, then I turn on the stove, etc.  Pick an activity you feel like you can describe in great detail.", "Back to Basics" },
                    { 18, "Running water over your hands can help to regulate your nervous system, try either washing your hands or just running water over them for at least 30 seconds, 5 - 10 times a day.", "Wash" },
                    { 19, "Identify a grounding object, this could be a piece of jewelry you often wear or something as simple as a nicely textured rock or piece of fabric. Whenever you are starting to feel overwhelmed by negative emotions, trauma triggers, or anxiety, touch your grounding object to help you stay rooted in the present", "Grounding Objects" },
                    { 20, "Color in a coloring book for 10 minutes. Let your mind focus on the colors and your creativity to help relax your mind.", "Coloring Therapy" },
                    { 21, "Watch a funny stand-up comedy show or humorous videos online to make yourself laugh and revel in the laughter.", "Laughter Therapy" },
                    { 22, "Take a leisurely walk in a nearby park or forest. Connect with nature and breath the fresh air around you.", "Nature Walk" },
                    { 23, "Describe a place that you find very soothing(example: the beach - the sounds, colors, shapes, textures)", "Remember a Safe Place" },
                    { 24, "Using essential oils like lavender or eucalyptus in a diffuser to create a calming and soothing atmosphere in your space.", "Aromatherapy" }
                });

            migrationBuilder.InsertData(
                table: "Emotions",
                columns: new[] { "Id", "EmotionName" },
                values: new object[,]
                {
                    { 1, "Hopeful" },
                    { 2, "Empowered" },
                    { 3, "Optimistic" },
                    { 4, "Calm" },
                    { 5, "Gracious" },
                    { 6, "Joyful" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "d8d76512-74f1-43bb-b1fd-87d3a8aa36df" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "FirstName", "IdentityUserId", "LastName" },
                values: new object[,]
                {
                    { 1, "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Strator" },
                    { 2, "Ryan", "d8d76512-74f1-43bb-b1fd-87d3a8aa36df", "Mathis" },
                    { 3, "Ethan", "a7d21fac-3b21-454a-a747-075f072d0cf3", "Mathis" },
                    { 4, "Simone", "c806cfae-bda9-47c5-8473-dd52fd056a9b", "Henderson" },
                    { 5, "Bob", "9ce89d88-75da-4a80-9b0d-3fe58582b8e2", "Williams" },
                    { 6, "Eve", "d224a03d-bf0c-4a05-b728-e3521e45d74d", "Davis" }
                });

            migrationBuilder.InsertData(
                table: "CopeJournals",
                columns: new[] { "Id", "CopeStrategyId", "JournalDate", "JournalText", "LastUpdated", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "This strategy was a tough one for me to implement...", null, 1 },
                    { 2, 6, new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "This strategy was easier for me to implement...", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "CopeEmotions",
                columns: new[] { "Id", "CopeJournalId", "EmotionId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CopeEmotions_CopeJournalId",
                table: "CopeEmotions",
                column: "CopeJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_CopeEmotions_EmotionId",
                table: "CopeEmotions",
                column: "EmotionId");

            migrationBuilder.CreateIndex(
                name: "IX_CopeJournals_CopeStrategyId",
                table: "CopeJournals",
                column: "CopeStrategyId");

            migrationBuilder.CreateIndex(
                name: "IX_CopeJournals_UserProfileId",
                table: "CopeJournals",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CopeEmotions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CopeJournals");

            migrationBuilder.DropTable(
                name: "Emotions");

            migrationBuilder.DropTable(
                name: "CopeStrategies");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
