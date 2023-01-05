using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductFeedback.API.Migrations
{
    /// <inheritdoc />
    public partial class SuggestionDBAddCommentReply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Image", "UserName" },
                values: new object[] { 2, ".", "Test User" });

            migrationBuilder.InsertData(
                table: "SuggestionsCommentReply",
                columns: new[] { "Id", "Content", "ReplyingTo", "SuggestionCommentId", "UserId" },
                values: new object[] { 1, "Good idea!", "Suzanne Chang", null, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuggestionsCommentReply",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
