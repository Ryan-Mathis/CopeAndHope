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
                    CopeStrategyText = table.Column<string>(type: "text", nullable: false)
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
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "d01b49db-2e7e-46af-a901-8251ae673d45", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9ce89d88-75da-4a80-9b0d-3fe58582b8e2", 0, "361c7d60-74e0-45ee-b498-303e8475ed6c", "bob@williams.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAELz4baWQn7VLj4I184wqk46/SqkHjhg9Ov13R2ZnF+Z+/ZpHeR7dN94vONM5GrCbbw==", null, false, "2745112d-cca2-46ba-859a-64cfd776c08d", false, "BobWilliams" },
                    { "a7d21fac-3b21-454a-a747-075f072d0cf3", 0, "cacfd477-1a19-4455-9e29-b44fe51b046c", "ethan@mathis.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEOnd3iG4mqoFSH8bilYcmeb2LdOXVRdPvgJX6H+kA27DS3iuSZvSdOmiTTdujPLolA==", null, false, "62c28541-d9d0-43ad-b063-69acbc71d9e8", false, "EthanMathis" },
                    { "c806cfae-bda9-47c5-8473-dd52fd056a9b", 0, "cc7a34ea-6fc4-430a-8ff7-091c583882dc", "simone@henderson.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEMwpBTnyPQ2FH5qS8vwebYydXPFGOrHsrD6vGABLZP4ChJDBOlUu1WTnAMDOSG2AIg==", null, false, "1e4335d3-e435-43c5-8aab-43810914335b", false, "SimoneHenderson" },
                    { "d224a03d-bf0c-4a05-b728-e3521e45d74d", 0, "707aa808-6894-4eff-aed4-6e5bed957ff9", "Eve@Davis.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEFTOkRAvH5xHIpXiIcz/t3TxPNRTSsPIKpfIJnb6wlDbuwz3pfPcAKrstXXaz+WWig==", null, false, "49818934-a75a-406d-98f4-8d7fa952b865", false, "EveDavis" },
                    { "d8d76512-74f1-43bb-b1fd-87d3a8aa36df", 0, "74633978-1336-4ad2-a410-ed37fc4352ca", "ryan@mathis.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEMtTnshMzZka3Y5GdpQP+dwuXdH84rFGW+nqxq+bIrx9T7KUGEHxOB9Llnxwpl7e9Q==", null, false, "3a8486a4-becd-403d-858b-0083a19ca004", false, "RyanMathis" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "47960b3d-ca08-4fbe-9876-15119b0b4880", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAENDq0T5FbYROiTavVwdXG1f2XP/drbg0ddPGD7s6pnAVXQo34hqFWxOOBz5OexDXnw==", null, false, "48657560-3523-41fb-89fd-3562043c1a2c", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "CopeStrategies",
                columns: new[] { "Id", "CopeStrategyText" },
                values: new object[,]
                {
                    { 1, "Example Coping Strategy 1" },
                    { 2, "Example Coping Strategy 2" },
                    { 3, "Example Coping Strategy 3" },
                    { 4, "Example Coping Strategy 4" },
                    { 5, "Example Coping Strategy 5" },
                    { 6, "Example Coping Strategy 6" },
                    { 7, "Example Coping Strategy 7" },
                    { 8, "Example Coping Strategy 8" },
                    { 9, "Example Coping Strategy 9" },
                    { 10, "Example Coping Strategy 10" },
                    { 11, "Example Coping Strategy 11" },
                    { 12, "Example Coping Strategy 12" },
                    { 13, "Example Coping Strategy 13" },
                    { 14, "Example Coping Strategy 14" },
                    { 15, "Example Coping Strategy 15" },
                    { 16, "Example Coping Strategy 16" },
                    { 17, "Example Coping Strategy 17" },
                    { 18, "Example Coping Strategy 18" },
                    { 19, "Example Coping Strategy 19" },
                    { 20, "Example Coping Strategy 20" },
                    { 21, "Example Coping Strategy 21" },
                    { 22, "Example Coping Strategy 22" },
                    { 23, "Example Coping Strategy 23" },
                    { 24, "Example Coping Strategy 24" },
                    { 25, "Example Coping Strategy 25" },
                    { 26, "Example Coping Strategy 26" },
                    { 27, "Example Coping Strategy 27" },
                    { 28, "Example Coping Strategy 28" },
                    { 29, "Example Coping Strategy 29" },
                    { 30, "Example Coping Strategy 30" },
                    { 31, "Example Coping Strategy 31" }
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
