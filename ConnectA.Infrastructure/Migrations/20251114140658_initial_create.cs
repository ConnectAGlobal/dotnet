using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial_create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    password_hash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    password_salt = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    type = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    active = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "learning_tracks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(2000)", maxLength: 2000, nullable: false),
                    level = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    senior_id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_learning_tracks", x => x.id);
                    table.ForeignKey(
                        name: "FK_learning_tracks_users_senior_id",
                        column: x => x.senior_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mentorship_matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    junior_id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    senior_id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CompatibilityScore = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    MatchedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mentorship_matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mentorship_matches_users_junior_id",
                        column: x => x.junior_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mentorship_matches_users_senior_id",
                        column: x => x.senior_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    user_id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    biography = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    skills = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    experience = table.Column<string>(type: "NVARCHAR2(2000)", maxLength: 2000, nullable: false),
                    objectives = table.Column<string>(type: "NVARCHAR2(2000)", maxLength: 2000, nullable: false),
                    location = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    lenguages = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_profiles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "learning_track_users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    user_id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    learning_track_id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    score = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    started_at = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    completed_at = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_learning_track_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_learning_track_users_learning_tracks_learning_track_id",
                        column: x => x.learning_track_id,
                        principalTable: "learning_tracks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_learning_track_users_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "track_stages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    learning_track_id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    title = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(2000)", maxLength: 2000, nullable: false),
                    activity_type = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    order = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    estimated_duration = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    resource_link = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_track_stages", x => x.id);
                    table.ForeignKey(
                        name: "FK_track_stages_learning_tracks_learning_track_id",
                        column: x => x.learning_track_id,
                        principalTable: "learning_tracks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mentorship_challenges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    mentorship_match_id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mentorship_challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mentorship_challenges_mentorship_matches_mentorship_match_id",
                        column: x => x.mentorship_match_id,
                        principalTable: "mentorship_matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mentorship_evaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    MentorshipMatchId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Evaluator = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Rating = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Comment = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    EvaluatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mentorship_evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mentorship_evaluations_mentorship_matches_MentorshipMatchId",
                        column: x => x.MentorshipMatchId,
                        principalTable: "mentorship_matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_learning_track_users_learning_track_id",
                table: "learning_track_users",
                column: "learning_track_id");

            migrationBuilder.CreateIndex(
                name: "IX_learning_track_users_user_id",
                table: "learning_track_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_learning_tracks_senior_id",
                table: "learning_tracks",
                column: "senior_id");

            migrationBuilder.CreateIndex(
                name: "IX_mentorship_challenges_mentorship_match_id",
                table: "mentorship_challenges",
                column: "mentorship_match_id");

            migrationBuilder.CreateIndex(
                name: "IX_mentorship_evaluations_MentorshipMatchId",
                table: "mentorship_evaluations",
                column: "MentorshipMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_mentorship_matches_junior_id",
                table: "mentorship_matches",
                column: "junior_id");

            migrationBuilder.CreateIndex(
                name: "IX_mentorship_matches_senior_id",
                table: "mentorship_matches",
                column: "senior_id");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_user_id",
                table: "profiles",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_track_stages_learning_track_id",
                table: "track_stages",
                column: "learning_track_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "learning_track_users");

            migrationBuilder.DropTable(
                name: "mentorship_challenges");

            migrationBuilder.DropTable(
                name: "mentorship_evaluations");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "track_stages");

            migrationBuilder.DropTable(
                name: "mentorship_matches");

            migrationBuilder.DropTable(
                name: "learning_tracks");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
