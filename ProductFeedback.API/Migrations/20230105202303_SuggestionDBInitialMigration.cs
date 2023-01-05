using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductFeedback.API.Migrations
{
    /// <inheritdoc />
    public partial class SuggestionDBInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Upvotes = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuggestionsComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SuggestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestionsComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuggestionsComment_Suggestions_SuggestionId",
                        column: x => x.SuggestionId,
                        principalTable: "Suggestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuggestionsComment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuggestionsCommentReply",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReplyingTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SuggestionCommentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestionsCommentReply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuggestionsCommentReply_SuggestionsComment_SuggestionCommentId",
                        column: x => x.SuggestionCommentId,
                        principalTable: "SuggestionsComment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SuggestionsCommentReply_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Suggestions",
                columns: new[] { "Id", "Category", "Description", "Status", "Title", "Upvotes" },
                values: new object[] { 1, "enhancement", "Easier to search for solutions based on a specific stack.", "live", "Add tags for solutions okay", 144 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Image", "UserName" },
                values: new object[] { 1, "./assets/user-images/image-suzanne.jpg", "Suzanne Chang" });

            migrationBuilder.InsertData(
                table: "SuggestionsComment",
                columns: new[] { "Id", "Content", "SuggestionId", "UserId" },
                values: new object[] { 1, "Awesome idea! Trying to find framework-specific projects within the hubs can be tedious", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_SuggestionsComment_SuggestionId",
                table: "SuggestionsComment",
                column: "SuggestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SuggestionsComment_UserId",
                table: "SuggestionsComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SuggestionsCommentReply_SuggestionCommentId",
                table: "SuggestionsCommentReply",
                column: "SuggestionCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_SuggestionsCommentReply_UserId",
                table: "SuggestionsCommentReply",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuggestionsCommentReply");

            migrationBuilder.DropTable(
                name: "SuggestionsComment");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
