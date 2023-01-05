using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductFeedback.API.Migrations
{
    /// <inheritdoc />
    public partial class SuggestionDBAddCommentReply2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SuggestionsCommentReply",
                keyColumn: "Id",
                keyValue: 1,
                column: "SuggestionCommentId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SuggestionsCommentReply",
                keyColumn: "Id",
                keyValue: 1,
                column: "SuggestionCommentId",
                value: null);
        }
    }
}
